using System;
using System.Collections.Generic;
using Entitas;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.Logic {
    public class UpdateScoreSystem : ReactiveSystem<InputEntity> {
        private GameContext game { get; set; }
        private Text scoreLabel { get; set; }

        public UpdateScoreSystem(Contexts context) : base(context.input) {
            game = context.game;
            scoreLabel = RootSystem.cfg.score.GetComponent<Text>();
        }
        
        public UpdateScoreSystem(ICollector<InputEntity> collector) : base(collector) { }

        protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context) {
            return context.CreateCollector(InputMatcher.Tick);
        }

        protected override bool Filter(InputEntity entity) {
            return true;
        }

        protected override void Execute(List<InputEntity> entities) {
            game.score.currScore = Mathf.CeilToInt(game.score.currScore + 0.5f * Time.deltaTime);
            scoreLabel.text = "" + game.score.currScore;
        
        }

       }
}