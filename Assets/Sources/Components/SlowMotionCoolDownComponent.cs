using Entitas;
using UnityEngine;

namespace Sources.Components {
	public class SlowMotionCoolDownComponent : IComponent {
		public float cooldown;
		public float usedAt;
	}
}
