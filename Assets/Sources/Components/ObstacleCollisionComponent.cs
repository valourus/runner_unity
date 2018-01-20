using Entitas;
using UnityEngine;

namespace Sources.Components {
    [Input]
    public class ObstacleCollisionComponent : IComponent {
        public GameObject self;
        public GameObject other;
    }
}