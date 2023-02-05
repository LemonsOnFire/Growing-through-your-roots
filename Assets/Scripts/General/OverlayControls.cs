using UnityEngine;

public class OverlayControls : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void PauseMenu() {
        float buttonX = (Screen.width / 2) - 90;
        float buttonY = (Screen.height / 5) + 100;
        GUIStyle style = new GUIStyle(GUI.skin.box);
        style.normal.background = GuiUtils.MakeTexture(2, 2, Color.black);

        GUI.Box(new Rect(buttonX - 10, buttonY - 10, 220, 130), "", style);
        if (GUI.Button(new Rect(buttonX, buttonY, 200, 30), "Resume")) {
            Time.timeScale = 1f;
        }
        if (GUI.Button(new Rect(buttonX, buttonY + 40, 200, 30), "Return to Menu")) {
            GetComponent<GameLogic>().ExitToMainMenu();
        }
        if (GUI.Button(new Rect(buttonX, buttonY + 80, 200, 30), "Quit Game")) {
            Application.Quit();
        }
    }

    private void GameOverMenu() {
        float buttonX = (Screen.width / 2) - 90;
        float buttonY = (Screen.height / 5) + 100;
        GUIStyle style = new GUIStyle(GUI.skin.box);
        style.normal.background = GuiUtils.MakeTexture(2, 2, Color.black);

        GUI.Box(new Rect(buttonX - 10, buttonY - 10, 220, 130), "", style);
        if (GUI.Button(new Rect(buttonX, buttonY, 200, 30), "Try Again")) {
            GetComponent<GameLogic>().RestartLevel();
        }
        if (GUI.Button(new Rect(buttonX, buttonY + 40, 200, 30), "Return to Menu")) {
            GetComponent<GameLogic>().ExitToMainMenu();
        }
        if (GUI.Button(new Rect(buttonX, buttonY + 80, 200, 30), "Quit Game")) {
            Application.Quit();
        }
    }

    private void GameOverScreen() {
        
        Rect posRect = new Rect(Camera.main.pixelRect.x, 0f, Camera.main.pixelRect.width, Camera.main.pixelRect.height);

        GUIStyle style = new GUIStyle(GUI.skin.box);
        Color c = Color.black;
        c.a = .6f;
        style.normal.background = GuiUtils.MakeTexture(2, 2, c);

        int xOffset = posRect.x == 0 ? 0 : 5;
        int yOffset = posRect.y == 0 ? 0 : 5;
        int p1xOffset = 12;
        int p1yOffset = 100;
        GUI.Box(new Rect(posRect.x, posRect.y, posRect.width, posRect.height), "", style);

        style = new GUIStyle();
        style.normal.textColor = Color.red;
        GUI.Label(new Rect(posRect.x + (posRect.width / 2) - 40 + p1xOffset, posRect.y + (posRect.height / 2) - p1yOffset - 20, 20, 20), "Game Over", style);
    }

    void OnGUI() {

        if (GetComponent<GameLogic>().GAME_OVER) {
            GameOverScreen();
        }

        if (Time.timeScale == 0f) {
            PauseMenu();
        }
        if (GetComponent<GameLogic>().GAME_OVER) {
            GameOverMenu();
        }
    }
}
