using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class test : MonoBehaviour
{

    private IEnumerator coroutine;

    void Start()
    {
        print("starting: " + Time.time);
        
        coroutine = WaitAndPrint(2.0f);
        StartCoroutine(coroutine);

        print("before WaitAndPrint finishes: " + Time.time);
    }

    private IEnumerator WaitAndPrint(float waitTime)
    {
        while (true)
        {
            
            yield return new WaitForSeconds(waitTime);
            print("WaitAndPrint " + Time.time); 
        }
    }
}
