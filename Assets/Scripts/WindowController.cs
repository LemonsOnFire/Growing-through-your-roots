using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowController : MonoBehaviour
{
    public enum WindowState {sad, interact, happy};
    public WindowState state;

    public int HitCounter = 0;
    public List<WindowColliders> colliders = new List<WindowColliders>();
    public SingleStoryManager ssmanager;

 

    // Update is called once per frame
    void Update()
    {
        if(HitCounter ==1)
        {
            state = WindowState.interact;

        }

        if(HitCounter == colliders.Count)
        {
            ssmanager.Switcher();
            state = WindowState.happy;
        }
    }
}
