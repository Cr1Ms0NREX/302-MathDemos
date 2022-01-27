using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class OrbitDemo : MonoBehaviour
{

    public float timeMultiplier = 1;
    public float timeOffset = 0;

    public Transform orbitCenter;

    public float radius = 10;

    public int pathResolution = 32;

    private LineRenderer path;


    // Start is called before the first frame update
    void Start()
    {
        path = GetComponent<LineRenderer>();
        path.loop = true;
        path.useWorldSpace = true;
        UpdateOrbitPath();
    }

    // Update is called once per frame
    void Update()
    {
        
        if (!orbitCenter) return;
        {
            if (radius < 11)
            {
                float x = radius * Mathf.Cos(Time.time * timeMultiplier + timeOffset);
                float z = radius * Mathf.Sin(Time.time * timeMultiplier + timeOffset);
                transform.position = new Vector3(x, 0, z) + orbitCenter.position;
            }
            if (radius >= 11 && radius < 16)
            {
                float x = radius * Mathf.Cos(2 * Time.time - 100);
                float z = radius * Mathf.Sin(2 * Time.time - 100);
                transform.position = new Vector3(x, 0, z) + orbitCenter.position;
            }
            if (radius >= 16 && radius < 21)
            {
                float x = radius * Mathf.Cos(3 * Time.time - 600);
                float z = radius * Mathf.Sin(3 * Time.time - 600);
                transform.position = new Vector3(x, 0, z) + orbitCenter.position;
            }
            if (radius >= 21 && radius < 26)
            {
                float x = radius * Mathf.Cos(4 * Time.time - 300);
                float z = radius * Mathf.Sin(4 * Time.time - 300);
                transform.position = new Vector3(x, 0, z) + orbitCenter.position;
            }
            if (radius >= 26 && radius < 31)
            {
                float x = radius * Mathf.Cos(5 * Time.time - 600);
                float z = radius * Mathf.Sin(5 * Time.time - 600);
                transform.position = new Vector3(x, 0, z) + orbitCenter.position;
            }
            if (radius >= 31 && radius < 36)
            {
                float x = radius * Mathf.Cos(6 * Time.time - 800);
                float z = radius * Mathf.Sin(6 * Time.time - 800);
                transform.position = new Vector3(x, 0, z) + orbitCenter.position;
            }
            if (radius >= 36 && radius < 41)
            {
                float x = radius * Mathf.Cos(7 * Time.time - 1200);
                float z = radius * Mathf.Sin(7 * Time.time - 1200);
                transform.position = new Vector3(x, 0, z) + orbitCenter.position;
            }
            if (radius >= 41 && radius < 46)
            {
                float x = radius * Mathf.Cos(8 * Time.time - 2);
                float z = radius * Mathf.Sin(8 * Time.time - 2);
                transform.position = new Vector3(x, 0, z) + orbitCenter.position;
            }
            if (orbitCenter.hasChanged) UpdateOrbitPath();
        }
    }
    void UpdateOrbitPath()
    {
        if (!orbitCenter) return;

        float radsPerCircle = 2 * Mathf.PI;


        Vector3[] pts = new Vector3[32];

        for (int i = 0; i < pts.Length; i++)
        {
            float x = radius * Mathf.Cos(i * radsPerCircle / pathResolution);
            float z = radius * Mathf.Sin(i * radsPerCircle / pathResolution);

            Vector3 pt = new Vector3(x, 0, z) + orbitCenter.position;
            pts[i] = pt;
        }
        path.positionCount = pathResolution;
        path.SetPositions(pts);
    }
}
