using System.Collections.Generic;
using Entitas;
using Entitas.Unity;
using Entitas.VisualDebugging.Unity;
using UnityEngine;

namespace Sources.Logic {
	public class OnObstacleCollisionSystem : ReactiveSystem<InputEntity> {
		
		public OnObstacleCollisionSystem(IContext<InputEntity> context) : base(context) { }
		public OnObstacleCollisionSystem(ICollector<InputEntity> collector) : base(collector) { }
		
		protected override ICollector<InputEntity> GetTrigger(IContext<InputEntity> context) {
			return context.CreateCollector(InputMatcher.ObstacleCollision.Added());
		}

		protected override bool Filter(InputEntity entity) {
			return entity.hasObstacleCollision;
		}

		protected override void Execute(List<InputEntity> entities) {
			foreach(var entity in entities) {
				if(entity.obstacleCollision.other != null) {
					Debug.Log("Deleted obstacle");
					entity.obstacleCollision.other.DestroyGameObject();
				}
				entity.Destroy();
			}
		}
	}
}
