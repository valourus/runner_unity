using System.Runtime.Serialization;
using Entitas;
using Entitas.Unity;
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
            go.Link(player, context.game);
            go.AddComponent<CollisionEntry>();
            player.AddView(go);
            player.isDead = false;
            player.AddSpeed(1);
            player.AddScore(VUtils.getInstance().getHighscore(), 0);
            player.AddExperience(VUtils.getInstance().getLevel(), VUtils.getInstance().getXP());
        }
    }
}