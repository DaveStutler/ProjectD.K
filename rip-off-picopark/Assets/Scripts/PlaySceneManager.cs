using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlaySceneManager : MonoBehaviour
{
    [SerializeField] private string sceneToLoad;
    

    // To change scene from Play to Selection screen
    public void goToSelection()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
