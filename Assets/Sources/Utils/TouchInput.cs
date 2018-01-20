using System.Runtime.Remoting.Contexts;
using UnityEngine;
using Lean.Touch;

namespace Sources.Utils {
    public class TouchInput : MonoBehaviour {
        
        public void onSwipeUp(LeanFinger finger) {
            Debug.Log("swipe up");
        }

        public void onSwipeDown(LeanFinger finger) {
            Contexts.sharedInstance.input.CreateEntity().isSwipDown = true;
        }
        
        public void onDoubleTap(LeanFinger finger) {
            if(RootSystem.cfg.isPaused)
                Contexts.sharedInstance.input.CreateEntity().AddRestartGame(RestartFase.FASE1);
        }
    }
}