using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsInfo : MonoBehaviour
{
    public enum ROLES { Programmers, Artists, Music, Writers };

    public static string[] programmers = null;
    public static string[] artists = null;
    public static string[] music = null;
    public static string[] writers = null;
    public static int START_INDEX = 0;

    private void Awake() {
        programmers = ShiftArrayOrder(new string[] { "Leonard W", "Matt", "James", "Chris Draheim" });
        artists = ShiftArrayOrder(new string[] { "Bianca", "Thanh-Mai" });
        music = ShiftArrayOrder(new string[] { "Abe Underhill" });
        writers = ShiftArrayOrder(new string[] { "Zack" });
    }

    // Start is called before the first frame update
    void Start()
    {
        int size = System.Enum.GetNames(typeof(ROLES)).Length;
        START_INDEX = size;
        while(START_INDEX >= size) {
            START_INDEX = Mathf.RoundToInt(UnityEngine.Random.Range(0f, (float)size));
        }
}

    // Update is called once per frame
    void Update()
    {
        
    }

    private static string[] GetTeamMembersForRole(ROLES r) {

        switch(r) {
            case (ROLES.Artists): {
                    return artists;
                }
            case (ROLES.Programmers): {
                    return programmers;
                }
            case (ROLES.Music): {
                    return music;
                }
            case (ROLES.Writers): {
                    return writers;
                }
        }

        return new string[] { };
    }

    private static string[] ShiftArrayOrder(string[] arr) {

        int size = arr.Length;
        string[] ret = new string[size];
        int startInd = size;
        while (startInd >= size) {
            startInd = Mathf.RoundToInt(UnityEngine.Random.Range(0f, (float)size));
        }

        int ind = 0;
        for (int i = startInd; i < size; i++, ind++) {

            ret[ind] = arr[i];
        }
        for (int i = 0; i < startInd; i++, ind++) {

            ret[ind] = arr[i];
        }

        return ret;
    }

    public void ShowCredits() {

        int size = System.Enum.GetNames(typeof(ROLES)).Length;
        int yBase = (Screen.height / 10) + 60;

        for (int i = START_INDEX; i < size; i++) {

            ROLES role = (ROLES)System.Enum.GetValues(typeof(ROLES)).GetValue(i);
            string[] credits = GetTeamMembersForRole(role);
            GUI.Label(new Rect((Screen.width / 2) - 200, yBase, 150, 20), role.ToString() + ":");
            GetComponent<GameInfo>().ShowInfo(credits, (Screen.width / 2) + 100, yBase, 20);
            yBase += (credits.Length * 20) + 20;
        }

        for (int i = 0; i < START_INDEX; i++) {

            ROLES role = (ROLES)System.Enum.GetValues(typeof(ROLES)).GetValue(i);
            string[] credits = GetTeamMembersForRole(role);
            GUI.Label(new Rect((Screen.width / 2) - 200, yBase, 150, 20), role.ToString() + ":");
            GetComponent<GameInfo>().ShowInfo(credits, (Screen.width / 2) + 100, yBase, 20);
            yBase += (credits.Length * 20) + 20;
        }
    }
}
