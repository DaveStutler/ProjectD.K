﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyWobbly : MonoBehaviour
{
    // The gameObject in the position of the platform that needs to be spawned
    // and the object that needs to be spawned in that position. 
    [SerializeField] public GameObject platform;
    [SerializeField] private GameObject wobblyPrefab;
    [SerializeField] private float timeInterval = 1.5f;
    [SerializeField] private float timeUntilReappear = 3.0f;
    private bool pressed = false;
    public bool platformDestroyed = false;
    //private bool wobblyDestroyed = false;
    private float timer = 0.0f;
    private Vector2 position;

    private void Start()
    {
        this.position = platform.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        // Checks if platform is there when button is pressed
        // If it is, start the timer for dash player to pass the challenge
        // Destroy platform when it passes desinated time.
        if (pressed && !platformDestroyed)
        {
            this.timer += Time.deltaTime;
            if (timer >= this.timeInterval)
            {
                Destroy(platform);
                this.platformDestroyed = true;
                timer = 0;
            }

        }
        // Creates a new plaform for wobbly brick after cooldown so player can try the challenge again
        else if (platformDestroyed)
        {
            this.timer += Time.deltaTime;
            if (timer >= timeUntilReappear)
            {
                platform = Instantiate(wobblyPrefab, this.position, Quaternion.identity);
                this.platformDestroyed = false;
                timer = 0;
            }
        }
    }


    void OnTriggerEnter2D(Collider2D collision)
    {

        if (collision.gameObject.tag == "Player")
        {
            // Know the player has collided with the button.
            var player = collision.gameObject;
            if (!pressed)
            {
                this.pressed = true;
            }

        }
    }
}