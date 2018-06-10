using Entitas;
using Entitas.CodeGeneration.Attributes;
using Sources.Utils;

namespace Sources.Components {
    [Game]
    [Unique]
    public class RestartableComponent : IComponent {
        public RestartFase fase; 
    }
}
