using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class GameHelper
{
    private static readonly Dictionary<float, WaitForSeconds> WaitDictionary = new Dictionary<float, WaitForSeconds>();
    public static WaitForSeconds wait(float time)
    {
        if (WaitDictionary.TryGetValue(time, out var wait)) return wait;
        WaitDictionary[time] = new WaitForSeconds(time);
        return WaitDictionary[time];
    }

    private static Camera _Camera;
    public static Camera Camera
    {
        get
        {
            if (_Camera == null) _Camera = Camera.main;
            return _Camera;
        }
    }

    public static Vector2 ConvertAngleToDirection(float angle, bool isGlobalAngle = false, Transform target = null)
    {
        if(!isGlobalAngle)
        {
            angle -= target.eulerAngles.z;
        }
        var direction = new Vector2(Mathf.Sin(Mathf.Deg2Rad * angle), Mathf.Cos(Mathf.Deg2Rad * angle));
        return direction;
    }
}
