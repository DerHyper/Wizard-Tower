using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class InputUtilities
{
    // Retruns true if a fire button or joystick is pushed in any direction
    public static bool fireButtonPushed()
    {
        return ControllerFireButtonPushed() || KeyboardFireButtonPushed();
    }

    private static bool ControllerFireButtonPushed()
    {
        return Input.GetAxis("Horizontal Shoot Joystick") != 0 || Input.GetAxis("Vertical Shoot Joystick") != 0;
    }

    private static bool KeyboardFireButtonPushed()
    {
        return Input.GetAxis("Horizontal Shoot") != 0 || Input.GetAxis("Vertical Shoot") != 0;
    }
}
