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
            if(!RootSystem.cfg.isPaused) {
                Config cfg = RootSystem.cfg;
                cfg.player.GetComponent<Animator>().Play("fall");
                RootSystem.cfg.isPaused = true;
                game.isDead = true;
                LevelLogic.addXP(game.score.currScore, game.experience);
                RootSystem.cfg.gameOverMenu.AddComponent<FadeIn>();
                if(game.score.currScore > game.score.highscore) {
                    game.score.highscore = game.score.currScore;
                }
                VUtils.getInstance().save(game.experience.level, game.experience.xp, game.score.highscore);
                
                RootSystem.cfg.endScore.GetComponent<Text>().text = 
                    "highscore: " + game.score.highscore + "\n" +
                    game.score.currScore;
                RootSystem.cfg.gamemenu.AddComponent<FadeOut>();
                GameObject lowerPart = entities[0].playerCollision.other.transform.GetChild(0).gameObject;
                GameObject upperPart = entities[0].playerCollision.other.transform.GetChild(1).gameObject;
                Transform parent = lowerPart.transform.parent;
                upperPart.transform.parent = parent.parent;
                lowerPart.transform.parent = parent.parent;
                Object.Destroy(parent.gameObject);
                GameObject go = new GameObject();
                go.AddComponent<BoxCollider>();
                go.transform.position = lowerPart.transform.position;
                upperPart.AddComponent<CapsuleCollider>().radius = 1;
                upperPart.AddComponent<Rigidbody>().AddForce(new Vector3(0, 0, -2 * game.speed.value), ForceMode.Impulse);
                Object.Destroy(go, 0.5f);
                Object.Destroy(upperPart, 2f);
                game.speed.value = 0;
            } else {
                Debug.Log("deleting obstacle because the player was there first");
                entities[0].playerCollision.other.DestroyGameObject();
            }     
            foreach(var entity in entities) {
                entity.Destroy();
            }
        }
    }
}