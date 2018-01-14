using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Sources.Logic {
    public class MoveLeftSystem : ReactiveSystem<InputEntity> {
        private Contexts context { get; set; }
        private IGroup<GameEntity> obstacles { get; set; }
        private GameObject player { get; set; }
        
        public MoveLeftSystem(Contexts context) : base(context.input) {
            this.context = context;
            obstacles = this.context.game.GetGroup(GameMatcher.Obstacle);
            player = RootSystem.cfg.player;
        }
        public MoveLeftSystem(ICollector<InputEntity> collector) : base(collector) { }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context) {
            return context.CreateCollector(InputMatcher.Tick);
        }

        protected override bool Filter(InputEntity entity) {
            return true;
        }

        protected override void Execute(List<InputEntity> entities) {
            //if(!Input.GetKey(KeyCode.A)) return;
            if(Input.GetMouseButton(0) && Input.mousePosition.x > Screen.width / 2) return;
            player.transform.rotation = Quaternion.Lerp(
                player.transform.rotation,
                Quaternion.AngleAxis(150, Vector3.up),
                context.game.speed.value * 10 * Time.deltaTime);
            
            foreach(var obstacle in obstacles) 
                obstacle.view.value.transform.Translate(Vector3.left * Time.deltaTime * 10 * context.game.speed.value);
        }
    }
}