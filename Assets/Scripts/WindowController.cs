using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowController : MonoBehaviour
{
    public enum WindowState {sad, interact, happy};
    public WindowState state;

    public int HitCounter = 0;
    public List<WindowColliders> colliders = new List<WindowColliders>();


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(HitCounter ==1)
        {
            state = WindowState.interact;

        }

        if(HitCounter == colliders.Count)
        {
            // hit all the colliders
            state = WindowState.happy;
        }
    }
}
