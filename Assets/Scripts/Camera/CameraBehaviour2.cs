using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBehaviour2 : MonoBehaviour {

    [SerializeField]
    private GameObject _target;
    [SerializeField]
    private GameObject _player;
    [SerializeField]
    private GameObject _PlayerFollow;
    // Use this for initialization
    private Transform _cameraTransform;
    private int _cameraOffset = 3;

    void Start () {
        _cameraTransform = this.transform;
    }
	
	// Update is called once per frame
	void Update () {
        Vector3 distPlayerFolP = _player.transform.position - _PlayerFollow.transform.position;
	}
}
