using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_mesh : MonoBehaviour
{
    public MeshCollider cl;
    public GameObject playerObject;
    private player _player; 

	void Start()
    {
        _player = playerObject.GetComponent<player>();
	}
}
