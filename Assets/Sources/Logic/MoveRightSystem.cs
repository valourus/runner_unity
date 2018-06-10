using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Sources.Logic {
    public class MoveRightSystem : ReactiveSystem<InputEntity> {
        private Contexts context { get; set; }
        private IGroup<GameEntity> obstacles { get; set; }
        private GameObject player { get; set; }

        public MoveRightSystem(Contexts context) : base(context.input) {
            this.context = context;
            obstacles = context.game.GetGroup(GameMatcher.Obstacle);
            player = GameObject.Find("player");
        }

        public MoveRightSystem(ICollector<InputEntity> collector) : base(collector) { }


        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context) {
            return context.CreateCollector(InputMatcher.Tick);
        }

        protected override bool Filter(InputEntity entity) {
            return true;
        }

        protected override void Execute(List<InputEntity> entities) {
            //if(!Input.GetKey(KeyCode.D)) return;
            if(!Input.GetMouseButton(0) || Input.mousePosition.x < Screen.width - Screen.width*0.2) return;
            player.transform.rotation = Quaternion.Lerp(
                player.transform.rotation,
                Quaternion.AngleAxis(210, Vector3.up),
                18 * Time.deltaTime);

            foreach(var obstacle in obstacles)
                if(obstacle.view.value !=  null)
                    obstacle.view.value.transform.Translate(Vector3.right * Time.deltaTime * context.game.speed.value * 10);
        }
    }
}