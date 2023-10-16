using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class friendly : MonoBehaviour
{
    Animator anim;
    HelperScript helper;

    // Start is called before the first frame update
    public void Start()
    {
        helper = gameObject.AddComponent<HelperScript>();

    }

    // Update is called once per frame
    public void Update()
    {
        helper.DoRayCollisionCheck();

    }
}
