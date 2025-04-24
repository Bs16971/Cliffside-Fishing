using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D;
using Random = UnityEngine.Random;

public class SphereGoes : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject sphere;
    private Vector3 destination;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            StartCoroutine(WaitAndDoSomething());
           
        }
    }
    IEnumerator WaitAndDoSomething()
    {
        
        yield return new WaitForSeconds(1.7f); // Waits for 1 second
        destination = new Vector3(Random.Range(-10, 10), -2, 40);
        while (Vector3.Distance(sphere.transform.position, destination) > 0.01f)
        {
            sphere.transform.position = Vector3.MoveTowards(transform.position, destination, 40f * Time.deltaTime);
            yield return null;
        }

        sphere.transform.position = destination;
    }

    
    
}
