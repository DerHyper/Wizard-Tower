using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState State;

    public static event Action<GameState> OnGameStateChanged;

    private void Awake() {
        Instance = this;
    }

    void Start() {
        UpdateGameState(GameState.Loading);
    }

    public void UpdateGameState(GameState newState) {
        State = newState;

        switch (newState)
        {
            case GameState.Loading:
                UpdateGameState(GameState.Playing);
                break;
            case GameState.Playing:
                break;
            case GameState.LevelComplete:
                break;
            case GameState.PlayerDead:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState));
        }

        OnGameStateChanged?.Invoke(newState);
    }
}

public enum GameState{
    Loading,
    Playing,
    LevelComplete,
    PlayerDead
}
