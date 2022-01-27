using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class OrbitDemoMoon : MonoBehaviour
{
    public Transform orbitCenterMoon;

    public float radius = 2;

    public int pathResolution = 32;

    private LineRenderer path;

    // Start is called before the first frame update
    void Start()
    {
        path = GetComponent<LineRenderer>();
        path.loop = true;
        path.useWorldSpace = true;
        UpdateOrbitMoonPath();
    }

    // Update is called once per frame
    void Update()
    {
        if (!orbitCenterMoon) return;
        float x = radius * Mathf.Cos(12 * Time.time);
        float z = radius * Mathf.Sin(12 * Time.time);

        transform.position = new Vector3(x, 0, z) + orbitCenterMoon.position;
        if (orbitCenterMoon.hasChanged) UpdateOrbitMoonPath();
    }
    void UpdateOrbitMoonPath()
    {

        if (!orbitCenterMoon) return;

        float radsPerCircle = 2 * Mathf.PI;


        Vector3[] pts = new Vector3[32];

        for (int i = 0; i < pts.Length; i++)
        {
            float x = radius * Mathf.Cos(i * radsPerCircle / pathResolution);
            float z = radius * Mathf.Sin(i * radsPerCircle / pathResolution);

            Vector3 pt = new Vector3(x, 0, z) + orbitCenterMoon.position;
            pts[i] = pt;
        }
        path.positionCount = pathResolution;
        path.SetPositions(pts);
    }


}