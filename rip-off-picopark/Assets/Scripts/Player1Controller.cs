using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using Player.Command;
public class Player1Controller : MonoBehaviour
{
    private IPlayerCommand ability;
    private IPlayerCommand jump;
    private IPlayerCommand right;
    private IPlayerCommand left;


    // Start is called before the first frame update
    void Start()
    {
        //this.gameObject.AddComponent<CaptainMotivateCommand>();
        this.ability = gameObject.AddComponent<>();
        this.jump = ScriptableObject.CreateInstance<>();
        this.right = ScriptableObject.CreateInstance<MoveCharacterRight>();
        this.left = ScriptableObject.CreateInstance<MoveCharacterLeft>();

        //this.booty.text = "Booty";
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetButtonDown("Fire1"))
        {
            this.ability.Execute(this.gameObject);
        }
        if (Input.GetAxis("Vertical") > 0.01)
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

        //var animator = this.gameObject.GetComponent<Animator>();
        //animator.SetFloat("Velocity", Mathf.Abs(this.gameObject.GetComponent<Rigidbody2D>().velocity.x/5.0f));
    }
}
