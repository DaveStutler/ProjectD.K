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
    private Animator animator;

    void Start()
    {
        this.jump = ScriptableObject.CreateInstance<MoveCharacterJump>();
        this.right = ScriptableObject.CreateInstance<MoveCharacterRight>();
        this.left = ScriptableObject.CreateInstance<MoveCharacterLeft>();
        this.special = ScriptableObject.CreateInstance<SizeUp>();
        this.horizontalStop = ScriptableObject.CreateInstance<StopHorizontalMovement>();
        this.animator = this.gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Keypad6))
        {
            this.rightPressed = false;
            this.horizontalStop.Execute(this.gameObject);
        }
        if (Input.GetKeyUp(KeyCode.Keypad4))
        {
            this.leftPressed = false;
            this.horizontalStop.Execute(this.gameObject);
        }
        if (Input.GetKeyDown(KeyCode.Keypad8) && this.canJump)
        {
            this.jump.Execute(this.gameObject);
            this.canJump = false;
            this.animator.SetBool("isJumping", true); // set the animator to jump
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
        if (Input.GetKey(KeyCode.Keypad7))
        {
            this.special.Execute(this.gameObject);
        }
        this.animator.SetFloat("speed", Mathf.Abs(this.gameObject.GetComponent<Rigidbody2D>().velocity.x/5.0f));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Player")
        {
            this.canJump = true;
            this.animator.SetBool("isJumping", false);
        }
    }
}
