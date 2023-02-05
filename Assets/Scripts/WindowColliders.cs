using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class WindowColliders : MonoBehaviour
{
    public WindowController controller;
    public GameObject leaf;
    public Sprite bulb;
    public void OnTriggerEnter2D(Collider2D collision)
    {
        Quaternion rot = Random.rotation;
        controller.HitCounter++;
       var LeafObj =  Instantiate(leaf, collision.transform.position, rot);


    }
    private void Start()
    {
        controller = GetComponentInParent<WindowController>();

    }
}
