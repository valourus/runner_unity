using Entitas.Unity;
using UnityEngine;

namespace Sources.Monobehaviour {
    public class ObstacleCollisionEntry : MonoBehaviour {
        public string Target;

        private void OnTriggerEnter(Collider other) {
            if(other.gameObject.CompareTag("Obstacle")) {
                Contexts.sharedInstance.input.CreateEntity().AddObstacleCollision(gameObject, other.gameObject);
            }
            
        }
        
        void OnTriggerStay(Collider other)
        {           
            if(other.gameObject.CompareTag("Obstacle")) {
                Contexts.sharedInstance.input.CreateEntity().AddObstacleCollision(gameObject, other.gameObject);
            }
            
        }
    }
}
