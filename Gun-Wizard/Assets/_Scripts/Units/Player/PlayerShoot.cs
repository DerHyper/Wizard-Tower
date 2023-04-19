using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerShoot : MonoBehaviour
{
    [SerializeField]
    Transform firePoint;

    [SerializeField]
    Logger logger;

    public InputAction inputAction;

    private void OnEnable()
    {
        inputAction.Enable();
    }

    private void OnDisable() {
        inputAction.Disable();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        Vector2 shootDirection = inputAction.ReadValue<Vector2>();

        if (shootDirection.magnitude > 0)
        {
            logger.Log("FIRE!",this);
        }
    }

    

}
