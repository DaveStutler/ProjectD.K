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
            // Case for disabling more than one jump.
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            this.right.Execute(this.gameObject);
        }
        if(Input.GetKeyDown(KeyCode.A))
        {
            this.left.Execute(this.gameObject);
        }

        var xPos = this.gameObject.transform.position.x;
        Debug.Log(xPos);
    }
}