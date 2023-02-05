using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleStoryManager : MonoBehaviour
{
    public int counter = 1;
    public List<GameObject> ActionObjects= new List<GameObject>();

    public void OnTriggerEnter(Collider other)
    {
        // start processes
    }

    public void Switcher()

    {
        ActionObjects[0].SetActive(false);
        ActionObjects[1].SetActive(true);
    }
}
