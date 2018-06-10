using UnityEngine;

public class FadeOut : MonoBehaviour {
    
    private CanvasGroup group { get; set; }

    private void Awake() {
        group = GetComponent<CanvasGroup>();
        FadeIn other = GetComponent<FadeIn>();
        if (other != null)
            Destroy(other);
    }
    
    private void Update() {
        group.alpha = Mathf.Lerp(group.alpha, 0, Time.deltaTime * 7);
        if(group.alpha < 0.0001) 
            Destroy(this);
    }
}
