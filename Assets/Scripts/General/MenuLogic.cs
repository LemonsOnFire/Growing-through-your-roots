using UnityEngine;
using System;

public class MenuLogic : MonoBehaviour {

    public enum MenuForm { MAIN_MENU, CREDITS };

    public static readonly string GAME_TITLE = "Growing Through Your Roots";
    public static readonly string[] GAME_TITLE_ARR = new string[] { GAME_TITLE, "--preserve-root", "Rooting for the Little Guy", "[TITLE OF GAME]" };
    public static readonly float[] GAME_TITLE_OFFSET_ARR = new float[] { 17f, 50f, 25f, 42f  };
    public static int TITLE_INDEX = 0;

    private MenuForm currentMenu = MenuForm.MAIN_MENU;

    // Use this for initialization
    void Start () {
        TITLE_INDEX = Mathf.RoundToInt(UnityEngine.Random.Range(0f, ((float)GAME_TITLE_ARR.Length)));
    }
	
	// Update is called once per frame
	void Update () {
    }

    private void ShowCredits() {
        string[] credits = new string[] { "Bianca", "Thanh-Mai", "Leonard", "Matt", "James", "Chris Draheim" };
        GetComponent<GameInfo>().ShowInfo(credits, (Screen.width / 2) - 40, (Screen.height / 5) + 100, 20);
    }

    private string GetMenuTitle() {

        if (currentMenu == MenuForm.CREDITS) {
            return "Credits";
        }
        
        try {
            return GAME_TITLE_ARR[TITLE_INDEX];
        } catch(Exception e) { }

        return GAME_TITLE_ARR[0];
    }

    private void LoadScene(string scene) {
        GameLogic.LoadLevel(scene);
    }

    void OnGUI() {

		float boxX = (Screen.width/2) - 400;
		float boxY = (Screen.height/5);
        float buttonX = (Screen.width / 2) - 90;
        float buttonY = boxY + 100;

        GUI.Box(new Rect(boxX, boxY, 800, 350), "");
        GUI.Label(new Rect(buttonX + GAME_TITLE_OFFSET_ARR[TITLE_INDEX], boxY + 50, 200, 30), GetMenuTitle());

        if (currentMenu != MenuForm.MAIN_MENU) {
            if (GUI.Button(new Rect(buttonX, buttonY + 150, 200, 30), "Return")) {
                currentMenu = MenuForm.MAIN_MENU;
            }
        }

        if (currentMenu == MenuForm.CREDITS) {
            ShowCredits();
			return;
		}
        
		if(GUI.Button(new Rect(buttonX, buttonY, 200, 30), "Start")) {
            LoadScene("_LevelOne");
        }
		if(GUI.Button(new Rect(buttonX, buttonY + 50, 200, 30), "Credits")) {
            currentMenu = MenuForm.CREDITS;
        }

        if (GUI.Button(new Rect(buttonX, buttonY + 150, 200, 30), "Exit")) {
			Application.Quit();
        }
    }
}
