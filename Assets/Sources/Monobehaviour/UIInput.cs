using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIInput : MonoBehaviour {

    public void onClickStartBtn() {
        Contexts.sharedInstance.input.CreateEntity().isOnStartClick = true;
    }
}
