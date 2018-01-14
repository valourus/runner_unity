using Entitas;
using Entitas.CodeGeneration.Attributes;

namespace Sources.Components {
    [Game]
    [Unique]
    public class ScoreComponent : IComponent {
        public int highscore;
        public int currScore;
    }
}