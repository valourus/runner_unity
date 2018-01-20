using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Sources.Logic {
    public class MoveForwardSystem : ReactiveSystem<InputEntity> {
        private Contexts context { get; set; }
        private IGroup<GameEntity> obstacles { get; set; }
        private GameObject player { get; set; }

        public MoveForwardSystem(Contexts context) : base(context.input) {
            this.context = context;
            obstacles = context.game.GetGroup(GameMatcher.Obstacle);
            player = RootSystem.cfg.player;
        }

        public MoveForwardSystem(ICollector<InputEntity> collector) : base(collector) { }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context) {
            return context.CreateCollector(InputMatcher.Tick);
        }

        protected override bool Filter(InputEntity entity) {
            return true;
        }

        protected override void Execute(List<InputEntity> entities) {
            foreach(var obstacle in obstacles)
                if(obstacle.view.value != null)
                    obstacle.view.value.transform.Translate(Vector3.forward * Time.deltaTime * context.game.speed.value * 10);

            //if(!Input.GetKey(KeyCode.A) && !Input.GetKey(KeyCode.D))
            if(!Input.GetMouseButton(0))
                player.transform.rotation = Quaternion.Lerp(
                    player.transform.rotation,
                    Quaternion.AngleAxis(180, Vector3.up),
                    context.game.speed.value * 10 * Time.deltaTime);
        }
    }
}