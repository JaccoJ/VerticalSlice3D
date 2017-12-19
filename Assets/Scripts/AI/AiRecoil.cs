using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiRecoil : MonoBehaviour {

    public float knockbackSpeed = 5f;
    private Rigidbody rb;
    public Transform player;
    
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }


    void OnCollisionEnter(Collision col)
    {


        if (col.gameObject.tag == "Player")
        {
            print("hit");

            rb.AddForce((player.position + transform.position) * knockbackSpeed , ForceMode.Impulse);
            
        }
    }
}
