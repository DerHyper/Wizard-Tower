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
    private float huntRadius, stayRadius, fleeRadius;

    void Start() {
        UpdateEnemyState(EnemyState.Idle);
        logger = Finder.FindLogger();
    }

    public void UpdateEnemyState(EnemyState newState) {
        State = newState;
        logger?.Log($"Enemy is now in {newState}-State", this);
        switch (newState)
        {
            case EnemyState.Idle:
                break;
            case EnemyState.Hunt:
                break;
            case EnemyState.Flee:
                break;
            case EnemyState.Stay:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState));
        }
        OnEnemyStateChanged?.Invoke(newState);
    }

    private void Update() {
        checkPlayerInRadius();
        logger.DrawCircle(gameObject.transform.position, huntRadius);
        logger.DrawCircle(gameObject.transform.position, fleeRadius);
        logger.DrawCircle(gameObject.transform.position, stayRadius);
    }

    private void checkPlayerInRadius()
    {
        GameObject player = Finder.FindPlayer();
        float distance = (player.transform.position - transform.position).magnitude;
        if (IsInHuntDistance(distance))
        {
            UpdateEnemyState(EnemyState.Hunt);
        }
        else if (IsInStayDistance(distance))
        {
            UpdateEnemyState(EnemyState.Stay);
        }
        else if (IsInFleeDistance(distance))
        {
            UpdateEnemyState(EnemyState.Flee);
        }
        else if (State != EnemyState.Idle)
        {
            UpdateEnemyState(EnemyState.Idle);
        }
    }

    private bool IsInFleeDistance(float distance)
    {
        return distance < fleeRadius && State != EnemyState.Flee;
    }

    private bool IsInStayDistance(float distance)
    {
        return distance < stayRadius && distance > fleeRadius && State != EnemyState.Stay;
    }

    private bool IsInHuntDistance(float distance)
    {
        return distance < huntRadius && distance > stayRadius && State != EnemyState.Hunt;
    }
}
    

public enum EnemyState
{
    Idle,
    Hunt,
    Flee,
    Stay
}
