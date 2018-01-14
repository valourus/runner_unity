using Entitas;
using Entitas.Unity;
using Sources.Utils;
using UnityEngine;

namespace Sources.Logic {
    public class InitObstacleSystem : IInitializeSystem {
        private Contexts context { get; set; }

        public InitObstacleSystem(Contexts context) {
            this.context = context;
        }

        public void Initialize() {
            GameObject obstacles = GameObject.Find("Obstacles");
            for(int i = 0; i < 110; i++) {
                var entity = context.game.CreateEntity();
                GameObject go = GameObject.CreatePrimitive(PrimitiveType.Cube);
                go.AddComponent<Rigidbody>().isKinematic = true;
                go.AddComponent<CollisionEntry>();
                go.tag = "Obstacle";
                go.name = "obstacle " + i;
                go.Link(entity, context.game);
                go.transform.parent = obstacles.transform;
                go.transform.position = new Vector3(Random.Range(-100, 0), 0.5f, Random.Range(-100, 0));
                entity.isObstacle = true;
                entity.AddView(go);
            }
        }
    }
}