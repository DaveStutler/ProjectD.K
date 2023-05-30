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
    private Animator animator;

    // Start is called before the first frame update
    void Start()
    {
        this.jump = ScriptableObject.CreateInstance<MoveCharacterJump>();
        this.right = ScriptableObject.CreateInstance<MoveCharacterRight>();
        this.left = ScriptableObject.CreateInstance<MoveCharacterLeft>();
        this.special = ScriptableObject.CreateInstance<SizeUp>();
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
            this.animator.SetBool("isJumping", true); // set the animator to jump
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
        if (Input.GetKey(KeyCode.Q))
        {
            this.special.Execute(this.gameObject);
        }
        this.animator.SetFloat("speed", Mathf.Abs(this.gameObject.GetComponent<Rigidbody2D>().velocity.x/5.0f));
    }

}
