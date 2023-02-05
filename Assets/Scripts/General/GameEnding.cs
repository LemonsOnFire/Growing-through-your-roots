using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameEnding : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ShowCredits() {
        string[] credits = new string[] { "Bianca", "Thanh-Mai", "Leonard", "Matt", "James", "Chris Draheim" };
        GetComponent<GameInfo>().ShowInfo(credits, (Screen.width / 2) - 40, (Screen.height / 5) + 100, 20);
    }

    private void LoadScene(string scene) {
        GameLogic.LoadLevel(scene);
    }

    void OnGUI() {

        float boxX = (Screen.width / 2) - 400;
        float boxY = (Screen.height / 5);
        float buttonX = (Screen.width / 2) - 90;
        float buttonY = boxY + 100;

        // GUI.Box(new Rect(boxX, boxY, 800, 350), "");
        GUI.Label(new Rect(buttonX + 20, boxY + 50, 200, 30), "Thanks for playing!");

        // ShowCredits();
        GetComponent<CreditsInfo>().ShowCredits();

        if (GUI.Button(new Rect(buttonX - 120, buttonY + 150, 200, 30), "Restart")) {
            LoadScene("_MainMenu");
        }

        if (GUI.Button(new Rect(buttonX + 120, buttonY + 150, 200, 30), "Exit")) {
            Application.Quit();
        }
    }
}
