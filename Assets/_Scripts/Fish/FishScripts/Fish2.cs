using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

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
        PlayerPrefs.SetInt("Chance", 5);
        PlayerPrefs.SetInt("DidItBreak", 1);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (caught)
        {
            Caught();
            
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
        LookWayMoving();
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
        if(other.CompareTag("TargetPos") )
        {
            SceneManager.LoadScene("_Scenes/CaughtScene");
            Destroy(gameObject);
           
           
        }
        if (other.CompareTag("Player"))
        {
            if (!caught)
            {

                StartCoroutine(CheckEscapeBeforeCaught());
                caught = true;
            } 

        }
    }

    void Caught()
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, targetPosition);
        if (distance > 0.1f)
        {
            rb.velocity = Vector3.Lerp(rb.velocity, direction * 50f, Time.deltaTime);
            if (transform.position == targetPosition)
            {
                caught = false;
            }
        }
    }

    void LookWayMoving()
    {
        Vector3 direction = rb.velocity.normalized;
        if (caught == true && direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(-direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);
        }
        if (direction != Vector3.zero)
        {
            Quaternion targetRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);
            // transform.forward = direction;
        }
    }
    public bool GetCaught()
    {
        return caught;
    }
    
    IEnumerator CheckEscapeBeforeCaught()
    {
        yield return new WaitForSeconds(0.25f); // ⏳ Wait before deciding

        int chance = PlayerPrefs.GetInt("Chance", 5);
        int roll = Random.Range(0, 10);
        
        

        if (roll >= chance)
        {
            
           
            caught = false;
            StartCoroutine(TemporarySpeedBoost(2));
            ChooseNewRandomPoint();
            PlayerPrefs.SetInt("DidItBreak", 1);// Resume swimming
        }
        else
        {
            PlayerPrefs.SetInt("DidItBreak", 0);
        } 
        // else: fish continues heading toward TargetPos
    }

    IEnumerator TemporarySpeedBoost(float duration)
    {
        moveSpeed = 30f;
        yield return new WaitForSeconds(duration);
        moveSpeed = 5f;
    }


}
