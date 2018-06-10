using UnityEngine;

public class FadeOut : MonoBehaviour {
    
    private CanvasGroup group { get; set; }

    private void Awake() {
        group = GetComponent<CanvasGroup>();
    }
    
    private void Update() {
        group.alpha = Mathf.Lerp(group.alpha, 0, Time.deltaTime * 7);
        if(group.alpha < 0.001) 
            Destroy(this);
    }
}
