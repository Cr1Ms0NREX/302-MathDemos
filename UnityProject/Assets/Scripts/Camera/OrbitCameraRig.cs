using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitCameraRig : MonoBehaviour
{
    public Transform thingToLookAt;
    private float pitch = 0;
    private float yaw = 0;
    private float disToTarget = 10;
    
    public float mouseSensitivityX = 1;
    public float mouseSensitivityY = 1;
    public float scrollSensitivity = 1;

    private Camera cam;
    // Start is called before the first frame update
    void Start()
    {
        cam = GetComponentInChildren<Camera>();
    }

    // Update is called once per frame
    void LateUpdate()
    {

        // Rotation

        float mx = Input.GetAxis("Mouse X"); // Yaw (Y Axis)
        float my = Input.GetAxis("Mouse Y");

        yaw += mx * mouseSensitivityX;
        pitch += my * mouseSensitivityY;

        pitch = Mathf.Clamp(pitch, -89, 89);

        transform.rotation = Quaternion.Euler(pitch, yaw, 0);

        // Dolly (Zoom)

        Vector2 scrollAmount = Input.mouseScrollDelta;
        disToTarget += scrollAmount.y * scrollSensitivity;
        disToTarget = Mathf.Clamp(disToTarget, 0, 5);


        //float z = AnimMath.Ease(cam.transform.localPosition.z, -disToTarget, .01f);
        cam.transform.localPosition = new Vector3(0, 0, -disToTarget);
        // Position

        if (thingToLookAt == null) return;
        //transform.position = thingToLookAt.position;

        // Ease
        transform.position = AnimMath.Ease(transform.position, thingToLookAt.position, .001f);
    }
}
