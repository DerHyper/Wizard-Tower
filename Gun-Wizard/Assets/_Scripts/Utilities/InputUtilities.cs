using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputUtilities
{
    // Retruns true if a fire button or joystick is pushed in any direction
    public static bool fireButtonPushed()
    {
        return Input.GetAxisRaw("Horizontal Shoot") != 0 || Input.GetAxisRaw("Horizontal Shoot") != 0;
    }
}
