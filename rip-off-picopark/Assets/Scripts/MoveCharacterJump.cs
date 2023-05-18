using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Player;

namespace Player
{
    public class MoveCharacterJump : ScriptableObject, IPlayerController
    {
        private float speed = 5.0f;

        public void Execute(GameObject gameObject)
        {
            var rigidBody = gameObject.GetComponent<Rigidbody2D>();
            if (rigidBody != null)
            {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, this.speed);
                gameObject.GetComponent<SpriteRenderer>().flipX = false;
            }
        }
    }
}