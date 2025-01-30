using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Fish : MonoBehaviour
{
    // Start is called before the first frame update
    private NavMeshAgent _agent;
    private bool isWalking = false;
    private int agentX;
    private int agentY;
    private int agentZ;
    
    void Start()
    {
        _agent = GetComponent<NavMeshAgent>();
        _agent.isStopped = true;
    }

    // Update is called once per frame
    void Update()
    {
       
        if (_agent.isStopped)
        {
            
            agentX = Random.Range(-20, 20);
            agentY = Random.Range(0, 10);
            agentZ = Random.Range(-20, 20);
            _agent.SetDestination(new Vector3(agentX, agentY, agentZ));
            
        }
    }

   
}
