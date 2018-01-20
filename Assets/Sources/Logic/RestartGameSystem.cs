using System.Collections.Generic;
using Entitas;
using Entitas.VisualDebugging.Unity;
using Sources.Monobehaviour;
using Sources.Utils;
using UnityEngine;

namespace Sources.Logic {
    public class RestartGameSystem : ReactiveSystem<InputEntity> {
        private GameContext game { get; set; }
        private GameObject player;

        public RestartGameSystem(Contexts context) : base(context.input) {
            game = context.game;
            player = RootSystem.cfg.player;
        }

        public RestartGameSystem(ICollector<InputEntity> collector) : base(collector) { }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context) {
            return context.CreateCollector(InputMatcher.RestartGame.Added());
        }

        protected override bool Filter(InputEntity entity) {
            return true;
        }

        protected override void Execute(List<InputEntity> entities) {
            foreach(var e in entities) {
                switch(e.restartGame.fase) {
                    case RestartFase.FASE1:
                        playerStandup();
                        break;
                    case RestartFase.FASE2:
                        startGame();
                        break;
                    case RestartFase.FASE3:
                        
                        break;
                }
                e.Destroy();
            }
            
        }

        private void walkBack() {
            RaycastHit hit;
            if(Physics.Raycast(player.transform.position, Vector3.forward, out hit)) {
                hit.collider.gameObject.DestroyGameObject();
            }
        }

        private void playerStandup() {
            player.GetComponent<Animator>().SetTrigger("standup");
        }

        private void startGame() {
            RootSystem.cfg.isPaused = false;
            game.speed.value = 1;
            game.score.currScore = 0;
        }
    }
}