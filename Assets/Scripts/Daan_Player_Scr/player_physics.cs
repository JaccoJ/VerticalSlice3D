using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_physics : MonoBehaviour
{

    private Rigidbody _rb;
    public GameObject playerObject;
    private Vector3 _forcePos;
    private Vector3 _currentDir;

	void Start()
    {
        _rb = gameObject.GetComponent<Rigidbody>();
        _currentDir = _rb.rotation.eulerAngles;
	}
	
	void Update()
    {
        _rb.AddForce(_forcePos);
        _rb.rotation.SetLookRotation(_currentDir);
	}

    public void SetForcePos(Vector3 set)
    {
        _forcePos = _rb.velocity;
        _forcePos += set;
    }
    public void SetForceDir(Vector3 set)
    {
        _currentDir += set;
    }
}
