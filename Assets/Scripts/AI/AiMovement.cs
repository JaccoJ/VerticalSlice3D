using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AiMovement : MonoBehaviour
{
     
    public Transform Player;
    public bool retreat;
    [SerializeField]
    private int MoveSpeed = 4;
    private int MaxDist = 4;
    [SerializeField]
    private float MinDist = 1;
    private AiAttack _enemyshoot;
    private float _fireRate = 1.50f;
    private float _nextFire = 0.0f;
    private Rigidbody rb;
    private Vector3 retreatPoint;
    private float speed;
    
   

    void Start()
    {
       rb = GetComponent<Rigidbody>();
    }
    
    void Awake()
    {
        speed = MoveSpeed * Time.deltaTime;
        _enemyshoot = GetComponent<AiAttack>();
    }


    void Update()
    {
       // retreatPoint =  new Vector3(0, 0, 0);
        
        Player = GameObject.FindWithTag("Player").transform;
        transform.LookAt(Player);

        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
        {

            transform.position += transform.forward * MoveSpeed * Time.deltaTime;
            retreat = false;
            print("go forward");
          
        }
        if (Vector3.Distance(transform.position, Player.position) <= MinDist)
        {
            retreat = true;

           /* if (retreat)
            {
                print("retreat");
                transform.position += Vector3.MoveTowards(transform.position, retreatPoint, speed);
                
            }*/
            if (Time.time > _nextFire)
            {
                _nextFire = Time.time + _fireRate;
                _enemyshoot.Shoot();
            }
        }
    }
}