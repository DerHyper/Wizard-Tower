using System;
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

    private bool isPlaying;

    private void Awake() {
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
    }

    private void OnDestroy() {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
    }

    private void GameManagerOnGameStateChanged(GameState state) {
        isPlaying = (state == GameState.Playing || state == GameState.LevelComplete);
    }

    private void OnEnable()
    {
        inputAction.Enable();
    }

    private void OnDisable() {
        inputAction.Disable();
    }

    void FixedUpdate()
    {
        if (isPlaying) LetPlayerMove();
    }

    private void LetPlayerMove()
    {
        movement = inputAction.ReadValue<Vector2>();
        //moves the rigid body to a new position and collides if sth is in the way
        rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
