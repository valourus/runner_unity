using System.Collections.Generic;
using Entitas;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.Logic {
    public class StartGameSystem : ReactiveSystem<InputEntity> {
        private GameContext game { get; set; }
        
        public StartGameSystem(Contexts context) : base(context.input) {
            game = context.game;
        }
        public StartGameSystem(ICollector<InputEntity> collector) : base(collector) { }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context) {
            return context.CreateCollector(InputMatcher.OnStartClick.Added());
        }

        protected override bool Filter(InputEntity entity) {
            return true;
        }

        protected override void Execute(List<InputEntity> entities) {
            RootSystem.cfg.cam.GetComponent<Animator>().SetTrigger("movebehindplayer");
            RootSystem.cfg.isPaused = false;
            game.score.currScore = 0;
            game.speed.value = 1;

            RootSystem.cfg.mainmenu.GetComponent<CanvasGroup>().blocksRaycasts = false;
            RootSystem.cfg.mainmenu.AddComponent<FadeOut>();
            RootSystem.cfg.levelBar.AddComponent<FadeOut>();
            RootSystem.cfg.gamemenu.AddComponent<FadeIn>();  
            entities[0].Destroy();
        }
    }
}