using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMoveScript : MonoBehaviour
{
    private InputManager inputManager;
    [SerializeField]
    private float movementSpeed = 5;

    [SerializeField]
    private Transform _testPlayer;


    void Start()
    {
       
        if (!(inputManager = this.GetComponent<InputManager>()))
        {
            inputManager = this.gameObject.AddComponent<InputManager>();
        }
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            this.transform.Rotate(0, 1, 0);
        }
        Vector3 movement = new Vector3();
        if (inputManager.Up())
        {
            movement += this.transform.forward;
        }
        if (inputManager.Down())
        {
            movement -= this.transform.forward;
        }
        if (inputManager.Right())
        {
            movement += this.transform.right;
        }
        if (inputManager.Left())
        {
            movement -= this.transform.right;
        }
        movement.Normalize();
        this.transform.position += (movement * Time.deltaTime * movementSpeed);
    }

    
}
