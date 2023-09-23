using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(InamicStats))]
public class EnemyCombat : MonoBehaviour
{
    public Animator animator;

    public Transform attackPoint;
    public LayerMask enemyLayers;

    public int attackDamage = 40;
    public float attackRange = 0.5f;

    public float attackRate = 2f;

    public float attackSpeed = 1f;
    private float attackCD = 0f;

    float nextAttackTime = 0f;

    public bool cdAttack;

    public GameObject proiectil;
    public Transform firePoint;

    InamicStats inamicStats;

    void Start()
    {
        inamicStats = GetComponent<InamicStats>();
    }


    void Update()
    {
        if (Time.time >= nextAttackTime)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                //Attack();
                cdAttack = false;
                nextAttackTime = Time.time + 1f / attackRate;
                Debug.Log(nextAttackTime);
            }

        }

        attackCD -= Time.deltaTime;

    }


    public void AttackDistanta(CharacterStats targetStats)
    {
        if (attackCD <= 0f)
        {
            animator.SetTrigger("Attack");

            Rigidbody rb = Instantiate(proiectil, firePoint.position, Quaternion.identity).GetComponent<Rigidbody>();
            
            rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
            rb.AddForce(transform.up* 1f, ForceMode.Impulse);

            targetStats.TakeDamage(inamicStats.damage.GetValue());


            //Collider[] hitPlayer = Physics.OverlapSphere(attackPoint.position, attackRange, playerLayer);

            //foreach (Collider player in hitPlayer)
            // {
            //     Debug.Log("Am lovit " + player.name + " provocand " + myStats.damage.GetValue());
            //     player.GetComponent<Player>().TakeDamage(myStats.damage.GetValue());

            // }
            attackCD = 1f / attackSpeed;


        }

    }


    public void Attack2(CharacterStats targetStats)
    {
        if (attackCD <= 0f)
        {
            animator.SetTrigger("Attack");

            targetStats.TakeDamage(inamicStats.damage.GetValue());

            attackCD = 1f / attackSpeed;


        }
    }

    /*public void Attack()
    {
        if (attackCD <= 0f)
        {
            Debug.Log("Inamicul Ataca ");
            animator.SetTrigger("Attack");


            Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

            foreach (Collider enemy in hitEnemies)
            {
                Debug.Log("Am lovit " + enemy.name);
                //enemy.GetComponent<Enemy>().TakeDamage(myStats.damage.GetValue());
            }

            attackCD = 1f / attackSpeed;
            Debug.Log("Inamicul Ataca 3");
        }

        //cdAttack = true;
    }*/


    private void OnDrawGizmosSelected()
    {
        if (attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
