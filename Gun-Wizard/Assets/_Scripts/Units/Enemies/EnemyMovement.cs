using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    private EnemyAI enemyAI;
    private bool isHunting;
    Rigidbody2D rb;
    GameObject player;

    private void Awake() {
        enemyAI = GetComponentInParent<EnemyAI>();
        enemyAI.OnEnemyStateChanged += EnemyAIOnGameStateChanged;
    }

    private void OnDestroy() {
        enemyAI.OnEnemyStateChanged -= EnemyAIOnGameStateChanged;
    }

    private void EnemyAIOnGameStateChanged(EnemyState state) {
        isHunting = (state == EnemyState.Hunt);
    }

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        player = Finder.FindPlayer();
    }

    // Update is called once per frame
    void Update()
    {
        if (isHunting)
        {
            Vector2 direction = (player.transform.position -transform.position).normalized;
            rb.position = rb.position + direction*Time.deltaTime;
        }
    }
}