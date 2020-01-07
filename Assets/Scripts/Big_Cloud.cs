using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Big_Cloud : MonoBehaviour
{
    public float speed = 10.0f;

    private void Update()
    {
        GetComponent<Rigidbody2D>().velocity = new Vector3(speed, GetComponent<Rigidbody2D>().velocity.y);
    }
    
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            GameControlScript.health = 0;
        }
    }
}
