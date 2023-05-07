using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public InputAction shootingInput;

    private void OnEnable()
    {
        shootingInput.Enable();
    }

    private void OnDisable() {
        shootingInput.Disable();
    }

    // Retruns 'true' is the player is pressing a shoot-button (e.g. Arrow Keys or the right Joystick of a Gamepad)
    public bool ShootButtonPressed()
    {
        Vector2 shootDirection = shootingInput.ReadValue<Vector2>();
        return shootDirection.magnitude > 0;
    }

    // Transforms Input-Vektor to a Quaternion
    public Quaternion GetShootQuaternion()
    {
        Vector2 shootDirection = shootingInput.ReadValue<Vector2>();
        Quaternion OriginalQuaternion = Quaternion.LookRotation(Vector3.forward, shootDirection);
        Quaternion TransformedQuaternion = OriginalQuaternion * Quaternion.Euler(0, 0, 90);
        return TransformedQuaternion;
    }
}
