using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyAi2 : MonoBehaviour
{
    public int Health;

    public NavMeshAgent Agent;
    public Transform Player;
    public LayerMask whatIsPlayer, whatIsGround;

    public Vector3 walkpoint;
    bool walkpointset;
    public float walkpointrange;

    public float timeBetweenAttacks;
    bool alreadyAttacked;

    public float SightRange, AttackRange;
    public bool PlayerInSightRange, PlayerInAttackRange;

    public GameObject Sword;
    public Sword_Script SS;

    // Start is called before the first frame update
    void Start()
    {
        Player = GameObject.Find("PlayerBody").transform;
        Agent = GetComponent<NavMeshAgent>();
        SS = GameObject.FindObjectOfType(typeof(Sword_Script)) as Sword_Script;
    }

    void Update()
    {
        PlayerInSightRange = Physics.CheckSphere(transform.position, SightRange, whatIsPlayer);
        PlayerInAttackRange = Physics.CheckSphere(transform.position, AttackRange, whatIsPlayer);

        if (!PlayerInAttackRange && !PlayerInSightRange) patroling();
        if (PlayerInSightRange && !PlayerInAttackRange) ChasePlayer();
        if (PlayerInSightRange && PlayerInAttackRange) AttackPlayer();
    }
    public void TakeDamage(int Damage)
    {
        Health -= Damage;
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }
    
    private void patroling()
    {
        if (!walkpointset) SearchWalkPoint();

        if (walkpointset)
            Agent.SetDestination(walkpoint);

        Vector3 distanceToWalkPoint = transform.position - walkpoint;

        if(distanceToWalkPoint.magnitude < 0.5f)
            walkpointset = false;
    }
    
    private void SearchWalkPoint()
    {
        float RandomZ = Random.Range(-walkpointrange, walkpointrange);
        float RandomX = Random.Range(-walkpointrange, walkpointrange);

        walkpoint = new Vector3(transform.position.x + RandomX, transform.position.y, transform.position.z + RandomZ);

        if (Physics.Raycast(walkpoint, -transform.up, 2f, whatIsGround))
            walkpointset = true;
    }

    private void ChasePlayer()
    {
        Agent.SetDestination(Player.position);
    }

    private void AttackPlayer()
    {
        Agent.SetDestination(transform.position);

        transform.LookAt(Player);

        if(!alreadyAttacked)
        {
            SS.SwordAttack();
            Invoke("ResetAttack", timeBetweenAttacks);
        }
    }

    private void ResetAttack()
    {
        alreadyAttacked = false;
    }
}
