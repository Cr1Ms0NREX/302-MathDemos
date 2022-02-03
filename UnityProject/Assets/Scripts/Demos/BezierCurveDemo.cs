using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

public class BezierCurveDemo : MonoBehaviour
{
    public Transform StartPoint;
    public Transform EndPoint;
    public Transform ControlPoint;

    [Range(2,100)]
    public int CurveResolution = 10;
    public float TweenTimeLength = 3;
    public AnimationCurve temporalEasing;
    private float TweenTimeCurrent = 0;
    private bool IsPlaying = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (IsPlaying) TweenTimeCurrent += Time.deltaTime;

        float p = TweenTimeCurrent / TweenTimeLength;

        p = Mathf.Clamp(p, 0, 1);

        p = temporalEasing.Evaluate(p);

        Vector3 pos = FindPointOnCurve(p);
        transform.position = pos;

        if (TweenTimeCurrent >= TweenTimeLength) IsPlaying = false;

    }

    public void PlayTween(bool fromBeginning = false)
    {
        IsPlaying = true;
        if (fromBeginning) TweenTimeCurrent = 0;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireCube(ControlPoint.position, Vector3.one);
        //Gizmos.DrawLine(StartPoint.position, EndPoint.position);


        for (int i = 0; i < CurveResolution; i++)
        {
            Vector3 a = FindPointOnCurve(i / (float)CurveResolution);
            Vector3 b = FindPointOnCurve((i+1) / (float)CurveResolution);

            Gizmos.DrawLine(a, b);

        }
    }
    Vector3 FindPointOnCurve(float percent)
    {
        Vector3 a = AnimMath.Lerp(StartPoint.position, ControlPoint.position, percent);
        Vector3 b = AnimMath.Lerp(ControlPoint.position, EndPoint.position, percent);

        return AnimMath.Lerp(a, b, percent);
    }

}

[CustomEditor(typeof(BezierCurveDemo))]
public class QuadradicDemoEditor : Editor
{
    public override void OnInspectorGUI()
    {
        base.OnInspectorGUI();

        if(GUILayout.Button("Play Tween"))
        {
            (target as BezierCurveDemo).PlayTween(true);
        }
    }
}
