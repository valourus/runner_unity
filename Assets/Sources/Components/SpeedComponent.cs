using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Sources.Components {
    [Game]
    [Unique]
    public class SpeedComponent : IComponent {
        public float value;
    }
}