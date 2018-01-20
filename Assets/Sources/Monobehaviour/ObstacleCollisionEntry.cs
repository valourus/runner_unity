using Entitas.Unity;
using UnityEngine;

namespace Sources.Monobehaviour {
    public class ObstacleCollisionEntry : MonoBehaviour {
        public string Target;

        void OnTriggerStay(Collider other)
        {           
            if(other.gameObject.CompareTag("Obstacle")) {
                Contexts.sharedInstance.input.CreateEntity().AddObstacleCollision(gameObject, other.gameObject);
            }
            
        }
    }
}
