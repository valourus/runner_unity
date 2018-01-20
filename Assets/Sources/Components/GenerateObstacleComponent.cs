using System.Collections.Generic;
using Entitas;
using Sources.Utils;

namespace Sources.Components {
    [Input]
    public class GenerateObstacleComponent :IComponent {
        public GeneratePlace place;
    }
}