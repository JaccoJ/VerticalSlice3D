using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour {

    //Connected to the player Gameobject


    public string tag;
    public float speed;
    public enum PlayerState {idle, walking, attack};
    private PlayerState _state;
    private player_movement _movement;
    private player_animation _animation;

    public GameObject animationObject;
    public GameObject managerObject;

    private Inputmanager _inputs;

    void Start()
    {
        _animation = animationObject.GetComponent<player_animation>();
        _movement = gameObject.GetComponent<player_movement>();
        _inputs = managerObject.GetComponent<Inputmanager>();

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
                if (_movement.AnyInput())
                {
                    _state = PlayerState.walking;
                }
                break;
            case PlayerState.attack:
                break;
            case PlayerState.walking:
                if (!_movement.AnyInput())
                {
                    _state = PlayerState.idle;
                }

                break;
            default:
                Debug.Log("No state stated");
                break;
        }
    }

    private void StateAction()
    {
        switch (this._state)
        {
            case PlayerState.idle:
                _animation.PlayAnimation("idle");
                break;
            case PlayerState.attack:
                break;
            case PlayerState.walking:
                _animation.PlayAnimation("run");
                break;
            default:
                Debug.Log("No state to act for");
                break;
        }
    }

    public string CheckInputMovement()
    {
        string res = null;
        if (_inputs.Up())
        {
            res = "up";
        }
        if (_inputs.Down())
        {
            res = "down";
        }
        if (_inputs.Right())
        {
            res = "right";
        }
        if (_inputs.Left())
        {
            res = "left";
        }

        if (res != null)
        {
            //Debug.Log(res);
            return res;
        }
        else
        {
            SetState(player.PlayerState.idle);
            //Debug.Log("CheckInputFrontal: none inputted");
            return "none";
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
