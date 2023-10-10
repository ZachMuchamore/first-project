using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperScript : MonoBehaviour
{
    // Start is called before the first frame update
    LayerMask groundLayerMask;
    public void Start()
    {
        groundLayerMask = LayerMask.GetMask("Ground");
    }

    public void DoRayCollisionCheck()
    {
        float raylength = 0.5f;
        RaycastHit2D hit;
        hit = Physics2D.Raycast(transform.position, -Vector2.up, raylength, groundLayerMask);
        Color hitColor = Color.white;
        if (hit.collider != null)
        {
            print("Player has collided with Ground layer");
            hitColor = Color.green;
        }
        Debug.DrawRay(transform.position, -Vector2.up * raylength, hitColor);
    }

    public void FlipObject(bool flip)
    {

        if (flip == true)
        {
            
            transform.transform.localScale = new Vector3(-3, 3, 3);
        }
        else
        {
            transform.transform.localScale = new Vector3(3, 3, 3);

        }
        // Update is called once per frame

    }

}