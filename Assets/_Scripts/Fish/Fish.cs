using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Fish : MonoBehaviour
{
    // Start is called before the first frame update
    private NavMeshAgent _agent;
    private bool isMoving = false;
    private float agentX;
    private float agentY;
    private float agentZ;
    private bool caught = false;
    private Vector3 targetPosition;
    private float speed = 0.5f;
    
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        GameObject targetObject = GameObject.FindGameObjectWithTag("Player");

        
        targetPosition = targetObject.transform.position;

        caught = false;
    }

    // Update is called once per frame
    void Update()
    {

        if (caught)
        {
            MovePlayer2();
        }
        else
        {
            if (isMoving == false)
            {
                agentX = Random.Range(-5, 5);
                agentY = Random.Range(1, 8);
                agentZ = Random.Range(-5, 5);
                _agent.SetDestination(new Vector3(agentX, agentY, agentZ));

                isMoving = true;


            }
            else if (isMoving)
            {
                if (transform.position.x == agentX && transform.position.y == agentY && transform.position.z == agentZ)
                {
                    isMoving = false;
                    Debug.Log("This is working");
                }
            }
        }
    }
    void MovePlayer2()
    {
        Vector3 direction = (targetPosition - transform.position).normalized;
        float distance = Vector3.Distance(transform.position, targetPosition);
        if (distance > 0.1f)
        {
            
            if (direction == Vector3.zero)
            {
                Debug.Log("Direction is Zer0!");
            }
            Debug.Log("Speed" + speed);
            Debug.Log("We are moving");
            _agent.Move(direction * 2f * Time.deltaTime);
            if (transform.position == targetPosition)
            {
                caught = false;
            }
        }
    }

   
}
