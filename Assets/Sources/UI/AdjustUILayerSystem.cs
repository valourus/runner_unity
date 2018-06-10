using Entitas;
using UnityEngine;

namespace Sources.UI {
    public class AdjustUILayerSystem : IInitializeSystem {

        private GameContext game { get; set; }
        
        public AdjustUILayerSystem(Contexts contexts) {
            game = contexts.game;
        }
        
        public void Initialize() {
            RootSystem.cfg.startBtn.GetComponent<RectTransform>().sizeDelta = 
                new Vector2 (Screen.width, 200);
            
        }
    }
}    