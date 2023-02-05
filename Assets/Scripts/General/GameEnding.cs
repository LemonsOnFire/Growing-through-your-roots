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

    private void LoadScene(string scene) {
        GameLogic.LoadLevel(scene);
    }

    void OnGUI() {
        
        float offsetX = (Screen.width / 2) - 90;
        float offsetY = Screen.height - 100;
        
        GUI.Label(new Rect(offsetX + 20, (Screen.height / 10), 200, 30), "Thanks for playing!");
        
        GetComponent<CreditsInfo>().ShowCredits();

        if (GUI.Button(new Rect(offsetX - 120, offsetY, 200, 30), "Restart")) {
            LoadScene("_MainMenu");
        }

        if (GUI.Button(new Rect(offsetX + 120, offsetY, 200, 30), "Exit")) {
            Application.Quit();
        }
    }
}
