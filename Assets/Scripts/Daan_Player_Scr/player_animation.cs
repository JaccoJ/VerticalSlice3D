using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_animation : MonoBehaviour
{
    //Attached to the gameobject: characters from the parent: models.

    private float _animationTime;
    private Animator _animator;
    private Animation _currentAnimation;
    private player _player;
    private bool runAnim;

    public GameObject playerObject;

	void Start() {
        _animator = gameObject.GetComponent<Animator>();
        _player = playerObject.GetComponent<player>();
        runAnim = false;
    }
	
	void Update() {
        if (this._animator.GetCurrentAnimatorStateInfo(0).IsName("idle"))
        {
            Debug.Log("im playing idle animation");
        }
        

        //when attacking
        if (Input.GetKeyDown(KeyCode.L))
        {
            _animator.SetBool("running", true);

//            _animator.SetTrigger("first_attack");
        }
        //when running
        //when nothing

    }
    public void PlayAnimation(string ani)
    {
        switch (ani)
        {
            case "run":
                runAnim = !runAnim;
                _animator.SetBool("running",runAnim);
                break;
            case "idle":
                _animator.SetTrigger("setIdle");
                break;
            case "attack1":
                _animator.SetTrigger("first_attack");
                break;
            case "attack2":
                _animator.SetTrigger("second_attack");
                break;
            case "attack3":
                _animator.SetTrigger("third_attack");
                break;
            default:
                break;
        }
    }
}
