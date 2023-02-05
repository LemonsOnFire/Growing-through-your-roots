using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameObjUtils
{

    public static bool HasActiveEditorCam() {
        return CountActive(GameObject.FindObjectsOfType<EditorCam>()) > 0;
    }

    private static int CountActive(MonoBehaviour[] mbArr) {

        int count = 0;
        foreach (MonoBehaviour mb in mbArr) {
            if (mb.isActiveAndEnabled) {
                count++;
            }
        }

        return count;
    }

    private static int CountInactive(MonoBehaviour[] mbArr) {

        return mbArr.Length - CountActive(mbArr);
    }

    public static string GetActiveString(MonoBehaviour[] mbArr) {

        int inactive = CountInactive(mbArr);

        return "" + CountActive(mbArr) + (inactive > 0 ? " (" + inactive + ")" : "");
    }
}
