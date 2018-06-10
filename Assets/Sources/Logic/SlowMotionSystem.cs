using System;
using System.Collections.Generic;
using System.Threading;
using Entitas;
using UnityEngine;

namespace Sources.Logic {
	public class SlowMotionSystem : ReactiveSystem<InputEntity> {
		private GameContext game { get; set; }

		public SlowMotionSystem(Contexts context) : base(context.input) {
			game = context.game;
		}
		
		public SlowMotionSystem(ICollector<InputEntity> collector) : base(collector) { }
		
		protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context) {
			return context.CreateCollector(InputMatcher.SwipDown.Added());
		}

		protected override bool Filter(InputEntity entity) {
			return entity.isSwipDown;
		}

		protected override void Execute(List<InputEntity> entities) {
			if(!game.speedEntity.hasSlowMotionCoolDown) {
				game.speed.value -= 0.5f;
				game.speedEntity.AddSlowMotionCoolDown(5, Time.realtimeSinceStartup);
			}

			foreach(var entity in entities) {
				entity.Destroy();
			}
		}
	}
}
