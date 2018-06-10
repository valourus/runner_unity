using System.Collections.Generic;
using System.Runtime.Serialization.Formatters;
using Entitas;
using Entitas.Unity;
using Sources.Monobehaviour;
using Sources.Utils;
using UnityEditor;
using UnityEngine;

namespace Sources.Logic {
    public class GenerateObstacleSystem : ReactiveSystem<InputEntity>, IInitializeSystem {
        private Contexts context { get; set; }
        private Transform obstacles { get; set; }

        public GenerateObstacleSystem(Contexts context) : base(context.input) {
            this.context = context;
            obstacles = RootSystem.cfg.obstacles.transform;
        }

        public GenerateObstacleSystem(ICollector<InputEntity> collector) : base(collector) { }

        public void Initialize() {
            for(int i = 0; i < 15; i++)
                generateObstale(Random.Range(-100, 0), 0.5f, Random.Range(-200, 100));
            for(int i = 0; i < 15; i++)
                generateObstale(Random.Range(-100, 0), 0.5f, Random.Range(-200, 100));
        }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context) {
            return context.CreateCollector(InputMatcher.GenerateObstacle.Added());
        }

        protected override bool Filter(InputEntity entity) {
            return true;
        }

        protected override void Execute(List<InputEntity> entities) {
            foreach(var entity in entities) {
                switch(entity.generateObstacle.place) {
                    case GeneratePlace.UPFRONT:
                        generateObstale(Random.Range(-100, 0), 0.5f, -200);
                        break;
                    case GeneratePlace.LEFT:
                        generateObstale(-9, 0.5f, Random.Range(-200, 100));
                        break;
                    case GeneratePlace.RIGHT:
                        generateObstale(-104, 0.5f, Random.Range(-200, 100));
                        break;
                }

                if(obstacles.childCount < 40) {
                    generateObstale(Random.Range(-100, 0), 0.5f, -200);
                }

                entity.Destroy();
            }
        }

        private void generateObstale(float x, float y, float z) {
            var entity = context.game.CreateEntity();
            GameObject go;
            int chance = Random.Range(0, 100);
            if(chance < 20) {
                go = Object.Instantiate(RootSystem.cfg.tree1, new Vector3(x, y, z), Quaternion.identity);
            }
            else if(chance > 20 && chance < 65) {
                go = Object.Instantiate(RootSystem.cfg.stone2, new Vector3(x, y, z), Quaternion.identity);
            }
            else if(chance < 65 && chance > 90) {
                go = Object.Instantiate(RootSystem.cfg.stone1, new Vector3(x, y, z), Quaternion.identity);
            }
            else {
                go = Object.Instantiate(RootSystem.cfg.tree2, new Vector3(x, y, z), Quaternion.identity);
            }

            go.transform.GetChild(0).localRotation = Quaternion.Euler(0, Random.Range(0, 360), 0);
            go.tag = "Obstacle";
            go.name = "obstacle";
            go.transform.parent = obstacles.transform;
            entity.isObstacle = true;
            entity.AddView(go);
        }
    }
}