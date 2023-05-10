using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public Canvas DeathMenu;
    public MenuManager Instance;

    Logger logger;

    private void Awake() {
        Instance = this;
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
    }

    private void OnDestroy() {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
    }

    private void GameManagerOnGameStateChanged(GameState state) {
        if (state == GameState.PlayerDead)
        {
            ActivateMenu(DeathMenu);
        }
    }
    
    private void Start() {
        
        logger = Finder.FindLogger();
        if (DeathMenu != null)
        {
            DeactivateMenu(DeathMenu); 
        }   
    }

    public void DeactivateMenu(Canvas[] menus)
    {
        foreach (Canvas menu in menus)
        {
            DeactivateMenu(menu);
        }
    }

    public void DeactivateMenu(Canvas menu)
    {
        menu.gameObject.SetActive(false);
    }

    public void ToggleMenu(Canvas menu)
    {
        if (menu.isActiveAndEnabled)
        {
            DeactivateMenu(menu);
        }
        else
        {
            ActivateMenu(menu);
        }
    }

    public void ActivateMenu(Canvas menu)
    {
        menu.gameObject.SetActive(true);
    }

    public void LoadMainMenueScene()
    {
        LevelManager.Instance.LoadMainMenueScene();
    }

    public void QuitGame()
    {
        LevelManager.Instance.QuitGame();
    }

    public void LoadNextScene()
    {
        LevelManager.Instance.LoadNextScene();
    }
}
