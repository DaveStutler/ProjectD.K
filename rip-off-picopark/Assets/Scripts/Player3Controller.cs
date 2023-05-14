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
        if (Input.GetKeyDown(KeyCode.Keypad8))
        {
            this.jump.Execute(this.gameObject);
        }
        if (Input.GetKeyDown(KeyCode.Keypad6))
        {
            this.right.Execute(this.gameObject);
        }
        if (Input.GetKeyDown(KeyCode.Keypad4))
        {
            this.left.Execute(this.gameObject);
        }
    }
}
