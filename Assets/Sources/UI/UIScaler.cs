using UnityEngine;

namespace Sources.UI {
    public class UIScaler : MonoBehaviour {
        public float width;
        public float height;

        void Start() {
            GetComponent<RectTransform>().sizeDelta = new Vector2(
                Screen.width / 100 * width,
                Screen.height / 100 * height
            );
        }
    }
}