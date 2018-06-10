using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using Sources.Utils;
using UnityEngine;

namespace Sources.Logic {
    public class RestartGameSystem : ReactiveSystem<InputEntity>, IInitializeSystem {
        private GameContext game { get; set; }
        private GameObject player;
        private GameEntity playerEntity { get; set; }

        public RestartGameSystem(Contexts context) : base(context.input) {
            game = context.game;
        }
        
        public void Initialize() {
            player = RootSystem.cfg.player;
            playerEntity = player.GetEntityLink().entity as GameEntity;
        }

        public RestartGameSystem(ICollector<InputEntity> collector) : base(collector) { }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context) {
            return context.CreateCollector(InputMatcher.RestartGame.Added());
        }

        protected override bool Filter(InputEntity entity) {
            return true;
        }

        protected override void Execute(List<InputEntity> entities) {
            foreach(var entity in entities) {
                switch(entity.restartGame.fase) {
                    case RestartFase.FASE1:
                        player.GetComponent<Animator>().SetTrigger("stand up");
                        if(playerEntity.hasJumpCoolDown)
                            playerEntity.RemoveJumpCoolDown();
                        if(playerEntity.hasSlowMotionCoolDown)
                            playerEntity.RemoveSlowMotionCoolDown();
                        game.isDead = false;
                        RootSystem.cfg.gameOverMenu.AddComponent<FadeOut>();
                        RootSystem.cfg.levelBar.AddComponent<FadeOut>();
                        break;
                    case RestartFase.FASE2:
                        game.speed.value = 1;
                        game.score.currScore = 0;
                        RootSystem.cfg.gamemenu.AddComponent<FadeIn>();
                        RootSystem.cfg.isPaused = false;
                        player.GetComponent<Rigidbody>().AddForce(Vector3.up * 90, ForceMode.Impulse); 
                        player.GetComponent<Animator>().SetTrigger("jump");
                        break;
                }

                entity.Destroy();
            }
        }
    }
}