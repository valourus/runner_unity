using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FadeIn : MonoBehaviour {
    
    private CanvasGroup group { get; set; }

    private void Awake() {
        group = GetComponent<CanvasGroup>();
    }
    
    private void Update() {
        group.alpha = Mathf.Lerp(group.alpha, 1, Time.deltaTime * 7);
        if(group.alpha < 0.01) 
            Destroy(this);
    }
}
