using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreditsInfo : MonoBehaviour
{
    public enum ROLES { Programmers, Artists, Music, Writers };

    public static string[] programmers = new string[] { "Leonard", "Matt", "James Witten", "Chris Draheim" };
    public static string[] artists = new string[] { "Bianca", "Thanh-Mai" };
    public static string[] music = new string[] { };
    public static string[] writers = new string[] { "Zack" };

    // private static ROLES[] roles = new ROLES[] { ROLES.Programmers, ROLES.Artists, ROLES.Music };
    // public static string[] roles = new string[] { "Programmers", "Artists", "Music" };
    public static int START_INDEX = 0;

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
        }

        return new string[] { };
    }

    public void ShowCredits() {

        int size = System.Enum.GetNames(typeof(ROLES)).Length;
        int yBase = (Screen.height / 5) + 100;

        for (int i = START_INDEX; i <= size; i++) {
            int ind = i + START_INDEX;
            if(ind >= size) {
                ind -= size;
            }

            ROLES role = (ROLES)System.Enum.GetValues(typeof(ROLES)).GetValue(ind);
            string[] credits = GetTeamMembersForRole(role);
            GUI.Label(new Rect((Screen.width / 2) - 100, yBase, 40, 20), role.ToString() + ":");
            GetComponent<GameInfo>().ShowInfo(credits, (Screen.width / 2) + 100, yBase, 20);
            yBase += (credits.Length * 20);
        }
        
    }
}
