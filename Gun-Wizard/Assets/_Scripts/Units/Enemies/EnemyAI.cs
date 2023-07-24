using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EnemyAI : MonoBehaviour
{
    public EnemyState State {get; set;}
    public event Action<EnemyState> OnEnemyStateChanged;
    private Logger logger;
    [SerializeField]
    private float huntingRadius;

    void Start() {
        UpdateEnemyState(EnemyState.Idle);
        logger = Finder.FindLogger();
    }

    public void UpdateEnemyState(EnemyState newState) {
        State = newState;
        logger?.Log($"Player is now in {newState}-State", this);
        switch (newState)
        {
            case EnemyState.Idle:
                break;
            case EnemyState.Hunt:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState));
        }
        OnEnemyStateChanged?.Invoke(newState);
    }

    private void Update() {
        checkPlayerInRadius();
        Debug.Log(logger);
        logger.DrawCircle(gameObject.transform.position, huntingRadius);
    }

    private void checkPlayerInRadius()
    {
        GameObject player = Finder.FindPlayer();
        float distance = (player.transform.position - transform.position).magnitude;
        if (distance < huntingRadius)
        {
            UpdateEnemyState(EnemyState.Hunt);
        } 
        else if (State != EnemyState.Idle)
        {
            UpdateEnemyState(EnemyState.Idle);
        }
    }
}
    

public enum EnemyState
{
    Idle,
    Hunt
}
