using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_physics : MonoBehaviour
{

    private Rigidbody _rb;
    public GameObject playerObject;

	void Start()
    {
        _rb = playerObject.GetComponent<Rigidbody>();
	}
	
	void Update ()
    {
		
	}
}
