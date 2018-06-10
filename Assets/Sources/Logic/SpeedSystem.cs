using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Sources.Logic {
    public class SpeedSystem : ReactiveSystem<InputEntity> {

        private GameContext game { get; set; }

        public SpeedSystem(Contexts context) : base(context.input) {
            game = context.game;
        }
        
        public SpeedSystem(ICollector<InputEntity> collector) : base(collector) { }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context) {
            return context.CreateCollector(InputMatcher.Tick);
        }

        protected override bool Filter(InputEntity entity) {
            return true;
        }

        protected override void Execute(List<InputEntity> entities) {          
            game.speed.value += 0.1f * Time.deltaTime;
        }
    }
}
