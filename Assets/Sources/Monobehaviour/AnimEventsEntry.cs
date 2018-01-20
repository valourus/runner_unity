using System.Collections;
using System.Collections.Generic;
using Sources.Utils;
using UnityEngine;

public class AnimEventsEntry : MonoBehaviour {
    public void onAnimationFinished() {
        Contexts.sharedInstance.input.CreateEntity().AddRestartGame(RestartFase.FASE2);
    }
}
