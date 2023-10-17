using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class friendly : MonoBehaviour
{
    public float speed;
    Animator anim;
    HelperScript helper;
    public bool grounded;
    public GameObject pointA;
    public GameObject pointB;  
    private Rigidbody2D rb;
    private Transform currentPoint;
    // Start is called before the first frame update
    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentPoint = pointB.transform;
        anim = GetComponent<Animator>();   
        anim.SetBool("running", true);
        helper = gameObject.AddComponent<HelperScript>();

    }

    // Update is called once per frame
    public void Update()
    {
        Vector2 point = currentPoint.position - transform.position;
        if(currentPoint == pointB.transform)
        {
            rb.velocity = new Vector2(speed, 0);
        }
        else
        {
            rb.velocity = new Vector2(-speed, 0);
        }

        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointB.transform)
        {
            flip();
            currentPoint = pointA.transform;
        }
        if (Vector2.Distance(transform.position, currentPoint.position) < 0.5f && currentPoint == pointA.transform)
        {
            flip();
            currentPoint = pointB.transform;
        }
        grounded = helper.DoRayCollisionCheck();


    }

    private void flip()
    {
        Vector3 localScale = transform.localScale;
        localScale.x *= -1;
        transform.localScale = localScale;
    }
    

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(pointA.transform.position, 0.5f);
        Gizmos.DrawWireSphere(pointB.transform.position, 0.5f);
        Gizmos.DrawLine(pointA.transform.position, pointB.transform.position);
    }
}
