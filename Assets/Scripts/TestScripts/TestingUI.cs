using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestingUI : MonoBehaviour
{
    [SerializeField]
    private GameObject _lockOn;

    private bool checkLock = true;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            LockOn();
        }
    }

    void LockOn()
    {
        if (checkLock == true)
        {
            _lockOn.SetActive(false);
            checkLock = false;
        }
        else
        {
            _lockOn.SetActive(true);
            checkLock = true;
        }
    //    _lockOn.SetActive(!_lockOn.activeSelf);
    }
}
