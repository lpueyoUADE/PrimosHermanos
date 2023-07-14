using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class BasicEnemy : MonoBehaviour
{
    [SerializeField] NavMeshAgent agent;

    private Transform player;
    [SerializeField] GameObject deathSound;

    [SerializeField] LayerMask ground, target;

    private Vector3 patrolPoint;

    private bool patrolPointSet;

    [SerializeField] float patrolRange;

    [SerializeField] float viewRange;
    [SerializeField] float detectionRange;

    private bool playerInSight;
    private bool playerInSight2;

    private bool playerNear;

    public float totalTime = 50f;
    public float currentTime = 0f;

    [SerializeField] Transform checkPoint;

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
        playerInSight2 = Physics.Raycast(transform.position, -transform.forward * viewRange, 9);

        if (!GetComponent<FieldOfVision>().CanSeePlayer() && !GetComponent<FieldOfVisionBack>().CanSeePlayer() && !playerNear && !playerInSight && !playerInSight2) { Patrolling();}
        else if (GetComponent<FieldOfVision>().CanSeePlayer() || GetComponent<FieldOfVisionBack>().CanSeePlayer() || !playerNear || !playerInSight || !playerInSight2) {Chasing();}
    }

    private void Patrolling()
    {
        if (!patrolPointSet)
        {
            GetPatrolPoint();
        }
        
        if (patrolPointSet)
        {
            agent.speed = 5;
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
        agent.speed = 10;
        //if (GetComponent<FieldOfVisionBack>().CanSeePlayer())
        //{
        //    transform.rotation = Quaternion.Euler(0f, 180f, 0f);
        //}
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawSphere(transform.position, detectionRange);
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, transform.forward * viewRange);
        Gizmos.DrawRay(transform.position, -transform.forward * viewRange);
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

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            deathSound.GetComponent<AudioSource>().Play();
            player.transform.position = checkPoint.position;
        }
    }

}
