using Entitas;
using UnityEngine;

namespace Sources.Components {
	[Input]
	public class PlayerCollisionComponent : IComponent {
		public GameObject self;
		public GameObject other;
	}
}
