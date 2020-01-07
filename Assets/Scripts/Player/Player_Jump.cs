using UnityEngine;
using System.Collections;

public class Player_Jump : MonoBehaviour {

    public float jumpForce = 300.0f;

    public Transform GroundCheck;
    public float groundRadius = 0.2f;
    public bool grounded = false;
    public LayerMask whatIsGround;
    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    //This code makes the player jump when the space key is pressed
    //First check if the player's rigidbody is connected to the ground, if that is the case you can jump
    void Update(){
        bool jump = Input.GetButtonDown("Jump");

        grounded = Physics2D.OverlapCircle(GroundCheck.position, groundRadius, whatIsGround);

        if (GameControlScript.health > 0)
        {
            if (jump && grounded)
            {
                GetComponent<Rigidbody2D>().AddForce(Vector3.up * jumpForce);
                anim.SetBool("jump", true);
            }
            else
            {
                anim.SetBool("jump", false);
            }
        }
    }
}