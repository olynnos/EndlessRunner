using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
	public GameObject player;
    public float walkSpeed = 10.0f;

    private Animator anim;

    private void Start()
    {
        anim = GetComponent<Animator>();
    }

    void FixedUpdate()
    {
        float move = Input.GetAxis("Horizontal");

		if (GameControlScript.health > 0){

        	//Check if you press left or right and move that direction
        	if (move < 0){
        	    //When you press the left button move to the left
        	    GetComponent<Rigidbody2D>().velocity = new Vector3(move * walkSpeed, GetComponent<Rigidbody2D>().velocity.y);

        	    var rot = transform.rotation;
        	    rot.x = 0;
        	    rot.y = 180;
         	   transform.rotation = rot;
        	}

        	if (move > 0){
         	   //When you press the right button move to the right
         	   GetComponent<Rigidbody2D>().velocity = new Vector3(move * walkSpeed, GetComponent<Rigidbody2D>().velocity.y);

         	   var rot = transform.rotation;
         	   rot.x = 0;
         	   rot.y = 0;
          	   transform.rotation = rot;
        	}
		}

        //Change the animation to running when the player moves
        if (move == 0)
        {
            anim.SetBool("isRunning", false);
        } else {
            anim.SetBool("isRunning", true);
        }

		if (GameControlScript.health == 0){
			anim.SetBool("death", true);
			GetComponent<Rigidbody2D>().velocity = new Vector3(0, -10, 0);
		}

		if (player.transform.position.y < -10)
		{
		GameControlScript.health = 0;
		}
    }
}
