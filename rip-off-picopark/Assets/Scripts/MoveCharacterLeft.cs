using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Player;

namespace Player
{
    public class MoveCharacterLeft : ScriptableObject, IPlayerController
    {
        private float speed = 5.0f;
        // private float timePassed = 0;

        public void Execute(GameObject gameObject)
        {
            var rigidBody = gameObject.GetComponent<Rigidbody2D>();
            if (rigidBody != null)
            {
                //this.timePassed = Time.deltaTime;
                rigidBody.velocity = new Vector2(-this.speed, rigidBody.velocity.y);
                // var oldPosition = rigidBody.transform.position;
                // rigidBody.position = new Vector3(oldPosition.x + (this.speed * timePassed), oldPosition.y, oldPosition.z);
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
    }
}