using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(CharacterStats))]
public class PlayerCombat : MonoBehaviour
{
    public Animator[] animator;

    public Transform attackPoint;
    public LayerMask enemyLayers;
    public float attackRange = 0.5f;

    public Transform firePoint;
    public GameObject projectile;
    public GameObject projectile2;

    public Transform[] SlashPoint;

    public float attackSpeed = 1f;
    public float attackCD = 0f;

    [SerializeField] private int countAttack;

    public bool attackCd;

    CharacterStats myStats;
    public bool isAttaking;

    public int deAnimat;
    public List<Slash> slashes;

    private GroundSlash groundSlashScript;

    public PlayerController playerController;

    public GameObject[] Inamici;
    public GameObject tinta;

    public PlayerManager playerManager;
    

    void Start()
    {

        Inamici = GameObject.FindGameObjectsWithTag("Inamic");
        //animator = GameObject.FindGameObjectsWithTag("Player").transform.GetChield(0).GetComponent<Animator>();
        myStats = GetComponent<CharacterStats>();
        countAttack = 0;
        deAnimat = PlayerPrefs.GetInt("PersonajActiv", 0);
        
    }


    void Update()
    {      
        attackCD -= Time.deltaTime;


        if (playerController.seMisca == false && Inamici.Length > 0)
            //AttackDistanta();
            VerificaStilAtack();
    }
    
    public void VerificaStilAtack()
    {
        //animator[deAnimat].SetBool("Merge", false);

        if (attackCD <= 0f)
        {

            Inamici = GameObject.FindGameObjectsWithTag("Inamic");
            var nearest = 400f;


            //Debug.Log("Deschide poarta");

            foreach (GameObject inamic in Inamici)
            {
                if (Vector3.Distance(transform.position, inamic.transform.position) < nearest)
                {
                    if (inamic.GetComponent<InamicStats>().mort == false)
                    {
                        nearest = Vector3.Distance(transform.position, inamic.transform.position);
                        tinta = inamic;
                        transform.LookAt(tinta.transform);




                        //Debug.Log("nearest " + nearest);

                        if (nearest >= 2.5f)
                        {
                            AttackDistanta();
                            //Debug.Log("Folosesc atac mele");
                        }
                        else
                        {
                            Attack();
                            //Debug.Log("Folosesc atac mele");
                        }
                    }
                    

                }
            }


            //Debug.Log("nearest " + nearest);

           


            attackCD = 1f / attackSpeed;

        }
    }

    public void GroudSlash()
    {
        var projectileGround = Instantiate(projectile2, firePoint.position, firePoint.rotation) as GameObject;

        groundSlashScript = projectileGround.GetComponent<GroundSlash>();
        projectileGround.GetComponent<Rigidbody>().velocity = transform.forward * groundSlashScript.speed;
    }

    public void AttackDistanta()
    {

        //Debug.DrawLine(transform.position, tinta.transform.position, Color.red);

        countAttack++;
        if (countAttack == 4)
        {
            countAttack = 1;
        }

        //Debug.Log(" Atacac distanta " + countAttack);

        if (countAttack == 1)
        {
            animator[deAnimat].SetTrigger("AtacDistanta");
        }
        if (countAttack == 2)
        {
            animator[deAnimat].SetTrigger("AtacDistanta2");
        }
        if (countAttack == 3)
        {
            animator[deAnimat].SetTrigger("AtacDistanta3");
        }
    }

    public void Attack()
    {
        countAttack++;
        if(countAttack==4)
        {
            countAttack = 1;
        }

        //Debug.Log(" Atacac mele " + countAttack);

        if (countAttack==1)
        {
            animator[deAnimat].SetTrigger("Attack");
        }
        if (countAttack == 2)
        {
            animator[deAnimat].SetTrigger("Attack2");
        }
        if (countAttack == 3)
        {
            animator[deAnimat].SetTrigger("Attack3");
        }


        Collider[] hitEnemies = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);

        foreach (Collider enemy in hitEnemies)
        {
            Debug.Log("Am lovit " + enemy.name);
            enemy.GetComponent<InamicStats>().TakeDamage(myStats.damage.GetValue());/////DE VERIFICAT
        }

    }
    public void Slashh()
    {
        var projectileGround = Instantiate(slashes[0].slahsObj, SlashPoint[0].position, SlashPoint[0].rotation) as GameObject;
        //slashes[0].slahsObj.SetActive(true);
    }

    public void Slashh2()
    {
        var projectileGround = Instantiate(slashes[0].slahsObj, SlashPoint[1].position, SlashPoint[1].rotation) as GameObject;
        //slashes[0].slahsObj.SetActive(true);
    }

    public void Slashh3()
    {
        var projectileGround = Instantiate(slashes[0].slahsObj, SlashPoint[2].position, SlashPoint[2].rotation) as GameObject;
        //slashes[0].slahsObj.SetActive(true);
    }
    public void Lanseaza()
    {
        Rigidbody rb = Instantiate(projectile, firePoint.position, firePoint.rotation).GetComponent<Rigidbody>();   //Quaternion.identity
        rb.AddForce(transform.forward * 32f, ForceMode.Impulse);
        rb.AddForce(transform.up * 0.5f, ForceMode.Impulse);
    }

    [System.Serializable]
    public class Slash
    {
        public GameObject slahsObj;

    }


    private void OnDrawGizmosSelected()
    {
        if(attackPoint == null)
        {
            return;
        }

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
