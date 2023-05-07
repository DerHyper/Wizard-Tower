using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public GameState State;
    Logger logger;

    public static event Action<GameState> OnGameStateChanged;

    private void Awake() {
        Instance = this;
    }

    void Start() {
        UpdateGameState(GameState.Playing);
        logger = Finder.FindLogger();
    }

    public void UpdateGameState(GameState newState) {
        State = newState;
        logger?.Log($"Player is now in {newState}-State", this);
        switch (newState)
        {
            case GameState.Loading:
                break;
            case GameState.Playing:
                break;
            case GameState.LevelComplete:
                break;
            case GameState.PlayerDead:
                HandlePlayerDead();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(newState));
        }
        OnGameStateChanged?.Invoke(newState);
    }

    private void HandlePlayerDead()
    {
        //throw new NotImplementedException();
    }

}

public enum GameState{
    Loading,
    Playing,
    LevelComplete,
    PlayerDead
}
