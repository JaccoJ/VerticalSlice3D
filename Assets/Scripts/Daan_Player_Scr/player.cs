using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    public string tag;
    public float speed;
    public GameObject scriptMovement;
    public enum PlayerState {idle, walking, attack};
    private PlayerState _state;
    private player_movement _movement;


    void Start()
    {
        _movement = scriptMovement.GetComponent<player_movement>();
        this.tag = gameObject.tag;
		if(speed == null) { speed = 1.4f; }
        if(tag == null || tag == "Untagged") {tag = "player"; }
	}
	
	void Update()
    {
        StateSwitch();
        StateAction();
	}

    private void StateSwitch()
    {
        switch (this._state)
        {
            case PlayerState.idle:
                /*if (_movement.currentDir == "up" ||
                    _movement.currentDir == "down" ||
                    _movement.currentDir == "right" ||
                    _movement.currentDir == "left")
                {
                    
                }*/
                break;
            case PlayerState.attack:
                break;
            case PlayerState.walking:
                break;
            default:
                break;
        }
    }

    private void StateAction()
    {
        switch (this._state)
        {
            case PlayerState.idle:
                break;
            case PlayerState.attack:
                break;
            case PlayerState.walking:
                break;
            default:
                break;
        }
    }

    public PlayerState GetState()
    {
        return this._state;
    }
    public void SetState(PlayerState state)
    {
        this._state = state;
    }

    public bool CheckWithin(float start, float end, float x)
    {
        if (start <= x && end >= x)
        {
            Debug.Log("CheckWithin: inside bounds");
            return true;
        }
        else if (start >= x || end <= x)
        {
            Debug.Log("CheckWithin: out of bounds");
            return false;
        }
        else
        {
            Debug.Log("CheckWithin: none were true");
            return false;
        }
    }
}
