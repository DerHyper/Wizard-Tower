using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    //acts as the  motor to move the player
    public Rigidbody2D rb;
    public InputAction inputAction;

    //stores Player movement
    Vector2 movement;

    private void OnEnable()
    {
        inputAction.Enable();
    }

    private void OnDisable() {
        inputAction.Disable();
    }

    void FixedUpdate()
    {
        movement = inputAction.ReadValue<Vector2>();
        //moves the rigid body to a new position and collides if sth is in the way
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
