using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class Player3Controller : MonoBehaviour
{
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
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        //this.gameObject.AddComponent<CaptainMotivateCommand>();
        // this.fire1 = gameObject.AddComponent<CaptainMotivateCommand>();
        this.jump = ScriptableObject.CreateInstance<MoveCharacterJump>();
        this.right = ScriptableObject.CreateInstance<MoveCharacterRight>();
        this.left = ScriptableObject.CreateInstance<MoveCharacterLeft>();
        this.horizontalStop = ScriptableObject.CreateInstance<StopHorizontalMovement>();
        this.animator = this.gameObject.GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Keypad6))
        {
            this.rightPressed = false;
            // Want to stop horizontal movement.
            this.horizontalStop.Execute(this.gameObject);
        }
        if (Input.GetKeyUp(KeyCode.Keypad4))
        {
            this.leftPressed = false;
            // Want to stop horizontal movement.
            this.horizontalStop.Execute(this.gameObject);
        }
        if (Input.GetKeyDown(KeyCode.Keypad8) && this.canJump)
        {
            if (!canDoubleJump)
            {
                this.jump.Execute(this.gameObject);
                this.canJump = false;
                this.animator.SetBool("isJumping", true); // set the animator to jump
            }
            else if (canDoubleJump && jumpCount < 2)
            {
                this.jump.Execute(this.gameObject);
                this.animator.SetBool("isJumping", true); // set the animator to jump
            }
            this.jumpCount++;
        }
        if (Input.GetKeyDown(KeyCode.Keypad6) || this.rightPressed)
        {
            this.right.Execute(this.gameObject);
            this.rightPressed = true;
        }
        if (Input.GetKeyDown(KeyCode.Keypad4) || this.leftPressed)
        {
            this.left.Execute(this.gameObject);
            this.leftPressed =true;
        }
        if (Input.GetKeyDown(KeyCode.Keypad7))
        {
            canDoubleJump = true;
        }
        this.animator.SetFloat("speed", Mathf.Abs(this.gameObject.GetComponent<Rigidbody2D>().velocity.x/5.0f));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor")
        {
            // Know the player has collided with the floor meaning they can jump again.
            this.canJump = true;
            this.jumpCount = 0;
            this.animator.SetBool("isJumping", false);
        }
    }
}
