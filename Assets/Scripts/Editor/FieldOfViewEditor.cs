using UnityEditor;
using System.Collections.Generic;
using UnityEngine;

[CustomEditor(typeof(FiewOfView))]
public class FieldOfViewEditor : Editor
{
    void OnSceneGUI()
    {
        FiewOfView fow = (FiewOfView)target;
        Handles.color = Color.white;
        Handles.DrawWireArc(fow.transform.position, Vector3.forward, Vector3.up, 360, fow.viewRadius);
        Vector2 viewAngleRight = GameHelper.ConvertAngleToDirection(-fow.viewAngle/2f, false, fow.transform);
        Vector2 viewAngleLeft = GameHelper.ConvertAngleToDirection(fow.viewAngle/2f, false, fow.transform);
        Handles.DrawLine(fow.transform.position,(Vector2)fow.transform.position + viewAngleRight * fow.viewRadius);
        Handles.DrawLine(fow.transform.position,(Vector2)fow.transform.position + viewAngleLeft * fow.viewRadius);
    }
}
