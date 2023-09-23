using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public float lookRadius = 10f;

    Transform target;
    NavMeshAgent agent;
    EnemyCombat combat;
    InamicStats inamicStats;
    public Animator animator;

    public LayerMask whatIsGroud, player;

    public float timer = 5f;


    //----------Patrulare-----//
    public Vector3 directie;
    public bool directieSetata;
    public float patrulareRange;


    void Start()
    {
        //target = PlayerManager.instance.player.transform;
        target = GameObject.Find("Personaj").transform;
        agent = GetComponent<NavMeshAgent>();
        combat = GetComponent<EnemyCombat>();
        //animator = GetComponent<Animator>();

        inamicStats = GetComponent<InamicStats>();

    }

    // Update is called once per frame
    void Update()
    {

        if (inamicStats.mort == false)
        {
            float distance = Vector3.Distance(target.position, transform.position);

            if (distance <= lookRadius)
            {
                agent.SetDestination(target.position);
                animator.SetBool("Merge", true);

                if (distance <= agent.stoppingDistance)
                {          
                    
                    agent.SetDestination(transform.position);

                    animator.SetBool("Merge", false);
                    CharacterStats targetStats = target.GetComponent<CharacterStats>();
                    if (targetStats != null)
                    {      
                            
                        combat.Attack2(targetStats);   
                          
                    }
                    FaceTarget();
                   
                }
               
            }
            if (distance > lookRadius)
            {
                Patruleaza();
            }
        }

        timer -= Time.deltaTime;


    }

    private void Patruleaza()
    {

        if (!directieSetata && timer < 0)
        {
            CautaDirectie();
            
        }

        if (directieSetata)
        {
            agent.SetDestination(directie);
            timer = Random.Range(2f, 6f);
        }

        Vector3 distanceToWalkPoint = transform.position - directie;

        if (distanceToWalkPoint.magnitude < 3f)
        {
            directieSetata = false;
            animator.SetBool("Merge", false);
        }
    }

    private void CautaDirectie()
    {

        float randomZ = Random.Range(-patrulareRange, patrulareRange);
        float randomX = Random.Range(-patrulareRange, patrulareRange);

        directie = new Vector3(transform.position.x + randomX, transform.position.y, transform.position.z + randomZ);

        if (Physics.Raycast(directie, -transform.up, 2f, whatIsGroud))
        {
            directieSetata = true;
            animator.SetBool("Merge", true);
        }


    }

    void FaceTarget()
    {
        Vector3 direction = (target.position - transform.position).normalized;
        Quaternion lookRotation = Quaternion.LookRotation(new Vector3(direction.x, 0, direction.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    IEnumerator Asteapta()
    {

        yield return new WaitForSeconds(5);
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
