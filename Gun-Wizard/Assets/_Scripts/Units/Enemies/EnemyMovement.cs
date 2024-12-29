using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private EnemyAI enemyAI;
    EnemyState state;
    private float movementSpeed;
    Rigidbody2D rb;
    GameObject player;

    private void Awake() {
        enemyAI = GetComponent<EnemyAI>();
        enemyAI.OnEnemyStateChanged += EnemyAIOnGameStateChanged;
    }

    private void OnDestroy() {
        enemyAI.OnEnemyStateChanged -= EnemyAIOnGameStateChanged;
    }

    private void EnemyAIOnGameStateChanged(EnemyState state) {
        this.state = state;
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = Finder.FindPlayer();
        movementSpeed = GetComponent<UnitDisplay>().GetMovementSpeed();
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        Vector2 direction = CalculateDirection();
        Vector2 frameMoveAmount = direction * Time.deltaTime * movementSpeed;
        rb.position = rb.position + frameMoveAmount;
    }

    private Vector2 CalculateDirection()
    {
        switch (state)
        {
            case EnemyState.Idle: return new Vector2();
            case EnemyState.Hunt: return PlayerDirection();
            case EnemyState.Flee: return -PlayerDirection();
            case EnemyState.Stay: return new Vector2();
            default: throw new ArgumentOutOfRangeException(nameof(state));
        }
    }

    private Vector2 PlayerDirection()
    {
        Vector2 direction = (player.transform.position -transform.position).normalized;
        return direction;
    }
}
