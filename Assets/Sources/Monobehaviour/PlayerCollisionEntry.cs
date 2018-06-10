using Entitas.Unity;
using UnityEngine;

namespace Sources.Monobehaviour {
    public class PlayerCollisionEntry : MonoBehaviour {
        private void OnTriggerEnter(Collider other) {
            Contexts.sharedInstance.input.CreateEntity().AddPlayerCollision(gameObject, other.gameObject);
        }

        private void OnCollisionEnter(Collision other) {
            if(other.gameObject.CompareTag("Ground")) {
                GameEntity e = gameObject.GetEntityLink().entity as GameEntity;
                e.AddJumpCoolDown(5, Time.realtimeSinceStartup);
                Contexts.sharedInstance.game.isJumping = false;
            }
        }
    }
}