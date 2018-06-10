using UnityEngine;


public sealed class Config : MonoBehaviour {
    public GameObject startBtn;
    public GameObject level;
    public GameObject xpBar;
    public GameObject player;
    public GameObject obstacles;
    public GameObject tree1;
    public GameObject tree2;
    public GameObject stone1;
    public GameObject stone2;
    public GameObject score;
    public GameObject cam;
    public GameObject mainmenu;
    public GameObject gamemenu;
    public GameObject gameOverMenu;
    public GameObject endScore;
    public GameObject jumpCover;
    public GameObject jumpIcon;
    public GameObject slowMotionIcon;
    public GameObject slowMotionCover;
    public float startSpeed;
    public bool isPaused;
    
    public void init() {
        Screen.orientation = ScreenOrientation.Portrait;
        Application.targetFrameRate = 60;
    }
}
