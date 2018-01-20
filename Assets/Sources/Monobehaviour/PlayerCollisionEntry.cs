using Entitas.Unity;
using UnityEngine;

namespace Sources.Monobehaviour {
    public class PlayerCollisionEntry : MonoBehaviour {
        private void OnTriggerEnter(Collider other) {
            Contexts.sharedInstance.input.CreateEntity().AddPlayerCollision(gameObject, other.gameObject);
        }
    }
}