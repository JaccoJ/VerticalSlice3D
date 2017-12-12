using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject _target;
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private GameObject _PlayerFollow;

    private Transform _cameraTransform;

    private bool _lookingAt;
    private bool _angleReached;
    private Vector3 _cameraOffset = new Vector3(0f,1.75f,-4f);

   


	void Start ()
    {
        _cameraTransform = this.transform;
        _angleReached = false;
        _lookingAt = false;
	}
	
	
	void Update ()
    {
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            _lookingAt = !_lookingAt;
        }

        if (_lookingAt == true)
        {
            _cameraTransform.position = new Vector3(_PlayerFollow.transform.position.x, _PlayerFollow.transform.position.y + _cameraOffset.y, _PlayerFollow.transform.position.z + _cameraOffset.z);
            _cameraTransform.LookAt(_target.transform);
            
            Vector3 CameraForward = Camera.main.transform.forward;
            Vector3 disCamPlayer = _cameraTransform.position - _player.transform.position;
            Vector3 _disPlayerEnemy = _target.transform.position - _player.transform.position;
            Vector3 _CameraOffset = new Vector3(_PlayerFollow.transform.position.x - _cameraTransform.position.x, _PlayerFollow.transform.position.y+ _cameraOffset.y, _PlayerFollow.transform.position.z + _cameraOffset.z);
            float angle = Vector3.Angle(CameraForward, _disPlayerEnemy);

            Debug.Log(angle);
            if (angle >= 20)
            {
                _angleReached = true;
             //_cameraTransform.position = new Vector3()   
            }else
            {
                _angleReached = false;
            }

            if(_angleReached == true)
            {
                _cameraTransform.position = _PlayerFollow.transform.position - _CameraOffset;
            }
        }
        else
        {
            _cameraTransform.position = _player.transform.position + _cameraOffset;
            _cameraTransform.LookAt(_player.transform);
            
        }
        
       
    }
}
