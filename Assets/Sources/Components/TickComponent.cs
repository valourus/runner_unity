using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Sources.Components {
    [Input]
    [Unique]
    public class TickComponent : IComponent {
        public int value;
    }
}