using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class Player3Controller : MonoBehaviour
{
    [SerializeField] private GameObject respawnPoint;
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
    public int keyCounter = 0;

    // Start is called before the first frame update
    void Start()
    {
        //this.gameObject.AddComponent<CaptainMotivateCommand>();
        // this.fire1 = gameObject.AddComponent<CaptainMotivateCommand>();
        this.jump = ScriptableObject.CreateInstance<MoveCharacterJump>();
        this.right = ScriptableObject.CreateInstance<MoveCharacterRight>();
        this.left = ScriptableObject.CreateInstance<MoveCharacterLeft>();
        this.horizontalStop = ScriptableObject.CreateInstance<StopHorizontalMovement>();
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

            }
            else if (canDoubleJump && jumpCount < 2)
            {
                this.jump.Execute(this.gameObject);
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
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Floor" || collision.gameObject.tag == "Player")
        {
            // Know the player has collided with the floor meaning they can jump again.
            this.canJump = true;
            this.jumpCount = 0;
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
