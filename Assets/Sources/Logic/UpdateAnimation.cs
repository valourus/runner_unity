using Entitas;
using UnityEngine;

namespace Sources.Logic {
	public class UpdateAnimation : IInitializeSystem, IExecuteSystem {
		private GameContext game { get; set; }
		private Animator anim { get; set; }
		private readonly int speedHash = Animator.StringToHash("speed");
		
		public UpdateAnimation(Contexts context) {
			game = context.game;
		}
		
		public void Initialize() {
			anim = RootSystem.cfg.player.GetComponent<Animator>();
		}

		public void Execute() {
			anim.SetFloat(speedHash, game.speed.value);
			anim.speed = game.speed.value;
		}
		
	}
}
