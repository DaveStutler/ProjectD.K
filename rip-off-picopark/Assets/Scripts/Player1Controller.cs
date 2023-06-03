using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class Player1Controller : MonoBehaviour
{
    [SerializeField] private GameObject floor;
    private IPlayerController right;
    private IPlayerController left;
    private IPlayerController jump;
    private IPlayerController special;
    private IPlayerController horizontalStop;
    private bool canJump = true;
    private bool rightPressed = false;
    private bool leftPressed = false;
    private bool canDoubleJump = false;
    private int jumpCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        this.jump = ScriptableObject.CreateInstance<MoveCharacterJump>();
        this.right = ScriptableObject.CreateInstance<MoveCharacterRight>();
        this.left = ScriptableObject.CreateInstance<MoveCharacterLeft>();
        this.special = ScriptableObject.CreateInstance<AbilityDoubleJump>();
        this.horizontalStop = ScriptableObject.CreateInstance<StopHorizontalMovement>();
    }

    // Update is called once per frame
    void Update()
    {   
        if (Input.GetKeyUp(KeyCode.D))
        {
            this.rightPressed = false;
            // Want to stop horizontal movement.
            this.horizontalStop.Execute(this.gameObject);
        }
        if (Input.GetKeyUp(KeyCode.A))
        {
            this.leftPressed = false;
            // Want to stop horizontal movement.
            this.horizontalStop.Execute(this.gameObject);
        }
        if (Input.GetKeyDown(KeyCode.W) && this.canJump && jumpCount < 2)
        {
            if (!canDoubleJump)
            {
                this.jump.Execute(this.gameObject);
                this.canJump = false;

            }
            else if (canDoubleJump && jumpCount < 2)
            {
                this.jump.Execute(this.gameObject);
            }
            this.jumpCount++;         
        }
        if (Input.GetKeyDown(KeyCode.D) || this.rightPressed)
        {
            this.right.Execute(this.gameObject);
            this.rightPressed = true;
        }
        if (Input.GetKeyDown(KeyCode.A) || this.leftPressed)
        {
            this.left.Execute(this.gameObject);
            this.leftPressed = true;
        }
        if (Input.GetKeyDown(KeyCode.Q))
        {
            canDoubleJump = true;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            // Know the player has collided with the floor meaning they can jump again.
            this.canJump = true;
            this.jumpCount = 0;
        }
    }
}
