using System.Runtime.Serialization;
using Entitas;
using Entitas.Unity;
using Sources.Monobehaviour;
using Sources.Utils;
using UnityEngine;

namespace Sources.Logic {
    public class InitPlayerSystem : IInitializeSystem {
        private Contexts context { get; set; }

        public InitPlayerSystem(Contexts context) {
            this.context = context;
        }

        public void Initialize() {
            var player = context.game.CreateEntity();
            GameObject go = RootSystem.cfg.player;
            player.AddView(go);
            player.isDead = false;
            player.AddSpeed(0);
            player.AddScore(VUtils.getInstance().getHighscore(), 0);
            player.AddExperience(VUtils.getInstance().getLevel(), VUtils.getInstance().getXP());
        }
    }
}