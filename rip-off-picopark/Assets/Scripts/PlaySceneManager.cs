using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

using GeneralSceneManager;

public class PlaySceneManager : MonoBehaviour
{
    [SerializeField] private GameObject lockDungeon;
    [SerializeField] private GameObject lockForest;
    [SerializeField] private GameObject dungeonMask;
    [SerializeField] private GameObject forestMask;

    // To change scene from Play to Selection screen.
    // Build index: 1
    public Button[] levelButtons;
    private int levelAt;

    void Start()
    {
        levelAt = PlayerPrefs.GetInt("levelAt", 2);
        
        for (int i = 0; i < levelButtons.Length; i++)
        {
            if (i + 2 > levelAt)
            {
                levelButtons[i].interactable = false;
            }
        }
    }

    public void Update()
    {
        if (levelAt == 2)
        {
            // Show chains when level is locked.
            lockDungeon.SetActive(true);
            lockForest.SetActive(true);

            // Make the locked levels dimmer than unlocked ones.
            dungeonMask.SetActive(true);
            forestMask.SetActive(true);
        }
        else if (levelAt == 3)
        {
            // Unlock dungeon stage, but keep forest locked.
            lockDungeon.SetActive(false);
            lockForest.SetActive(true);

            // Make the locked levels dimmer than unlocked ones.
            dungeonMask.SetActive(false);
            forestMask.SetActive(true);
        }
        else if (levelAt == 4)
        {
            // Unlock both stages.
            lockDungeon.SetActive(false);
            lockForest.SetActive(false);

            // Make the locked levels dimmer than unlocked ones.
            dungeonMask.SetActive(false);
            forestMask.SetActive(false);
        }
    }

    public void goToSelectionScreen()
    {
        PlayerPrefs.SetInt("levelAt", 2);
        levelAt = PlayerPrefs.GetInt("levelAt");
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        lockDungeon.SetActive(false);
        
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
