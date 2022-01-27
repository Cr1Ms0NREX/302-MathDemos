using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookAtCameraRig : MonoBehaviour
{

    public Transform target;

    public float desiredDistance = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        Vector3 vToTarget = target.position - transform.position;

        // Position of the Camera
        Vector3 targetPosition = -vToTarget;
        targetPosition.Normalize();
        targetPosition *= desiredDistance;

        targetPosition += target.position;

        transform.position = AnimMath.Ease(transform.position, targetPosition, .01f);

        // turning to look at target
        transform.rotation = Quaternion.LookRotation(vToTarget, Vector3.up); // new Vector3(0, 1, 0)
    }
}
