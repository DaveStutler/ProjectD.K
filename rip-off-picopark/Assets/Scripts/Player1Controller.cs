using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class Player1Controller : MonoBehaviour
{
    [SerializeField] private GameObject respawnPoint;
    private IPlayerController right;
    private IPlayerController left;
    private IPlayerController jump;
    private IPlayerController special1;
    private IPlayerController special2;
    private IPlayerController horizontalStop;
    private bool canJump = true;
    private bool rightPressed = false;
    private bool leftPressed = false;
    private bool canDash = false;
    public int keyCounter = 0;
    private Animator animator;


    // Start is called before the first frame update
    void Start()
    {
        this.jump = ScriptableObject.CreateInstance<MoveCharacterJump>();
        this.right = ScriptableObject.CreateInstance<MoveCharacterRight>();
        this.left = ScriptableObject.CreateInstance<MoveCharacterLeft>();
        this.special1 = ScriptableObject.CreateInstance<MoveCharacterDashLeft>();
        this.special2 = ScriptableObject.CreateInstance<MoveCharacterDashRight>();
        this.horizontalStop = ScriptableObject.CreateInstance<StopHorizontalMovement>();
        this.animator = this.gameObject.GetComponent<Animator>();
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
        if (Input.GetKeyDown(KeyCode.W) && this.canJump)
        {
            this.jump.Execute(this.gameObject);
            // Since the person has jumped they are no longer in contact with the floor
            // so they will no longer be able to jump until they gain contact again.
            this.canJump = false;
            this.animator.SetBool("isJumping", true);
        }
        if (Input.GetKeyDown(KeyCode.D) || this.rightPressed)
        {
            if (!canDash)
            {
                this.right.Execute(this.gameObject);
                this.rightPressed = true;
            }
            else if (canDash)
            {
                if (Input.GetKeyDown(KeyCode.D))
                {
                    this.special2.Execute(this.gameObject);
                    canDash = false;
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.A) || this.leftPressed)
        {
            if (!canDash)
            {
                this.left.Execute(this.gameObject);
                this.leftPressed = true;
            }
            else if (canDash)
            {
                if (Input.GetKeyDown(KeyCode.A))
                {
                    this.special1.Execute(this.gameObject);
                    canDash = false;
                }
            }

        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            canDash = true;

        }
        this.animator.SetFloat("Speed", Mathf.Abs(this.gameObject.GetComponent<Rigidbody2D>().velocity.x/5.0f));

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Player")
        {
            // Know the player has collided with the floor meaning they can jump again.
            this.canJump = true;
            this.animator.SetBool("isJumping", false);
        }
        if (collision.gameObject.tag == "Key" && collision.gameObject.GetComponent<KeyController>().collected == false)
        {
            this.keyCounter += 1;
        }
        if (collision.gameObject.tag == "Death")
        {
            var respawnPosition = this.respawnPoint.transform.position;
            this.gameObject.transform.position = respawnPosition;
        }

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "CheckPoint")
        {
            this.respawnPoint = collision.gameObject;
        }
    }
}