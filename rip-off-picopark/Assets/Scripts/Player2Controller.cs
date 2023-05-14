using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Player;

public class Player2Controller : MonoBehaviour
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
        if (Input.GetKeyDown(KeyCode.I))
        {
            this.jump.Execute(this.gameObject);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            this.right.Execute(this.gameObject);
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            this.left.Execute(this.gameObject);
        }
    }
}
