using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonDestroyWall : MonoBehaviour
{
    // The gameObject in the position of the platform that needs to be spawned
    // and the object that needs to be spawned in that position. 
    [SerializeField] private GameObject platform;
    private bool pressed = false;
    private bool platformDestroyed = false;
    private float timer = 0.0f;



    // Update is called once per frame
    void Update()
    {
        if (pressed && !platformDestroyed)
        {
            // Need to check if the button has been pressed and then also if the platform has not been moved and if the platform exists.
            // Want to move it to the final position. (TO DO)
            Destroy(platform);
            this.platformDestroyed = true;

        }
        this.timer += Time.deltaTime;
        if (timer >= 0.5)
        {
            Destroy(platform); 
            this.platformDestroyed= true;
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