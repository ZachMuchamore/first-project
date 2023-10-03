using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Playerscripts : MonoBehaviour

{
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
        sr = GetComponent<SpriteRenderer>();
        print("start"); 
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateDirection();
        LayerMask groundLayer;
        sr.flipX = false;
        anim.SetBool("player_run", false);
        anim.SetBool("player_jump", false);
        int speed = 5;
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
            gameObject.transform.localScale = new Vector3(-6, 6, 6);
            anim.SetBool("player_run", true);
            print("player pressed left");
            transform.position = new Vector2(transform.position.x - (speed * Time.deltaTime), transform.position.y);
        }

        if ( Input.GetKey("d") == true ) // move right 
        {
            gameObject.transform.localScale = new Vector3(6, 6, 6);
            anim.SetBool("player_run", true);
            print("player pressed right");
            transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
        }
        if (Input.GetKeyDown("space") == true) 
        {
            anim.SetBool("player_jump", true);
            rb.AddForce(new Vector3(0, 10, 0), ForceMode2D.Impulse);
        }

        if( rb.velocity.y != 0 )
        {
            anim.SetBool("player_jump", true);
        }
        if(Input.GetKeyDown("f"))
        {
            anim.SetTrigger("player_attack");
        }

        bool isGrounded()
        {
            if (Physics2D.BoxCast(transform.position, boxSize, 0, -transform.up, castDistance, groundLayer))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        void OnDrawgizmos()
        {
            Gizmos.DrawWireCube(transform.position-transform.up * castDistance, boxSize);
        }
        void UpdateDirection()
        {
            if (Input.GetAxis("Horizontal") < 0)
            {
                sr.flipX = false;
                lastDir = false;
            }
            else if (Input.GetAxis("Horizontal") > 0)
            {
                sr.flipX = true;
                lastDir = true;
            }
            else sr.flipX = lastDir;
        }
    }

    private void UpdateDirection()
    {
        throw new NotImplementedException();
    }
}


