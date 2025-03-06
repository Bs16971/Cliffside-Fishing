    using System;
using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;
using UnityEngine.AI;
using Random = UnityEngine.Random;

public class Fish1 : MonoBehaviour
{


    [SerializeField] private float moveRadius = 5f;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float heightVariation = 5f;
    [SerializeField] private float stopThreshold = 1f;
    [SerializeField] private float minX = -10;
    [SerializeField] private float maxX = 10;
    [SerializeField] private float minY = 2f;
    [SerializeField] private float maxY = 5f;
    [SerializeField] private float minZ = -10f;
    [SerializeField] private float maxZ = 10f;
    [SerializeField] private float detectionRange = 2f;
    private Vector3 boundaryMin = new Vector3(-8f, 2, -8f);
    private Vector3 boundaryMax = new Vector3(9f, 10f, 8f);
    private bool touchingWall;
   
    
    private Vector3 targetPosition;
    private bool caught;
    private Vector3 playerLocation;


    private Rigidbody rb;
    private Vector3 targetPoint;
    private GameObject player;
    private Vector3 velocity = Vector3.zero;
    private bool test;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        ChooseNewRandomPoint();
        caught = false;
        GameObject targetObject = GameObject.FindGameObjectWithTag("TargetPos");
        targetPosition = targetObject.transform.position;
       player = GameObject.FindGameObjectWithTag("Player");
       playerLocation = player.transform.position;
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        playerLocation = player.transform.position;
        float distanceToPlayer = Vector3.Distance(transform.position, playerLocation);
        
        if (distanceToPlayer < detectionRange && !caught && touchingWall == false)
        {
              RunAway();
              ChooseNewRandomPoint();
              
            
        } else if (caught)
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
        }else if (other.CompareTag("Wall"))
        {
            touchingWall = true;
        }
    }

    void Caught()
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, targetPosition);
        if (distance > 0.1f)
        {
            rb.velocity = Vector3.Lerp(rb.velocity, 2f * direction, Time.deltaTime);
            Debug.Log("is moving and caught");
            if (transform.position == targetPosition)
            {
                caught = false;
            }
        }
    }

    void RunAway()
    {
        Vector3 directionAway = (transform.position - player.transform.position).normalized;
        Vector3 newPosition = transform.position + directionAway * moveSpeed * Time.deltaTime;
        test = true;
        if (!caught)
        {
            
            if (IsInsideBoundary(newPosition) && !touchingWall)
            {
                Debug.Log(IsInsideBoundary(newPosition));
                transform.position = Vector3.Lerp(transform.position, newPosition, 10f);

            }
            else if (transform.position.y < maxY && touchingWall)
            {
                rb.velocity = new Vector3(0, moveSpeed, 0);
            }
        }
    }

   
    
    

    bool IsInsideBoundary(Vector3 position)
    {
        return position.x >= boundaryMin.x && position.x <= boundaryMax.x
        && position.y >= boundaryMin.y && position.y <= boundaryMax.y
        && position.z >= boundaryMin.z && position.z <= boundaryMax.z;
    }
    
    
}

 

