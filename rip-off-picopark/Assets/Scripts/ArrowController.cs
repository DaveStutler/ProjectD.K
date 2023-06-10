using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{

    void Update()
    {
        if (this.gameObject.transform.position.y <= -5)
        {
            Destroy(this.gameObject);
        }
        
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Death")
        {
            Destroy(this.gameObject);
        }
    }
}
