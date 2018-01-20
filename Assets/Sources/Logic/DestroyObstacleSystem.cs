using System.Collections.Generic;
using Entitas;
using UnityEngine;
using UnityEngine.Assertions.Must;

namespace Sources.Logic {
    public class DestroyObstacleSystem : ReactiveSystem<InputEntity> {
        private GameContext game;
        private IGroup<GameEntity> obstacles;

        public DestroyObstacleSystem(Contexts context) : base(context.input) {
            game = context.game;
            obstacles = game.GetGroup(GameMatcher.Obstacle);
        }

        public DestroyObstacleSystem(ICollector<InputEntity> collector) : base(collector) { }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context) {
            return context.CreateCollector(InputMatcher.Tick);
        }

        protected override bool Filter(InputEntity entity) {
            return true;
        }

        protected override void Execute(List<InputEntity> entities) {
            for(int i = obstacles.count - 1; i >= 0; i--) {
                if(obstacles.GetEntities()[i].view.value == null) {
                    obstacles.GetEntities()[i].Destroy();
                }
            }
        }
    }
}