using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;

    Logger logger;

    private void Awake() {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        } 
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        logger = Finder.FindLogger();
    }

    public void LoadMainMenueScene()
    {
        logger.Log("Load Main Menue.", this);
        SceneManager.LoadScene(0);
    }

    public void LoadNextScene()
    {
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        logger.Log($"Loading next scene: {nextSceneIndex}, {SceneManager.GetSceneByBuildIndex(nextSceneIndex).name}", this);
        SceneManager.LoadScene(nextSceneIndex);
    }

    public void LoadScene(string sceneName)
    {
        if (SceneManager.GetSceneByName(sceneName).IsValid())
        {
            SceneManager.LoadScene(sceneName);
        }
        else
        {
            logger.Log($"The Scene {sceneName} does not exist", this);
        }
    }

    public void QuitGame()
    {
        Debug.Log("Quit!", this);
        Application.Quit();
    }
}
