using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    //acts as the  motor to move the player
    public Rigidbody2D rb;
    public PlayerInputActions playerControls;

    //stores Player movement
    Vector2 movement;
    private InputAction move;

    private void Awake() {
        playerControls = new PlayerInputActions();
    }

    private void OnEnable() {
        move = playerControls.Player.Move;
        move.Enable();
    }

    private void OnDisable() {
        move.Disable();
    }

    // Update is called once per frame
    void Update()
    {
        //value between -1 to 1
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        movement = move.ReadValue<Vector2>();
    }

    void FixedUpdate()
    {
        //moves the rigid body to a new position and collides if sth is in the way
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
