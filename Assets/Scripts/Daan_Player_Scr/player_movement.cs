using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
    //Connected to the player Gameobject
    public enum DirStateHor { right, left, none };
    public enum DirStateVer { up, down, none };

    private DirStateHor _horDir = DirStateHor.none;
    private DirStateVer _verDir = DirStateVer.none;

    public GameObject physicsObject;
    public GameObject managerObject;
    public GameObject playerObject;

    private player _player;
    private player_physics _physics;
    private Inputmanager _inputs;


    public string currentInpPos = "none";
    public string currentInpDir = "none";

    public float moveMultiplier;
    public float rotationMultiplier;

    private Vector3 _conceptVectorDir;
    private Vector3 _conceptVectorPos;

    private bool _oppositeDir;



	void Start()
    {
        this._player = playerObject.GetComponent<player>();
        this._physics = physicsObject.GetComponent<player_physics>();
        this._inputs = managerObject.GetComponent<Inputmanager>();
	}
	
	void Update()
    {
        //Check what the input manager has to say.
        this.currentInpPos = _player.CheckInputMovement();

        //Preparing the vector3 values to be sended to the physics script.
        this._conceptVectorDir.y = _inputs.GetXRot() * rotationMultiplier * Time.deltaTime;
        this._conceptVectorPos = StraveMovement(this.currentInpPos);
        

        //Setting the vector3 values to the coresponding physics script.
        this._physics.SetForceDir(this._conceptVectorDir);
        this._physics.SetForcePos(this._conceptVectorPos);
	}  

    //Any input that makes the player move.
    public bool AnyInput()
    {
        if(_inputs.Down() || _inputs.Up() || _inputs.Left() || _inputs.Right())
        {
            Debug.Log("Inputted: true");
            return true;
        }
        else
        {
            Debug.Log("Inputted: false");
            return false;
        }
    }

    /*
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
*/
    public Vector3 StraveMovement(string dir)
    {
        switch (dir)
        {
            case "up":
                _player.SetState(player.PlayerState.walking);
                return Vector3.forward * this.moveMultiplier * Time.deltaTime;
            case "down":
                _player.SetState(player.PlayerState.walking);
                return Vector3.back * this.moveMultiplier * Time.deltaTime;
            case "left":
                _player.SetState(player.PlayerState.walking);
                return Vector3.left * this.moveMultiplier * Time.deltaTime;
            case "right":
                _player.SetState(player.PlayerState.walking);
                return Vector3.right * this.moveMultiplier * Time.deltaTime;
            default:
                Debug.Log("FrontalMovement: No value in parameter");
                _player.SetState(player.PlayerState.idle);
                return new Vector3(0,0);
        }
    }
}
