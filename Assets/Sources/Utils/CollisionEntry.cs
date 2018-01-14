using System.Runtime.Remoting.Contexts;
using Entitas.Unity;
using UnityEngine;

namespace Sources.Utils {
    public class CollisionEntry : MonoBehaviour {
        public string Target;

        private void OnCollisionEnter(Collision other) {
            var selfLink = gameObject.GetEntityLink();
            var otherLink = other.gameObject.GetEntityLink();
            if(otherLink == null) return;
            Contexts.sharedInstance.input.CreateEntity().AddCollision(selfLink.gameObject, otherLink.gameObject);
        }
    }
}
