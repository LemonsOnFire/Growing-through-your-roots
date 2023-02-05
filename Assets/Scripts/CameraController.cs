using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Search;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class CameraController : MonoBehaviour
{
    public float startZoomLevel = 5.0f;
    public float endZoomLevel = 4.0f;
    public float distanceToStartZoom = 1.0f;
    private bool isZooming = false;
    public float zoomSpeed = 1.0f;

    private bool isOpeningScroll = true;
    public float scrollSpeed = 1.0f;

    public GameObject player;
    public GameObject holdMovementTop;
    public GameObject holdMovementBottom;
    private bool isMovingToPlayer = false;

    // Start is called before the first frame update
    void Start()
    {
        Application.targetFrameRate = 60;
        GetComponentInParent<Camera>().orthographicSize = startZoomLevel;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (isZooming)
        {
            var zoomStep = zoomSpeed * Time.deltaTime;// calculate amount to zoom
            var cam = GetComponentInParent<Camera>();

            cam.orthographicSize = Vector2.MoveTowards( new Vector2( cam.orthographicSize, 0.0f ), new Vector2(endZoomLevel, 0.0f) , zoomStep).x;

            if (cam.orthographicSize == endZoomLevel)
            {
                isZooming = false;
            }
        }

        if (isOpeningScroll)
        {
            var step = scrollSpeed * Time.deltaTime; // calculate distance to move
            var moveToPosition = Vector3.MoveTowards(transform.position, player.transform.position, step);
            transform.position = new Vector3(transform.position.x, moveToPosition.y, transform.position.z);
            if(transform.position.y - player.transform.position.y < distanceToStartZoom)
            {
                isZooming = true;
            }

            if (transform.position.y == player.transform.position.y && !isZooming)
            {
                isOpeningScroll = false;
            }

        }
        else
        {
            if (player.transform.position.y > holdMovementTop.transform.position.y 
                || player.transform.position.y < holdMovementBottom.transform.position.y)
            {
                MoveCameraToPlayer();
            }
        }

        if (isMovingToPlayer)
        {
            MoveCameraToPlayer();
        }
    }

    private void MoveCameraToPlayer()
    {
        var step = scrollSpeed * Time.deltaTime; // calculate distance to move
        var moveToPosition = Vector3.MoveTowards(transform.position, player.transform.position, step);
        transform.position = new Vector3(transform.position.x, moveToPosition.y, transform.position.z);

        if (transform.position.y == player.transform.position.y)
        {
            isMovingToPlayer = false;
        }
    }
}
