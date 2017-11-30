using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_mesh : MonoBehaviour
{
    private MeshCollider meshCol;
    public GameObject playerObject;
    private player _player; 

	void Start()
    {
        _player = playerObject.GetComponent<player>();
        meshCol = gameObject.GetComponent<MeshCollider>();
	}

    public MeshCollider GetCol()
    {
        return meshCol;
    }
}
