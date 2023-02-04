using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WindowColliders : MonoBehaviour
{
    public WindowController controller;

    public void OnTriggerEnter2D(Collider2D collision)
    {
        controller.HitCounter++;
    }
    private void Start()
    {
        controller = GetComponentInParent<WindowController>();

    }
}
