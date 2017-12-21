using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_physics : MonoBehaviour
{
    //Connected to the physics Gameobject as a child in the player Gameobject

    private Rigidbody _rb;
    private player_movement _movement;
    private Inputmanager _inputs;

    public GameObject playerObject;
    public GameObject managerObject;

    private Vector3 _forcePos;
    private Vector3 _currentDir;

	void Start()
    {
        this._rb = gameObject.GetComponent<Rigidbody>();
        this._movement = playerObject.GetComponent<player_movement>();
        this._inputs = managerObject.GetComponent<Inputmanager>();
        //this._currentDir = _rb.rotation.eulerAngles;

    }
	
	void Update()
    {
        playerObject.transform.Translate(this._forcePos);
        playerObject.transform.Rotate(this._currentDir);
        this._forcePos = new Vector3();
    }

    public void SetForcePos(Vector3 set)
    {
        this._forcePos = set;
    }

    public void SetForceDir(Vector3 set)
    {
        this._currentDir.y = set.y;
    }
    public void SetForceDir(float set)
    {
        this._currentDir.y += set;
    }
}
