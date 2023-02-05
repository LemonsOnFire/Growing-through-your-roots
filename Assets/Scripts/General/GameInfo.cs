using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo : MonoBehaviour
{
    
    Rect offsets = new Rect(20f, 20f, 20f, 20f);
    public bool showInfo = true;

    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static string[] GetTopLeftInfo() {
        return new string[] { "Developers: Add screen info strings here for auto-positioning", "Test TL" };
    }

    private string[] GetTopRightInfo() {
        return new string[] { "Test TR" };
    }

    private string[] GetBottomLeftInfo() {
        return new string[] { "Test BL" , EditorCam.GetEditorCamControlsInfo() };
    }

    private string[] GetBottomRightInfo() {
        return new string[] { "Test BR" };
    }

    private void ShowInfo(string[] info, float xPos, float yPos, int yAdvance) {

        int ind = 0;

        foreach(string s in info) {

            GUIStyle style = new GUIStyle();
            style.normal.textColor = Color.red;

            GUI.Label(new Rect(xPos, yPos + (ind * yAdvance), 200, 20), s, style);
            ind++;
        }
    }

    private void OnGUI() {

        if(showInfo) {
            ShowInfo(GetTopLeftInfo(), offsets.x, offsets.y, 20);
            ShowInfo(GetTopRightInfo(), (Screen.width - offsets.width) - 200, offsets.y, 20);
            ShowInfo(GetBottomLeftInfo(), offsets.x, Screen.height - offsets.y, -20);
            ShowInfo(GetBottomRightInfo(), (Screen.width - offsets.width) - 200, Screen.height - offsets.y, -20);
        }
    }
}
