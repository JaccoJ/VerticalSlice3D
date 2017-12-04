using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_physics : MonoBehaviour
{
    //Connected to the physics Gameobject as a child in the player Gameobject

    private Rigidbody _rb;
    private player_movement _movement;
    private GameObject player_gameobject;

    public GameObject playerObject;

    private Vector3 _forcePos;
    private Vector3 _currentDir;

	void Start()
    {
        this._rb = gameObject.GetComponent<Rigidbody>();
        //this._currentDir = _rb.rotation.eulerAngles;
        player_gameobject = this.gameObject.GetComponentInParent<GameObject>();

    }
	
	void Update()
    {
        this._rb.AddForce(this._forcePos);
        player_gameobject.transform.Rotate(this._currentDir);
        
    }

    public void SetForcePos(Vector3 set)
    {
        this._forcePos.z = set.z;
    }

    public void SetForceDir(Vector3 set)
    {
        this._currentDir.y = set.y;
    }
}
