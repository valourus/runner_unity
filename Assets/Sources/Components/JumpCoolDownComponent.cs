using Entitas;

namespace Sources.Components {
    [Game]
    public class JumpCoolDownComponent : IComponent {
        public int cooldown;
        public float usedAt;
    }
}