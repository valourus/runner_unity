using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Sources.Logic {
    public class JumpCoolDownSystem : ReactiveSystem<InputEntity> {
        private IGroup<GameEntity> entities { get; set; }
        private RectTransform cover { get; set; }
        private RectTransform icon { get; set; }
        private float startwidth { get; set; }
        private float startHeight { get; set; }

        public JumpCoolDownSystem(Contexts context) : base(context.input) {
            entities = context.game.GetGroup(GameMatcher.JumpCoolDown);
            cover = RootSystem.cfg.jumpCover.GetComponent<RectTransform>();
            icon = RootSystem.cfg.jumpIcon.GetComponent<RectTransform>();
        }

        public JumpCoolDownSystem(ICollector<InputEntity> collector) : base(collector) { }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context) {
            return context.CreateCollector(InputMatcher.Tick);
        }

        protected override bool Filter(InputEntity entity) {
            return true;
        }

        protected override void Execute(List<InputEntity> entities) {
            if(this.entities.count < 1) return;
            foreach(var entity in this.entities) {
                float usedAt = entity.jumpCoolDown.usedAt;
                float cooldown = entity.jumpCoolDown.cooldown;
                if(usedAt + cooldown < Time.realtimeSinceStartup) {
                    entity.RemoveJumpCoolDown();
                    cover.sizeDelta = new Vector2(icon.rect.width, icon.rect.height);
                    break;
                }

                float percentage = (Time.realtimeSinceStartup - usedAt) / cooldown;
                cover.sizeDelta = new Vector2(icon.rect.width, percentage * icon.rect.height);
            }
        }
    }
}