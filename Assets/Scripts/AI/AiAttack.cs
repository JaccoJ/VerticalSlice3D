using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AiAttack : MonoBehaviour {

    public GameObject kogelSpawn;
    public GameObject kogelPrefab;
    //public GameObject Player;
    // Use this for initialization
    [SerializeField]
    private float kogelspeed;
    public Transform player2;


   

    public void Shoot()
    {
        
        GameObject kogel;
        kogel = Instantiate(kogelPrefab, kogelSpawn.transform.position, kogelSpawn.transform.rotation) as GameObject;

        Rigidbody kogelRigidbody;
        kogelRigidbody = kogel.GetComponent<Rigidbody>();

        kogelRigidbody.AddForce((player2.position - transform.position) * kogelspeed );

        Destroy(kogel, 0.50f);
    }

}
