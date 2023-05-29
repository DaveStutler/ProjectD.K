using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonPressed : MonoBehaviour
{
    //sees if platform disappeared/not
    bool isPlatformActive;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.name == "Player")
        {
            Debug.Log("Player touched the button");
            //collision.gameObject.transform.position = new Vector2(Random.value * 20.0f - 10.0f, this.DestinationLevel.transform.position.y + 4);
            foreach(Transform child in gameObject.transform)
            {
                if(child.tag == "Floor")
                {
                    child.gameObject.SetActive(!child.gameObject.activeSelf);
                }
            }
        }
    }
}
