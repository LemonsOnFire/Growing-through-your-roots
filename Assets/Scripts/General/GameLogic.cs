using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameLogic : MonoBehaviour {

    public static int levelLoaderIndex = 0;
    
    // Use this for initialization
    void Start () {
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(KeyCode.Escape) || Input.GetKeyDown(KeyCode.Tab)) {
			if(Time.timeScale == 0f) {
				Time.timeScale = 1f;
			} else {
				Time.timeScale = 0f;
			}
		}
    }

	public void ChangeLevel() {
		string currScene = SceneManager.GetActiveScene().name;
		Debug.Log("currScene: " + currScene);
		if(currScene.Equals("_MainMenu")) {
			LoadLevel("_LevelOne");
		} else if(currScene.Equals("_LevelOne")) {
			LoadLevel("_MainMenu");
		} else {
			LoadLevel("_MainMenu");
		} 
	}

    public static void LoadLevel(string levelName) {
        SceneManager.LoadScene(levelName);
    }

    public void ExitToMainMenu() {
        Time.timeScale = 1f;
        LoadLevel("_MainMenu");
    }

    public void RestartLevel() {
        Time.timeScale = 1f;
        LoadLevel(SceneManager.GetActiveScene().name);
    }
}
