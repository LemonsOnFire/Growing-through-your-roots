using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EditorCam : MonoBehaviour {
    
    public static KeyCode CONFIRM_KEY = KeyCode.Mouse0;
    public static KeyCode PAN_KEY = KeyCode.LeftAlt;
    public static KeyCode ROTATE_KEY = KeyCode.Mouse1;
    public static KeyCode CAMERA_KEY = KeyCode.Mouse2;
    public static string CAMERA_INPUT_X_AXIS = "Mouse X";
    public static string CAMERA_INPUT_Y_AXIS = "Mouse Y";

    float cameraSpeed = 30f;
    float turnSpeed = 4f;
    float zoomSpeed = 200f;
    float orthographicZoomSpeed = 1f;
    public bool freeRotation = true;

    // Use this for initialization
    void Start() {
        if(!GetComponent<Rigidbody>()) {
            gameObject.AddComponent<Rigidbody>();
            GetComponent<Rigidbody>().useGravity = false;
        }

        Camera.main.transform.position = GameVariables.DEFAULT_CAMERA_POSITION;
    }

    // Update is called once per frame
    void Update() {
        float hInput = -Input.GetAxis(CAMERA_INPUT_X_AXIS);
        float vInput = -Input.GetAxis(CAMERA_INPUT_Y_AXIS);

        if (Input.GetKey(CAMERA_KEY)) {
            // Pan camera
            Camera.main.GetComponent<Rigidbody>().velocity = new Vector3(hInput * cameraSpeed, vInput * cameraSpeed, 0f);
        } else if (freeRotation && Input.GetKey(ROTATE_KEY)) {
            // Rotate camera
            Vector3 pos = Camera.main.GetComponent<Rigidbody>().rotation.eulerAngles;
            Vector3 pos2 = pos;
            pos.x += (Mathf.Abs(vInput) > .2f) ? turnSpeed * Mathf.Sign(vInput) : 0f;
            pos.y -= (Mathf.Abs(hInput) > .2f) ? turnSpeed * Mathf.Sign(hInput) : 0f;
            Camera.main.GetComponent<Rigidbody>().rotation = Quaternion.Slerp(Quaternion.Euler(pos2), Quaternion.Euler(pos), turnSpeed);
        } else if (Input.GetAxis("Mouse ScrollWheel") != 0) {
            // Zoom camera

            if(Camera.main.GetComponent<Camera>().orthographic) {

                Camera.main.orthographicSize -= Input.GetAxis("Mouse ScrollWheel") * orthographicZoomSpeed;
            } else {
                Camera.main.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * Input.GetAxis("Mouse ScrollWheel") * zoomSpeed;

            }

        } else if(Input.GetKey(PAN_KEY)) {
            if (Input.GetAxis("Horizontal") != 0 || Input.GetAxis("Vertical") != 0) {
                // Pan camera
                Camera.main.GetComponent<Rigidbody>().velocity = new Vector3(Input.GetAxis("Horizontal") * cameraSpeed, Input.GetAxis("Vertical") * cameraSpeed);
            }
        } else {
            // Stop camera movement
            Camera.main.GetComponent<Rigidbody>().velocity = new Vector3(0f, 0f, 0f);
        }
    }
}
