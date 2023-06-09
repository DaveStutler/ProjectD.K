using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Player;


    public class MoveCharacterDashLeft : ScriptableObject, IPlayerController
    {
        private float speed = 20.0f;

        public void Execute(GameObject gameObject)
        {
            var rigidBody = gameObject.GetComponent<Rigidbody2D>();
            if (rigidBody != null)
            {
            
                rigidBody.velocity = new Vector2(-this.speed, rigidBody.velocity.y);
                gameObject.GetComponent<SpriteRenderer>().flipX = true;
            }
        }
    }
