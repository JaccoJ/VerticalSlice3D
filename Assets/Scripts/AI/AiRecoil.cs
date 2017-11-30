using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiRecoil : MonoBehaviour {

    private Rigidbody rb;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void OnCollisionEnter(Collision col)
    {


        if (col.gameObject.tag == "Player")
        {
            print("hit");
            rb.AddForce(new Vector3(-6,0,0) );
        }
    }
}
