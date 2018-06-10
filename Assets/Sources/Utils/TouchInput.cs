using System.Runtime.Remoting.Contexts;
using UnityEngine;
using Lean.Touch;

namespace Sources.Utils {
    public class TouchInput : MonoBehaviour {
        
        public void onSwipeUp(LeanFinger finger) {
            if(!RootSystem.cfg.isPaused)
                Contexts.sharedInstance.input.CreateEntity().isSwipeUp = true;
        }

        public void onSwipeDown(LeanFinger finger) {
            Debug.Log("swipe down");
            if(!RootSystem.cfg.isPaused)
                Contexts.sharedInstance.input.CreateEntity().isSwipDown = true;
        }
        
        public void onDoubleTap(LeanFinger finger) {
            if(RootSystem.cfg.isPaused && Contexts.sharedInstance.game.isDead)
                Contexts.sharedInstance.input.CreateEntity().AddRestartGame(RestartFase.FASE1);
        }
    }
}