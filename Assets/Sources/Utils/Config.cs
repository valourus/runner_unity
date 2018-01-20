using UnityEngine;


public sealed class Config : MonoBehaviour {
    public GameObject level;
    public GameObject xpBar;
    public GameObject player;
    public GameObject obstacles;
    public GameObject tree;
    public GameObject score;
    public GameObject cam;
    public GameObject mainmenu;
    public GameObject gamemenu;
    public float startSpeed;
    public bool isPaused;
    
    public void init() {
        Screen.orientation = ScreenOrientation.Portrait;
        Application.targetFrameRate = 60;
    }
}
