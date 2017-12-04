using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    //Connected to the player Gameobject


    public GameObject physicsObject;
    public GameObject managerObject;
    public GameObject playerObject;

    private player _player;
    private player_physics _physics;
    private Inputmanager inputs;


    public string currentInpPos = "none";
    public string currentInpDir = "none";

    public float frontalMultiplier;
    public float rotationMultiplier;

    private Vector3 _conceptVectorDir;
    private Vector3 _conceptVectorPos;



	void Start()
    {
        this._player = playerObject.GetComponent<player>();
        this._physics = physicsObject.GetComponent<player_physics>();
        this.inputs = managerObject.GetComponent<Inputmanager>();
	}
	
	void Update()
    {
        //Check what the input manager has to say.
        this.currentInpPos = CheckInputFrontal();
        this.currentInpDir = CheckInputDirection();

        //Preparing the vector3 values to be sended to the physics script.
        this._conceptVectorDir = DirectionSwitch(this.currentInpDir);
        this._conceptVectorPos = FrontalMovement(this.currentInpPos);

        //Setting the vector3 values to the coresponding physics script.
        _physics.SetForceDir(this._conceptVectorDir);
        _physics.SetForcePos(this._conceptVectorPos);
	}

    public string CheckInputFrontal()
    {
        string res = null;
        if (inputs.Up())
        {
            res = "up";
        }
        if (inputs.Down())
        {
            res = "down";
        }

        if (res != null)
        {
            Debug.Log(res);
            return res;
        }
        else
        {
            _player.SetState(player.PlayerState.idle);
            Debug.Log("CheckInputFrontal: none inputted");
            return "none";
        }

    }

    public string CheckInputDirection()
    {
        string res = null;
        if (inputs.Right())
        {
            res = "right";
        }
        if (inputs.Left())
        {
            res = "left";
        }
        if(res != null)
        {
            Debug.Log(res);
            return res;
        }
        else
        {
            Debug.Log("CheckInputDirection: none inputted");
            return "none";
        }
    }

    public Vector3 FrontalMovement(string dir)
    {
        switch (dir)
        {
            case "up":
                _player.SetState(player.PlayerState.walking);
                return Vector3.forward * this.frontalMultiplier * Time.deltaTime;
            case "down":
                _player.SetState(player.PlayerState.walking);
                return Vector3.back * this.frontalMultiplier * Time.deltaTime;
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
                return new Vector3(0,-1) * this.rotationMultiplier * Time.deltaTime;
            case "right":
                return new Vector3(0,1) * this.rotationMultiplier * Time.deltaTime;                
            case "none":
                return new Vector3(0,0);
            default:
                Debug.Log("DirectionSwitch: No value in parameter");
                return new Vector3(0,0,0);                
        }
    }
}
