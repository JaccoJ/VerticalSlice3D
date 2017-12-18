using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAttack : MonoBehaviour {

    public float speed = 10;
    public GameObject kogelSpawn;
    public GameObject kogelPrefab;
    //public GameObject Player;
    // Use this for initialization
    [SerializeField]
    private float kogelspeed = 5;
    public Transform player2;
    


	public void Awake()
	{
    
	}




    public void Shoot()
    {
        
        GameObject kogel;
        kogel = Instantiate(kogelPrefab, kogelSpawn.transform.position, kogelSpawn.transform.rotation) as GameObject;

        Rigidbody kogelRigidbody;
        kogelRigidbody = kogel.GetComponent<Rigidbody>();

        kogelRigidbody.AddForce((player2.position - transform.position) * kogelspeed );

        Destroy(kogel, 1.0f);    
	}

    public void Melee()
    {
        transform.Rotate(Vector3.up * Time.deltaTime * speed);
    }
}
