using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Fish2 : MonoBehaviour
{
    [SerializeField] private float moveRadius = 5f;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float heightVariation = 5f;
    [SerializeField] private float stopThreshold = 1f;
    [SerializeField] private float minX = -10;
    [SerializeField] private float maxX = 10;
    [SerializeField] private float minY = 0f;
    [SerializeField] private float maxY = 5f;
    [SerializeField] private float minZ = -10f;
    [SerializeField] private float maxZ = 10f;
    
    private Vector3 targetPosition;
    private bool caught; 


    private Rigidbody rb;
    private Vector3 targetPoint;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ChooseNewRandomPoint();
        caught = false;
        GameObject targetObject = GameObject.FindGameObjectWithTag("TargetPos");
        targetPosition = targetObject.transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (caught)
        {
            Caught();
            Debug.Log("Caught");
        }
        else
        {


            MoveToTarget();

            if (Vector3.Distance(transform.position, targetPoint) < stopThreshold)
            {
                ChooseNewRandomPoint();
            }
        }
    }

    void MoveToTarget()
    {
        Vector3 direction = (targetPoint - transform.position).normalized;
        rb.velocity = Vector3.Lerp(rb.velocity, direction * moveSpeed, Time.deltaTime * 2f);
        
    }

    void ChooseNewRandomPoint()
    {

        float newX = Random.Range(minX, maxX);
        float newY = Random.Range(minY, maxY);
        float newZ = Random.Range(minZ, maxZ);
        
        
        Vector3 randomDirection = new Vector3(
        Random.Range(-moveRadius, moveRadius),
        Random.Range(-heightVariation, heightVariation),
        Random.Range(-moveRadius, moveRadius));

        targetPoint = new Vector3(newX, newY, newZ);

    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            
            caught = true;
            
        }
    }

    void Caught()
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, targetPosition);
        if (distance > 0.1f)
        {
            rb.velocity = Vector3.Lerp(rb.velocity, direction * moveSpeed, Time.deltaTime);
            Debug.Log("is moving and caught");
            if (transform.position == targetPosition)
            {
                caught = false;
            }
        }
    }
}
