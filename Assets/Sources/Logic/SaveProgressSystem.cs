using Entitas;
using Sources.Utils;

namespace Sources.Logic {
    public class SaveProgressSystem : ITearDownSystem {

        private GameContext game { get; set; }
        
        public SaveProgressSystem(GameContext game) {
            this.game = game;
        }
        
        public void TearDown() {
            VUtils.getInstance().save(game.experience.level, game.experience.xp, 10);
        }
    }
}