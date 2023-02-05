using UnityEngine;
using System;

public class MenuLogic : MonoBehaviour {

    public enum MenuForm { MAIN_MENU, CREDITS };

    public static readonly string GAME_TITLE = "Growing Through Your Roots";
    // public static readonly string[] GAME_TITLE_ARR = new string[] { GAME_TITLE, "--preserve-root", "Rooting for the Little Guy", "[TITLE OF GAME]" };
   

    private MenuForm currentMenu = MenuForm.MAIN_MENU;

    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
    }

    private string GetMenuTitle() {

        if (currentMenu == MenuForm.CREDITS) {
            return "Credits";
        }

        return GAME_TITLE;
    }

    private void LoadScene(string scene) {
        GameLogic.LoadLevel(scene);
    }

    void OnGUI() {

		float boxX = (Screen.width/2) - 400;
		float boxY = (Screen.height/5);
        float buttonX = (Screen.width / 2) - 90;
        float buttonY = boxY + 100;

        GUI.Label(new Rect(buttonX + 17f, (currentMenu == MenuForm.MAIN_MENU) ?  boxY + 50 : (Screen.height / 10), 200, 30), GetMenuTitle());

        if (currentMenu != MenuForm.MAIN_MENU) {
            if (GUI.Button(new Rect(buttonX, buttonY + 150, 200, 30), "Return")) {
                currentMenu = MenuForm.MAIN_MENU;
            }
        }

        if (currentMenu == MenuForm.CREDITS) {
            GetComponent<CreditsInfo>().ShowCredits();
            return;
		}
        
		if(GUI.Button(new Rect(buttonX, buttonY, 200, 30), "Start")) {
            LoadScene("_LevelOne");
        }
		if(GUI.Button(new Rect(buttonX, buttonY + 50, 200, 30), "Credits")) {
            currentMenu = MenuForm.CREDITS;
        }
        if (GUI.Button(new Rect(buttonX + 300, buttonY + 50, 100, 30), "Don't")) {
            LoadScene("_GameEnding");
        }

        if (GUI.Button(new Rect(buttonX, buttonY + 150, 200, 30), "Exit")) {
			Application.Quit();
        }
    }
}
