using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    private MenuManager Instance;

    Logger logger;

    public void Awake() {
        Instance = this;
        GameManager.OnGameStateChanged += GameManagerOnGameStateChanged;
    }

    public void OnDestroy() {
        GameManager.OnGameStateChanged -= GameManagerOnGameStateChanged;
    }

    public void GameManagerOnGameStateChanged(GameState state) {
        if (state == GameState.PlayerDead)
        {
            ActivateDeathMenu();
        }
    }

    private void ActivateDeathMenu()
    {
        Finder.FindDeathMenu().GetComponent<InGameMenu>().Pause();
    }

    public void Start()
    {
        logger = Finder.FindLogger();
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

    public void DeactivateMenu(GameObject menu)
    {
        menu.SetActive(false);
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

    public void ActivateMenu(GameObject menu)
    {
        menu.SetActive(true);
    }

    public void LoadMainMenueScene()
    {
        LevelManager.Instance.LoadMainMenueScene();
    }

    public void LoadShopMenueScene()
    {
        LevelManager.Instance.LoadShopScene();
    }

    public void QuitGame()
    {
        LevelManager.Instance.QuitGame();
    }

    public void LoadNextScene()
    {
        LevelManager.Instance.LoadNextScene();
    }

    public void LoadLevelBuildScence()
    {
        LevelManager.Instance.LoadLevelBuildTestScence();
    }
}
