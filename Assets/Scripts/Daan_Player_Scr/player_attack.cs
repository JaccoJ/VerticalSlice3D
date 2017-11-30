using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_attack : MonoBehaviour
{
    public GameObject sword;
    private bool _active;
    private MeshCollider _swordCollider;
	void Start()
    {
        _swordCollider = sword.GetComponent<MeshCollider>();
	}
	
	void Update()
    {
		
	}

    //Check if boolean _active is equal to turn on/off the Collider
    private void ChangeCollider(bool eval)
    {
        this._swordCollider.enabled = eval;
    }

    public bool GetActive()
    {
        return this._active;
    }
    public void SetActive(bool val)
    {
        this._active = val;
    }
}
