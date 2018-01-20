using System.Collections.Generic;
using System.Linq;
using System.Xml;
using Entitas;
using Entitas.Unity;
using Entitas.VisualDebugging.Unity;
using Sources.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.Logic {
    public class OnPlayerCollisionSystem : ReactiveSystem<InputEntity> {
        private GameContext game { get; set; }

        public OnPlayerCollisionSystem(Contexts context) : base(context.input) {
            game = context.game;
        }

        public OnPlayerCollisionSystem(ICollector<InputEntity> collector) : base(collector) { }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context) {
            return context.CreateCollector(InputMatcher.PlayerCollision.Added());
        }

        protected override bool Filter(InputEntity entity) {
            return true;
        }

        protected override void Execute(List<InputEntity> entities) {            
            RootSystem.cfg.isPaused = true;    
            game.isDead = true;
            LevelLogic.addXP(game.score.currScore, game.experience);            
            
            Config cfg = RootSystem.cfg;
            cfg.player.GetComponent<Animator>().Play("fall");
            foreach(var entity in entities) {
                entity.Destroy();
            }
        }
    }
}