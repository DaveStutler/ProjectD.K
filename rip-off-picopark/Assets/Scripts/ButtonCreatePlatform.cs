using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCreatePlatform : MonoBehaviour
{
    // The gameObject in the position of the platform that needs to be spawned
    // and the object that needs to be spawned in that position. 
    [SerializeField] private GameObject platformPosition;
    [SerializeField] private GameObject platform;
    private bool pressed = false;
    private bool platformMade = false;
    private bool platformMoved = false;
    private Vector3 beginningPlatformLocation;
    private Vector3 endPlatformLocation;

    void Start()
    {
        this.beginningPlatformLocation = this.gameObject.transform.position;
        this.endPlatformLocation = platformPosition.transform.position;
    }


    // Update is called once per frame
    void Update()
    {
        if (pressed && !platformMoved && !platformMade)
        {
            // Need to check if the button has been pressed and then also if the platform has not been moved and if the platform exists.
            // Want to move it to the final position. (TO DO)
            Instantiate(platform, endPlatformLocation, Quaternion.identity);
            this.platformMoved = true;

        }
    }


    void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            // Know the player has collided with the button.
            var player = collision.gameObject;
            if (!pressed && collision.gameObject.transform.position.y >= this.gameObject.transform.position.y)
            {
                this.pressed = true;
            }

        }
    }
}