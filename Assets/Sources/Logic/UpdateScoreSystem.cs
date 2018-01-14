using System;
using Entitas;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.Logic {
    public class UpdateScoreSystem : IInitializeSystem, IExecuteSystem {
        private GameContext game { get; set; }
        private Text scoreLabel { get; set; }

        public UpdateScoreSystem(Contexts context) {
            game = context.game;
        }

        public void Initialize() {
            scoreLabel = GameObject.Find("score").GetComponent<Text>();
        }

        public void Execute() {
            if(game.isDead) return;
            game.score.currScore = Mathf.CeilToInt(game.score.currScore + 3 * Time.deltaTime);
            scoreLabel.text = "" + game.score.currScore;
        }
    }
}