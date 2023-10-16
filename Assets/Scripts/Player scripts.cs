using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Playerscripts : MonoBehaviour

{
    
    HelperScript helper;
    Animator anim;
    SpriteRenderer sr;
    // Start is called before the first frame update
    Rigidbody2D rb;
    public Vector2 boxSize;
    bool grounded;
    public float castDistance;
    private bool lastDir;


    void Start()
    {
        helper = gameObject.AddComponent<HelperScript>();
        sr = GetComponent<SpriteRenderer>();
        print("start"); 
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        anim.SetBool("player_run", false);
        anim.SetBool("player_jump", false);
        int speed = 5;
        if( Input.GetKey("x"))
        {
            helper.FlipObject(true);
        }
        if (Input.GetKey("e") == true) // press e to start sprinting 
        {
            print("player increasing speed");
            speed = speed + 5;
        }
        if (Input.GetKey("q") == true) // press q to move slowly 
        {
            print(" player slowing down");
            speed = speed - 3;
        }
        if ( Input.GetKey("a") == true ) // move left
        {
            gameObject.transform.localScale = new Vector3(-2, 2, 2);
            anim.SetBool("player_run", true);
            print("player pressed left");
            transform.position = new Vector2(transform.position.x - (speed * Time.deltaTime), transform.position.y);
            
        }

        if ( Input.GetKey("d") == true ) // move right 
        {
            gameObject.transform.localScale = new Vector3(2, 2, 2);
            anim.SetBool("player_run", true);
            print("player pressed right");
            transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
            

        }
        grounded = helper.DoRayCollisionCheck();
        if (Input.GetKeyDown("space") == true && grounded == true) 
        {
            anim.SetBool("player_jump", true);
            rb.AddForce(new Vector3(0, 5, 0), ForceMode2D.Impulse);
        }

        if( rb.velocity.y != 0 )
        {
            anim.SetBool("player_jump", true);
        }
        if(Input.GetKeyDown("f"))
        {
            anim.SetTrigger("player_attack");
        }
    }
}