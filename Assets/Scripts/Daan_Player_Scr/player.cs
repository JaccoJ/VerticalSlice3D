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
    private float attackBegTiming;
    private bool failedAtt;

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

    //The conditions to change from states
    private void StateSwitch()
    {
        switch (this._state)
        {
            case PlayerState.idle:
                if (_movement.AnyInput())
                {
                    _state = PlayerState.walking;
                }
                if (_inputs.ClickOne())
                {
                    _state = PlayerState.attack;
                    attackBegTiming = Time.time;
                }
                break;
            case PlayerState.attack:
                if (failedAtt)
                {
                    if (_movement.AnyInput())
                    {
                        _state = PlayerState.walking;
                    }
                    else
                    {
                        _state = PlayerState.idle;
                    }
                }
                
                break;
            case PlayerState.walking:
                if (!_movement.AnyInput())
                {
                    _state = PlayerState.idle;
                }
                if (_inputs.ClickOne())
                {
                    _state = PlayerState.attack;
                    attackBegTiming = Time.time;
                }
                break;
            default:
                Debug.Log("No state stated");
                break;
        }
    }

    //The general action of the states
    private void StateAction()
    {
        switch (this._state)
        {
            case PlayerState.idle:
                _animation.PlayAnimation("idle");
                break;
            case PlayerState.attack:
                if (!_animation.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("attack1"))
                {
                    _animation.PlayAnimation("attack1");
                }
                if (_inputs.ClickOne() && ((Time.time - attackBegTiming) > 1.5f && Time.time - attackBegTiming < 1.8f))
                {

                    attackBegTiming = Time.time;
                    if (!_animation.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("attack2"))
                    {
                        _animation.PlayAnimation("attack2");
                    }
                    if (_inputs.ClickOne() && ((Time.time - attackBegTiming) > 1.5f && Time.time - attackBegTiming < 1.8f))
                    {
                        if (!_animation.GetComponent<Animator>().GetCurrentAnimatorStateInfo(0).IsName("attack3"))
                        {
                            _animation.PlayAnimation("attack3");
                        }
                    }
                }
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
