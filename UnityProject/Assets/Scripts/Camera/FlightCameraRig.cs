using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlightCameraRig : MonoBehaviour
{

    public float speed = 10;

    private float pitch = 0;
    private float yaw = 0;

    public float mouseSensitivityX = 1;
    public float mouseSensitivityY = 1;

    // Start is called before the first frame update
    void Start()
    {
        //Cursor.lockState
    }

    // Update is called once per frame
    void Update()
    {

        // Calc Position

        float v = Input.GetAxis("Vertical"); // Foward / Back
        float h = Input.GetAxis("Horizontal"); // Left / Right (strafe)

        //transform.position += transform.forward * v * Time.deltaTime; // speed? 1 meter / second
        //transform.position += transform.right * h * Time.deltaTime; // speed? 1 meter / second

        Vector3 dir = transform.forward * v + transform.right * h;
        if (dir.magnitude > 1) dir.Normalize();
        transform.position += dir * Time.deltaTime * speed;

        // Calc Rotation

        float mx = Input.GetAxis("Mouse X"); // Yaw (Y Axis)
        float my = Input.GetAxis("Mouse Y"); // Pitch (X Axis)

        yaw += mx * mouseSensitivityX;
        pitch += my * mouseSensitivityY;

        pitch = Mathf.Clamp(pitch, -89, 89);

        transform.rotation = Quaternion.Euler(pitch, yaw, 0);

        
    }
}
