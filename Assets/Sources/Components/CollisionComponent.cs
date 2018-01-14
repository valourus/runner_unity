using Entitas;
using UnityEngine;

namespace Sources.Components {
    [Input]
    public class CollisionComponent : IComponent {
        public GameObject self;
        public GameObject other;
    }
}