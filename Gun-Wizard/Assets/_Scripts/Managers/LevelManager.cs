using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager Instance;
    public ArrayList scenes; // Does not work right now
    [SerializeField]
    private int currentLevel = 0;
    private int maxLevel;

    Logger logger;

    private void Awake() {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Start()
    {
        logger = Finder.FindLogger();
        // shuffleList(scenes);
        // maxLevel = scenes.Count;
    }

    private void shuffleList(ArrayList scenes)
    {
        for (int i = 0; i < scenes.Count; i++)
        {
            int randomIndex = Random.Range(i,scenes.Count);
            Scene temp = (Scene)scenes[i];
            scenes[i] = scenes[randomIndex];
            scenes[randomIndex] = temp;
        }
    }

    public void LoadMainMenueScene()
    {
        logger.Log("Load Main Menue.", this);
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadShopScene()
    {
        logger.Log("Load Shop Menue.", this);
        SceneManager.LoadScene("Shop");
    }

    public void LoadLevelBuildTestScence()
    {
        logger.Log("Load Shop Menue.", this);
        SceneManager.LoadScene("LevelBuildTestScence");
    }

    public void LoadNextScene()
    {
        int maxScenes = SceneManager.sceneCountInBuildSettings-1;
        
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex >= maxScenes)
        {
            SceneManager.LoadScene(0);
        }
        else
        {
            logger.Log($"Loading next scene: {nextSceneIndex}, {SceneManager.GetSceneByBuildIndex(nextSceneIndex).name}", this);
            SceneManager.LoadScene(nextSceneIndex);
        }
        ResetGame();
    }

    private void ResetGame()
    {
        Time.timeScale = 1;
        GameManager.Instance.UpdateGameState(GameState.Playing);
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
        ResetGame();
    }

    public void LoadNextRandomScene()
    {
        if (currentLevel > maxLevel)
        {
            LoadMainMenueScene();
            // All levels played
        }
        Scene nextScene = (Scene)scenes[currentLevel];
        SceneManager.LoadScene(nextScene.name);
        currentLevel++;
        scenes.Remove(nextScene);
        ResetGame();
    }


    public void QuitGame()
    {
        Debug.Log("Quit!", this);
        Application.Quit();
    }
}
