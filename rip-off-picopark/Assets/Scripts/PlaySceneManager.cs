using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using GeneralSceneManager;

public class PlaySceneManager : MonoBehaviour
{
    //[SerializeField] private string sceneToLoad;

    // To change scene from Play to Selection screen.
    // Build index: 1
    public Button[] levelButtons;

    void Start()
    {
        int levelAt = PlayerPrefs.GetInt("levelAt", 2);
        
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 2 > levelAt)
            {
                levelButtons[i].interactable = false;
            }
        }
    }

    public void goToSelectionScreen()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }


    // Change scene to Jail Escape scene;
    // Build index: 2
    public void goToJailEscape()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    // Change scene to Dungeon scene;
    // Build index: 3
    public void goToDungeon()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    // Change scene to Forest scene;
    // Build index: 4
    public void goToForest()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 3);
    }

    // Change scene to Island scene;
    // Build index: 5
    public void goToIsland()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 4);
    }

    // Change scene to Thank you scene;
    // Build index: 6
    public void goToThankYou()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 5);
    }

    public void goToCredits()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
