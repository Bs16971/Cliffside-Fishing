using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;

public class Flying : MonoBehaviour
{

    [SerializeField] private Transform player;
    
    [SerializeField] private GameObject projectilePrefab;
    [SerializeField] private Transform projectileSpawnPoint;


    [SerializeField] private float moveSpeed = 20f;
    [SerializeField] private float rotationSpeed = 7.5f;
    [SerializeField] private float circleDuration = 5f;
    [SerializeField] private float waypointDistanceThreshold = 2f;


    private Transform currentWaypointTarget;
    private Transform[] waypoints;

    private void FaceTarget(Vector3 targetPos)
    {
        Vector3 dir = targetPos - transform.position;
        if (dir.sqrMagnitude < 0.0001f) return;
        
        dir.Normalize();
        transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(dir), Time.deltaTime * rotationSpeed);
    }

   

   
    private void PickRandomWaypoint()
    {
        if (waypoints != null && waypoints.Length > 0)
        {
            currentWaypointTarget = waypoints[Random.Range(0, waypoints.Length)];
        }
    }

    private bool ReachedWaypoint()
    {
        if (!currentWaypointTarget) return false;
        return Vector3.Distance(transform.position, currentWaypointTarget.position) < waypointDistanceThreshold;
    }

    private void MoveTowardsTarger(Vector3 targetPos)
    {
        Vector3 dir = targetPos - transform.position;
        if (dir.sqrMagnitude < 0.0001f) return;
        
        dir.Normalize();
        transform.rotation = Quaternion.Slerp(
            transform.rotation, Quaternion.LookRotation(dir),
            Time.deltaTime * rotationSpeed);
        transform.position = Vector3.MoveTowards(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }

    private float DistanceToPlayer()
    {
        if (!player) return float.MaxValue;
        return Vector3.Distance(transform.position, player.position);
    }

    private IEnumerator CircleState(float duration)
    {
        float timer = 0f;

        while (timer < duration)
        {
            if(currentWaypointTarget)
                MoveTowardsTarger(currentWaypointTarget.position);
            if (ReachedWaypoint()) PickRandomWaypoint();

            yield return null;
        }
    }

    private IEnumerator AttackState(float duration)
    {
        
        float timer = 0f;
        float shootTimer = 0f;

        while (timer < duration)
        {
            timer += Time.deltaTime;
            shootTimer += Time.deltaTime;
            
            FaceTarget(player.position);

            if (DistanceToPlayer() > 0f)
            {
                MoveTowardsTarger(player.position);
            }

            if (shootTimer >= 0.5f)
            {
                shootTimer = 0f;
                
            }

            yield return null;
        }

    }

    private IEnumerator StateMachine()
    {
        while (true)
        {
            yield return StartCoroutine(CircleState(circleDuration));
            yield return StartCoroutine(AttackState(circleDuration));
        }
    }
    // Start is called before the first frame update
    void Start()
    {
      

        if (waypoints == null || waypoints.Length == 0) return;

        StartCoroutine(StateMachine());
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
