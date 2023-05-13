using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbiltyDoubleJump : ScriptableObject
{
    [SerializeField] private Transform floorCheck;
    [SerializeField] private LayerMask floorLayer;

    private float jumpForce = 15f;
    private bool doubleJump = false;

    public void Execute(GameObject gameObject)
    {
        var rigidBody = gameObject.GetComponent<Rigidbody2D>();
        if (IsGrounded() && Input.GetKeyDown(KeyCode.W))
        {
            doubleJump = false;
        }

        if (Input.GetKeyDown(KeyCode.W))
        {
            if (IsGrounded() || doubleJump)
            {
                rigidBody.velocity = new Vector2(rigidBody.velocity.x, jumpForce);
                doubleJump = !doubleJump;
            }
        }
    }

    private bool IsGrounded()
    {
        return Physics2D.OverlapCircle(floorCheck.position, 0.2f, floorLayer);
    }
}
