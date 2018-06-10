using System.Collections.Generic;
using Entitas;
using Sources.Components;
using UnityEngine;

namespace Sources.Logic {
    public class SlowMotionCooldownSystem : ReactiveSystem<InputEntity> {
        private GameContext game { get; set; }
        private IGroup<GameEntity> entities { get; set; }
        private RectTransform cover { get; set; }
        private Rect size { get; set; }
        
        public SlowMotionCooldownSystem(Contexts context) : base(context.input) {
            game = context.game;
            entities = game.GetGroup(GameMatcher.SlowMotionCoolDown);
            cover = RootSystem.cfg.slowMotionCover.GetComponent<RectTransform>();
            size = RootSystem.cfg.jumpCover.GetComponent<RectTransform>().rect;
        }
        public SlowMotionCooldownSystem(ICollector<InputEntity> collector) : base(collector) { }
        
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
                    game.speed.value += 0.5f;
                    entity.RemoveSlowMotionCoolDown();
                    break;
                }
                float percentage = (Time.realtimeSinceStartup - usedAt) / cooldown;
                cover.sizeDelta = new Vector2(size.width, percentage * size.height);
            }
        }
    }
}