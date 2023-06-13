using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class Player2Controller : MonoBehaviour
{
    [SerializeField] private GameObject respawnPoint;
    [SerializeField] private AudioSource footSteps;
    private IPlayerController right;
    private IPlayerController left;
    private IPlayerController jump;
    private IPlayerController special;
    private IPlayerController horizontalStop;
    private bool canJump = true;
    private bool rightPressed = false;
    private bool leftPressed = false;
    public int keyCounter = 0;
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
        if (Input.GetKeyUp(KeyCode.L))
        {
            footSteps.enabled = false;
            this.rightPressed = false;
            // Want to stop horizontal movement.
            this.horizontalStop.Execute(this.gameObject);
        }
        if (Input.GetKeyUp(KeyCode.J))
        {
            footSteps.enabled = false;
            this.leftPressed = false;
            // Want to stop horizontal movement.
            this.horizontalStop.Execute(this.gameObject);
        }
        if (Input.GetKeyDown(KeyCode.I) && this.canJump)
        {
            this.jump.Execute(this.gameObject);
            // Since the person has jumped they are no longer in contact with the floor
            // so they will no longer be able to jump until they gain contact again.
            this.canJump = false;
            this.animator.SetBool("isJumping", true); // set the animator to jump
        }
        if (Input.GetKeyDown(KeyCode.L) || this.rightPressed)
        {
            footSteps.enabled = true;
            this.right.Execute(this.gameObject);
            this.rightPressed = true;
        }
        if (Input.GetKeyDown(KeyCode.J) || this.leftPressed)
        {
            footSteps.enabled = true;
            this.left.Execute(this.gameObject);
            this.leftPressed = true;
        }
        if (Input.GetKey(KeyCode.K))
        {
            this.special.Execute(this.gameObject);
        }
        this.animator.SetFloat("Speed", Mathf.Abs(this.gameObject.GetComponent<Rigidbody2D>().velocity.x/5.0f));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // Debug.Log("colliding " + collision.gameObject.tag);
        if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Player")
        {
            this.canJump = true;
            this.animator.SetBool("isJumping", false);
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
