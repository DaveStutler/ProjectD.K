using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Player;

public class StopHorizontalMovement : ScriptableObject, IPlayerController
{
    public void Execute(GameObject gameObject)
    {
        var rigidBody = gameObject.GetComponent<Rigidbody2D>();
        if (rigidBody != null)
        {
            //this.timePassed = Time.deltaTime;
            rigidBody.velocity = new Vector2(0, rigidBody.velocity.y);
            // var oldPosition = rigidBody.transform.position;
            // rigidBody.position = new Vector3(oldPosition.x + (this.speed * timePassed), oldPosition.y, oldPosition.z);
        }
    }
}
