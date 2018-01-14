using Entitas;
using Sources.Utils;
using UnityEngine;
using UnityEngine.UI;

namespace Sources.Logic {
    public class UpdateUILayerSystem : IInitializeSystem, IExecuteSystem {
        private Text levelTxt { get; set; }
        private RectTransform xpBar { get; set; }
        private int barValue { get; set; }
        private GameContext game { get; set; }

        public UpdateUILayerSystem(Contexts context) {
            game = context.game;
        }
        
        public void Initialize() {
            levelTxt = RootSystem.cfg.level.GetComponent<Text>();
            levelTxt.text = "Level: " + VUtils.getInstance().getLevel();
            xpBar = RootSystem.cfg.xpBar.GetComponent<RectTransform>();
            xpBar.sizeDelta = new Vector2(LevelLogic.getXPPercentage(game.experience) * 2, 22);      
        }

        public void Execute() {
            xpBar.sizeDelta = new Vector2(
                Mathf.Lerp(xpBar.sizeDelta.x, (float) game.experience.xp / LevelLogic.getXPNeeded(game.experience.level) * 200,
                    5 * Time.deltaTime),
                22);
            levelTxt.text = "level: " + game.experience.level;
        }
    }
}