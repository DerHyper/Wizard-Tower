using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float moveSpeed = 5f;

    //acts as the  motor to move the player
    public Rigidbody2D rb;
    public InputAction inputAction;

    public bool isPlaying = true;

    private void Start() {
        moveSpeed = GetComponent<UnitDisplay>().GetMovementSpeed();
    }

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
        //Debug.Log(isPlaying);
        if (isPlaying) LetPlayerMove();
    }

    private void LetPlayerMove()
    {
        Vector2 movement = inputAction.ReadValue<Vector2>();
        //moves the rigid body to a new position and collides if sth is in the way
        //rb.velocity = movement*moveSpeed*Time.fixedDeltaTime*50;
        rb.position = rb.position + movement * moveSpeed * Time.fixedDeltaTime;
        //rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime);
    }
}
