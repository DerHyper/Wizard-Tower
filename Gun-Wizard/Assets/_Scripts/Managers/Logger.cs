using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logger : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    bool showDebug;
    List<(Vector3 postion, float radius)> circles = new List<(Vector3 postion, float radius)>{};

    public void Log(object message, Object sender)
    {
        if (showDebug)
        {
            Debug.Log(message,sender);
        }
    }

    public void DrawCircle(Vector3 position,float radius)
    {
        circles.Add((position, radius));
    }

    private void OnDrawGizmos() 
    {
        foreach ((Vector3 postion, float radius) circle in circles)
        {
            Gizmos.color = Color.cyan;
            Gizmos.DrawWireSphere(circle.postion, circle.radius);
        }
        circles.Clear();
    }
}
