using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArrowController : MonoBehaviour
{
    private float lifetime = 3.0f;
    void Update()
    {   
        this.lifetime -= Time.deltaTime;
        if (this.gameObject.transform.position.y <= -5)
        {
            Destroy(this.gameObject);
        }
        else if(lifetime <=0)
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
