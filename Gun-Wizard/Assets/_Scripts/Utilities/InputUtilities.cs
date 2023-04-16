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


    public static Vector3 ShootDirectionAsVector3() {
        if (ControllerFireButtonPushed())
        {
            return JoystickShootDirectionAsVector3();
        }
        else if (KeyboardFireButtonPushed())
        {
            return KeyboardShootDirectionAsVector3();
        }
        else
        {
            return Vector3.zero;
        }
    }

    private static Vector3 JoystickShootDirectionAsVector3()
    {
        return new Vector3(
            Input.GetAxis("Horizontal Shoot Joystick"),
            Input.GetAxis("Vertical Shoot Joystick"),
            0
            );
    }

    private static Vector3 KeyboardShootDirectionAsVector3()
    {
        switch (Input.GetAxis("Horizontal Shoot"))
        {
            case > 0:
                return Vector3.right;
            case < 0:
                return Vector3.left;
            default:
                switch (Input.GetAxis("Vertical Shoot"))
                {
                    case > 0:
                        return Vector3.up;
                    case < 0:
                        return Vector3.down;
                    default:
                        return Vector3.zero;
                }
        }
    }
}
