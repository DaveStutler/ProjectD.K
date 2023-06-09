using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DoorController : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject player1;
    [SerializeField] private GameObject player2;
    [SerializeField] private GameObject player3;
    [SerializeField] private string sceneToLoad;
    private int player1Keys = 0;
    private int player2Keys = 0;
    private int player3Keys = 0;
    private bool doorOpen = false;


    // Update is called once per frame
    void Update()
    {
        this.player1Keys = this.player1.GetComponent<Player1Controller>().keyCounter;
        this.player2Keys = this.player2.GetComponent<Player2Controller>().keyCounter;
        this.player3Keys = this.player3.GetComponent<Player3Controller>().keyCounter;
        var total_keys = player1Keys+player2Keys+player3Keys;

        if (total_keys == 3 && !this.doorOpen)
        {
            this.doorOpen = true;
            // The door opens here.
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (this.doorOpen)
        {
            SceneManager.LoadScene(sceneToLoad);
        }
    }
}