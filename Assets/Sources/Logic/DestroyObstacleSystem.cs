using System.Collections.Generic;
using Entitas;
using Entitas.VisualDebugging.Unity;
using UnityEngine;
using UnityEngine.Assertions.Must;

namespace Sources.Logic {
    public class DestroyObstacleSystem : IInitializeSystem, IExecuteSystem {
        private GameContext game { get; set; }
        private IGroup<GameEntity> obstacles { get; set; }
        private GameObject obstaclesGO { get; set; }

        public DestroyObstacleSystem(Contexts context) {
            game = context.game;
        }
        
        public void Initialize() {
            obstacles = game.GetGroup(GameMatcher.Obstacle);
            obstaclesGO = RootSystem.cfg.obstacles;
        }

        public void Execute() {
            for(int i = obstacles.count - 1; i >= 0; i--) {
                if(obstacles.GetEntities()[i].view.value == null) {
                    obstacles.GetEntities()[i].Destroy();
                }
            }

            for(int i = 0; i < obstaclesGO.transform.childCount; i++) {
                Transform go = obstaclesGO.transform.GetChild(i);
                if(go.childCount < 1) {
                    go.gameObject.DestroyGameObject();
                }
            }
        }
    }
}