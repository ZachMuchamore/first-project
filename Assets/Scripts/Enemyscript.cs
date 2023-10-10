using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private float distance;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        speed = 2f;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // distance = Vector2.Distance(transform.position, player.transform.position);
        //Vector2 direction = player.transform.position - transform.forward;
        distance = player.transform.position.x - transform.position.x;

        print(distance);
        if (distance < 0)
        {
            transform.transform.localScale = new Vector3(-1.25f, 1.25f, 1.25f);
            print("flipped");
        }
        else
        {
            transform.transform.localScale = new Vector3(1.25f, 1.25f, 1.25f);
        }
        Debug.Log("dist=" + distance);

        if ( distance > 2  || distance <-2 )
        {
            transform.position = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
            anim.SetBool("running",true);
            
        }
        else
        {
            anim.SetBool("running", false);
        }
    }
}