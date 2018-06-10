using System.Collections.Generic;
using Entitas;
using UnityEngine;

namespace Sources.Logic {
	public class PlayerJumpSystem : ReactiveSystem<InputEntity> {

		private Animator anim { get; set; }
		private Rigidbody player { get; set; }
		private GameContext game { get; set; }
		
		public PlayerJumpSystem(Contexts context) : base(context.input) {
			player = RootSystem.cfg.player.GetComponent<Rigidbody>();
			anim = RootSystem.cfg.player.GetComponent<Animator>();
			game = context.game;
		}
		public PlayerJumpSystem(ICollector<InputEntity> collector) : base(collector) { }
		
		protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context) {
			return context.CreateCollector(InputMatcher.SwipeUp.Added());
		}

		protected override bool Filter(InputEntity entity) {
			return true;
		}

		protected override void Execute(List<InputEntity> entities) {
			
			if(!game.isJumping && !game.speedEntity.hasJumpCoolDown) {
				game.isJumping = true;
				player.AddForce(Vector3.up * 90, ForceMode.Impulse); 
				anim.SetTrigger("jump");
			}

			foreach(var entity in entities) 
				entity.Destroy();
			
		}
	}
}
