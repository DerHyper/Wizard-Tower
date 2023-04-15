using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;

    //acts as the  motor to move the player
    public Rigidbody2D rb;

    //stores Player movement
    Vector2 movement;

    // Update is called once per frame
    void Update()
    {
        //value between -1 to 1
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    void FixedUpdate()
    {
        //moves the rigid body to a new position and collides if sth is in the way
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
