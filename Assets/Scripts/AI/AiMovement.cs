using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AiMovement : MonoBehaviour
{

    public Transform target;
    public bool fire;
    public float MinAttackDist;
    public Transform Player;
    public bool retreat;
    [SerializeField]
    private int MoveSpeed = 4;

    [SerializeField]
    private float MinDist = 1;
    private AiAttack _enemyattack;
    private float _fireRate = 2.00f;
    private float _nextFire = 0.0f;
    private Rigidbody rb;
    private Vector3 retreatPoint;




    private IEnumerator coroutine;

    void Start()
    {
        print("starting: " + Time.time);

        coroutine = WaitAndPrint(2.0f);
        StartCoroutine(coroutine);

        print("before WaitAndPrint finishes: " + Time.time);

    }
    
    void Awake()
    {

        Player = GameObject.FindWithTag("Player").transform;
        _enemyattack = GetComponent<AiAttack>();
		rb = GetComponent<Rigidbody>();
    }

	void Update()
	{
        print(MoveSpeed);

        if (Vector3.Distance(transform.position, Player.position) >= MinDist)
		{
			Move();
		}

		else if (Vector3.Distance(transform.position, Player.position) <= MinDist)
		{
			Shoots();
		}

        if (fire == true)
		{
			MoveToPoint();
		}   
	}


	void Shoots()
	{
        fire = true;
		
		/*if (Time.time > _nextFire )
		{
			_nextFire = Time.time + _fireRate;
			_enemyattack.Shoot();
            transform.LookAt(Player);
        }*/
	}

	void Move()
	{
       
		transform.LookAt(Player);
        fire = false;
        MoveSpeed = 3;
		transform.position += transform.forward * MoveSpeed * Time.deltaTime;
		print("go forward");
	}

	void MoveToPoint()
	{
		MoveSpeed = 2;

		float step = MoveSpeed * Time.deltaTime;
		transform.position = Vector3.MoveTowards(transform.position, target.position, step);

		transform.LookAt(target);

	}
    private IEnumerator WaitAndPrint(float waitTime)
    {
        while (true)
        {
            
            yield return new WaitForSeconds(waitTime);
            transform.LookAt(Player);
            _enemyattack.Shoot();
            MoveSpeed = 0;
        }
    }

}   