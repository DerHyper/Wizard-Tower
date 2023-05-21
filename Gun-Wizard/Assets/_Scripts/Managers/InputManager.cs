using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    public InputAction shootingInput;

    private CurrentInput currentInput;

    private void OnEnable()
    {
        shootingInput.Enable();
    }

    private void OnDisable() {
        shootingInput.Disable();
    }
    private void Start() {
        currentInput = CurrentInput.Mouse;
    }

    // Retruns 'true' is the player is pressing a shoot-button (e.g. Arrow Keys or the right Joystick of a Gamepad)
    public bool ShootButtonPressed()
    {
         if (currentInput == CurrentInput.Mouse)
        {
            return Input.GetMouseButton(0);
        } 
        else if (currentInput == CurrentInput.Controller || currentInput == CurrentInput.Keyboard)
        {
            Vector2 shootDirection = shootingInput.ReadValue<Vector2>();
            return shootDirection.magnitude > 0;
        }
        else
        {
            throw new System.NotImplementedException();
        }

        
    }

    // Transforms Input-Vektor to a Quaternion
    public Quaternion GetShootQuaternion()
    {
        Vector2 shootDirection = shootingInput.ReadValue<Vector2>();
        Quaternion OriginalQuaternion = Quaternion.LookRotation(Vector3.forward, shootDirection);
        Quaternion TransformedQuaternion = OriginalQuaternion * Quaternion.Euler(0, 0, 90);
        return TransformedQuaternion;
    }

    public Vector3 GetShootVektor()
    {
        if (currentInput == CurrentInput.Mouse)
        {
            Vector3 mousePosition = shootingInput.ReadValue<Vector2>();
            mousePosition.z = Camera.main.nearClipPlane;
            return Camera.main.ScreenToWorldPoint(mousePosition);
        } 
        else if (currentInput == CurrentInput.Controller || currentInput == CurrentInput.Keyboard)
        {
            Vector2 shootVector = shootingInput.ReadValue<Vector2>();
            return shootVector;
        }
        else
        {
            throw new System.NotImplementedException();
        }
        
    }
}

public enum CurrentInput{
    Controller,
    Mouse,
    Keyboard
}
