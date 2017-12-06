using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour : MonoBehaviour
{
    [SerializeField]
    private GameObject _target;
    [SerializeField]
    private GameObject _player;

    private Transform _cameraTransform;

    private bool _LookingAt;

    private float _distancePlayerCamera;
    
   

    private Vector3 _crosspointLookAt;


	void Start ()
    {
       
        _cameraTransform = Camera.main.transform;
        _LookingAt = false;
        
        
	}
	
	
	void Update ()
    {
        
        if (Input.GetKeyDown(KeyCode.F))
        {
            _LookingAt = !_LookingAt;
        }

        if (_LookingAt == true)
        {

            _cameraTransform.LookAt(_target.transform);
            Vector3 CameraForward = Camera.main.transform.forward;
            Vector3 _distancePlayerEnemy = _target.transform.position - _player.transform.position;
            float angle = Vector3.Angle(CameraForward, _distancePlayerEnemy);
        }
        else
        {
            _cameraTransform.LookAt(_player.transform);
        }

       
    }
}
