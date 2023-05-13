using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class Player1Controller : MonoBehaviour
{
    private IPlayerController right;
    private IPlayerController left;
    private IPlayerController jump;
    private IPlayerController special;

    // Start is called before the first frame update
    void Start()
    {
        //this.gameObject.AddComponent<CaptainMotivateCommand>();
        // this.fire1 = gameObject.AddComponent<CaptainMotivateCommand>();
        this.jump = ScriptableObject.CreateInstance<MoveCharacterJump>();
        this.right = ScriptableObject.CreateInstance<MoveCharacterRight>();
        this.left = ScriptableObject.CreateInstance<MoveCharacterLeft>();
        this.special = ScriptableObject.CreateInstance<MoveCharacterLeft>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            this.jump.Execute(this.gameObject);
        }
        if(Input.GetAxis("Horizontal") > 0.01)
        {
            this.right.Execute(this.gameObject);
        }
        if(Input.GetAxis("Horizontal") < -0.01)
        {
            this.left.Execute(this.gameObject);
        }
    }
}
