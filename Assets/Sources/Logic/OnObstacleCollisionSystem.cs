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
			return context.CreateCollector(InputMatcher.Collision);
		}

		protected override bool Filter(InputEntity entity) {
			return entity.hasCollision &&
			       entity.collision.self.CompareTag("Obstacle") &&
			       entity.collision.other.CompareTag("Obstacle");
		}

		protected override void Execute(List<InputEntity> entities) {
			foreach(var entity in entities) {
				Debug.Log("Deleted: " + entity.collision.other.name);
				entity.collision.other.GetEntityLink().entity.Destroy();
				entity.collision.other.DestroyGameObject();
				entity.collision.other.Unlink();
				entity.Destroy();
			}
		}
	}
}
