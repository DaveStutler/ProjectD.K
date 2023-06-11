using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyController : MonoBehaviour
{
    [SerializeField] private int leashDistance = 5;
    public bool collected = false;
    private GameObject collectedBy;
    private float keySpeed = 5.0f;
    private float catchUpKeySpeed = 1.0f;



    // Update is called once per frame
    void Update()
    {   
        var currentPlayerPosition = collectedBy.transform.position;
        var keyPosition = this.gameObject.transform.position;
        var distance = currentPlayerPosition - keyPosition;
        if (collected && distance.magnitude >= this.leashDistance)
        {
            // If the key has been collected and the distance it is longer than the leashDistance.
            this.gameObject.transform.position = Vector3.MoveTowards(keyPosition, currentPlayerPosition, keySpeed * Time.deltaTime);

        }
        if (collected && distance.magnitude < this.leashDistance)
        {
            this.gameObject.transform.position = Vector3.MoveTowards(keyPosition, currentPlayerPosition, catchUpKeySpeed * Time.deltaTime);
        }
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        // Want to make it so that if theres a collision with a player it must follow that player. 
        if (collision.gameObject.tag == "Player" && !collected)
        {
            collected = true;
            collectedBy = collision.gameObject;
            
            if (collision.gameObject.name == "Player 1")
            {
                collision.gameObject.GetComponent<Player1Controller>().keyCounter += 1;
            }
            if (collision.gameObject.name == "Player 2")
            {
                collision.gameObject.GetComponent<Player2Controller>().keyCounter += 1;
            }
            if (collision.gameObject.name == "Player 3")
            {
                collision.gameObject.GetComponent<Player3Controller>().keyCounter += 1;
            }

        }

    }


}
