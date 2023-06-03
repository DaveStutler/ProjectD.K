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
}
