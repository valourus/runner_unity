using Entitas;
namespace Sources.Components {
	[Game]
	public class SlowMotionCoolDownComponent : IComponent {
		public float cooldown;
		public float usedAt;
	}
}
