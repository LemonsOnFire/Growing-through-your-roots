using System.Collections;
using System.Collections.Generic;
using UnityEditor.Search;
using UnityEngine;

public class levelStartCameraScroll : MonoBehaviour
{
    public GameObject player;

    public GameObject startCamera;
    public Vector3 holdMovementTop;
    public Vector3 holdMovementBottom;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (player.transform.position.y > holdMovementTop.y)
        {
            MoveCameraUp();
        }
        else if (player.transform.position.y < holdMovementBottom.y)
        {
            MoveCameraDown();
        }
    }

    private void MoveCamera()
    {

    }

    private void MoveCameraUp()
    {
        MoveCamera();
    }

    private void MoveCameraDown()
    {
        MoveCamera();
    }
}
