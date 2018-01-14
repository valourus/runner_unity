using System.Collections.Generic;
using Entitas;
using Sources.Components;
using UnityEngine;

namespace Sources.Logic {
    public class CooldownSystem : ReactiveSystem<InputEntity> {
        private GameContext game { get; set; }
        private IGroup<GameEntity> entities { get; set; }

        public CooldownSystem(Contexts context) : base(context.input) {
            game = context.game;
            entities = game.GetGroup(GameMatcher.SlowMotionCoolDown);
        }
        public CooldownSystem(ICollector<InputEntity> collector) : base(collector) { }
        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context) {
            return context.CreateCollector(InputMatcher.AllOf(InputMatcher.Tick));
        }

        protected override bool Filter(InputEntity entity) {
            return true;
        }

        protected override void Execute(List<InputEntity> entities) {
            foreach(var entity in this.entities) {
                float usedAt = entity.slowMotionCoolDown.usedAt;
                float cooldown = entity.slowMotionCoolDown.cooldown;
                if(usedAt + cooldown < Time.realtimeSinceStartup) {
                    game.speed.value = 1;
                    entity.RemoveSlowMotionCoolDown();
                    break;
                }
            }
        }
    }
}