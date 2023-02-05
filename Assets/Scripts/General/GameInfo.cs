using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameInfo : MonoBehaviour
{
    
    Rect offsets = new Rect(20f, 20f, 20f, 20f);
    public bool showInfo = true;
    [Tooltip("Corners: 0)TL 1)TR 2)BL 3)BR")]
    public bool[] showCorner = new bool[] { true, true, true, true };
    private int[] startIndex = new int[System.Enum.GetNames(typeof(CreditsInfo.ROLES)).Length];


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

    public void ShowInfo(string[] info, float xPos, float yPos, int yAdvance) {
        ShowInfo(info, xPos, yPos, yAdvance, Color.white);
    }

    public void ShowInfo(string[] info, float xPos, float yPos, int yAdvance, Color c) {

        int size = info.Length;
        int ind = size;
        while (ind >= size) {
            ind = Mathf.RoundToInt(UnityEngine.Random.Range(0f, (float)size));
        }

        int yOffset = 0;
        

        foreach(string s in info) {

            GUIStyle style = new GUIStyle();
            style.normal.textColor = c;
            
            GUI.Label(new Rect(xPos, yPos + (yOffset * yAdvance), 200, 20), s, style);
            yOffset++;
        }
    }

    private void OnGUI() {

        if(showInfo) {
            if (showCorner[0]) ShowInfo(GetTopLeftInfo(), offsets.x, offsets.y, 20, Color.red);
            if (showCorner[1]) ShowInfo(GetTopRightInfo(), (Screen.width - offsets.width) - 200, offsets.y, 20, Color.red);
            if (showCorner[2]) ShowInfo(GetBottomLeftInfo(), offsets.x, Screen.height - offsets.y, -20, Color.red);
            if (showCorner[3]) ShowInfo(GetBottomRightInfo(), (Screen.width - offsets.width) - 200, Screen.height - offsets.y, -20, Color.red);
        }
    }
}
