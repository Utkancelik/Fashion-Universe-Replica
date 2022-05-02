
using UnityEngine;
using UnityEngine.AI;

public class CustomerAI : MonoBehaviour
{
    private NavMeshAgent agent;

    public Transform reyon;

    public LayerMask whatIsGround, whatIsReyon;

    // public float health;

    //Patroling
    public Vector3 walkPoint;
    bool walkPointSet;
    public float walkPointRange;

    //Attacking
    //public float timeBetweenAttacks;
    //bool alreadyAttacked;
    //public GameObject projectile;

    //States
    public float sightRange, attackRange;
    public bool reyonInSightRange, reyonInAttackRange;

    private void Awake()
    {
        reyon = GameObject.FindGameObjectWithTag("reyon").transform;
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        //Check for sight and attack range
        reyonInSightRange = Physics.CheckSphere(transform.position, sightRange, whatIsReyon);
        reyonInAttackRange = Physics.CheckSphere(transform.position, attackRange, whatIsReyon);

        if (!reyonInSightRange && !reyonInAttackRange) Patroling();
        if (reyonInSightRange && !reyonInAttackRange) ChasePlayer();
        if (reyonInAttackRange && reyonInSightRange) AttackPlayer();
    }

    private void Patroling()
    {
        if (!walkPointSet) SearchWalkPoint();

        if (walkPointSet)
            agent.SetDestination(walkPoint);

        Vector3 distanceToWalkPoint = transform.position - walkPoint;

        //Walkpoint reached
        if (distanceToWalkPoint.magnitude < 1f)
            walkPointSet = false;
    }
    private void SearchWalkPoint()
    {
        //Calculate random point in range
        float randomZ = Random.Range(-walkPointRange, walkPointRange);
        float randomX = Random.Range(-walkPointRange, walkPointRange);

        walkPoint = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(walkPoint, -transform.up, 2f, whatIsGround))
            walkPointSet = true;
    }

    private void ChasePlayer()
    {
        agent.SetDestination(reyon.position);
    }

    private void AttackPlayer()
    {
        //Make sure enemy doesn't move
        agent.SetDestination(transform.position);

        transform.LookAt(reyon);

        //if (!alreadyAttacked)
        {
            //eþyayý alýcak
            //reyona eriþip altýndaki
            ///Attack code here
            //Rigidbody rb = Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<Rigidbody>();
            //rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            //rb.AddForce(transform.up * 8f, ForceMode.Impulse);
            ///End of attack code

            //alreadyAttacked = true;
            //Invoke(nameof(ResetAttack), timeBetweenAttacks);
        }
    }
    private void ResetAttack()
    {
        //alreadyAttacked = false;
    }

    public void TakeDamage(int damage)
    {
       // health -= damage;

        //if (health <= 0) Invoke(nameof(DestroyEnemy), 0.5f);
    }
    private void DestroyEnemy()
    {
        Destroy(gameObject);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, sightRange);
    }
}
