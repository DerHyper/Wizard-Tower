using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Logger : MonoBehaviour
{
    [Header("Settings")]
    [SerializeField]
    bool showDebug;

    public void Log(object message, Object sender)
    {
        if (showDebug)
        {
            Debug.Log(message,sender);
        }
    }
}
