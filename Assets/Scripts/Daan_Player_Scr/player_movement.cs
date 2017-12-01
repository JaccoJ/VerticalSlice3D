using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    public GameObject physicsObject;
    public GameObject managerObject;
    public GameObject playerObject;

    private player _player;
    private player_physics _physics;
    private Inputmanager inputs;

    public string currentDir = "none";
    private Vector3 _conceptVectorDir;
    private Vector3 _conceptVectorPos;
    public Vector3 newVectorDir;
    public Vector3 newVectorPos;



	void Start()
    {
        this._player = playerObject.GetComponent<player>();
        this._physics = physicsObject.GetComponent<player_physics>();
        this.inputs = managerObject.GetComponent<Inputmanager>();
	}
	
	void Update()
    {
        this.currentDir = CheckInput();
        this._conceptVectorDir = DirectionSwitch(this.currentDir);
	}

    public string CheckInput()
    {
        if (inputs.Left())
        {
            return "left";
        }
        else if (inputs.Up())
        {
            return "up";
        }
        else if (inputs.Right())
        {
            return "right";
        }
        else if (inputs.Down())
        {
            return "down";
        }
        else
        {
            Debug.Log("CheckDirection: none inputted");
            return "none";
        }
    }

    public Vector3 FrontalMovement(string dir)
    {
        switch (dir)
        {
            case "up":
                _player.SetState(player.PlayerState.walking);
                return Vector3.forward;
            case "down":
                _player.SetState(player.PlayerState.walking);
                return Vector3.back;
            default:
                Debug.Log("FrontalMovement: No value in parameter");
                return new Vector3(0,0);
        }
    }

    public Vector3 DirectionSwitch(string dir)
    {
        switch (dir)
        {
            case "left":
                return new Vector3(0,-1);
            case "right":
                return new Vector3(0,1);                
            case "none":
                return new Vector3(0,0);
            default:
                _player.SetState(player.PlayerState.idle);
                Debug.Log("DirectionSwitch: No value in parameter");
                return new Vector3(0,0,0);                
        }
    }
}
