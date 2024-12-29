using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGameMenu : MonoBehaviour
{
    public GameObject MenuParent;
    public bool allowToggle = true;

    public void Update() {
        if (Input.GetKeyDown(KeyCode.Escape) && allowToggle)
        {
            ToggleOnOff();
        }
    }

    private void ToggleOnOff()
    {
        if (MenuParent.activeSelf)
        {
            Back();
        }
        else
        {
            Pause();
        }
    }

    public void MainMenu()
    {
        LevelManager.Instance.LoadMainMenueScene();
    }

    public void Back()
    {
        MenuParent.SetActive(false);
        Time.timeScale=1;
    }

    public void Pause()
    {
        MenuParent.SetActive(true);
        Time.timeScale=0;
    }
    
    public void Quit()
    {
        LevelManager.Instance.QuitGame();
    }
}
