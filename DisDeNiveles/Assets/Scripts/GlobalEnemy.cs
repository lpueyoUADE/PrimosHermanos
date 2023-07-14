using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class GlobalEnemy : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;

    private Transform player;

    [SerializeField] LayerMask ground, target;

    private Vector3 patrolPoint;

    private bool patrolPointSet;

    [SerializeField] float patrolRange;

    [SerializeField] float viewRange;
    [SerializeField] float detectionRange;

    private bool playerInSight;

    private bool playerNear;

    public float totalTime = 50f;
    public float currentTime = 0f;

    private void Awake()
    {
        player = GameObject.Find("Player 1").GetComponent<Transform>();
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        playerNear = Physics.CheckSphere(transform.position, detectionRange, target);
        playerInSight = Physics.Raycast(transform.position, transform.forward * viewRange, 9);

        if (!playerNear) { Patrolling(); }
        else if (playerNear) { Chasing(); }
    }

    private void Patrolling()
    {
        if (!patrolPointSet)
        {
            GetPatrolPoint();
        }

        if (patrolPointSet)
        {
            agent.SetDestination(patrolPoint);

        }

        Vector3 distanceToPatrolPoint = transform.position - patrolPoint;

        //Walkpoint Reached
        if (distanceToPatrolPoint.magnitude < 5 || Timer() == true)
        {
            patrolPointSet = false;
            currentTime = 0;
        }

    }

    private void GetPatrolPoint()
    {
        float randomZ = Random.Range(-patrolRange, patrolRange);
        float randomX = Random.Range(-patrolRange, patrolRange);

        patrolPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);
        NavMeshHit hit;
        if (NavMesh.SamplePosition(patrolPoint, out hit, Mathf.Infinity, NavMesh.AllAreas))
        {
            agent.SetDestination(hit.position);
            patrolPointSet = true;
        }

    }

    private void Chasing()
    {
        agent.SetDestination(player.position);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, detectionRange);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * viewRange);
    }

    private bool Timer()
    {
        currentTime += Time.deltaTime;

        if (currentTime >= totalTime)
        {
            return true;
        }
        return false;

    }

    //private bool LookingAtWall()
    //{

    //}




}
