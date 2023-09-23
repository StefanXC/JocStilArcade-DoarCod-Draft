using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InamicStats : MonoBehaviour
{
    public float maxHP = 100;
    public float curentHP { get; private set; }

    [SerializeField]
    float HPregen = 0;

    public Stat damage;
    public Stat armura;

    public HPbarScript hpBar;

    public Animator animator;

    public bool mort = false;

    public GameObject moare;

    public bool isAttacking = false;

    private void Awake()
    {
        curentHP = maxHP;
        hpBar.SetMaxHP((int)maxHP);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
        /*if (curentHP <= maxHP - HPregen && curentHP > 0) HP regen
        {
            RegenHP();
        }*/
    }

    /*public void RegenHP()  functia HP regen
    {
        curentHP += HPregen * Time.deltaTime;
        hpBar.SetHP((int)curentHP);
    }*/

    public void TakeDamage(int damage)
    {
        damage -= armura.GetValue();
        damage = Mathf.Clamp(damage, 1, int.MaxValue);

        curentHP -= damage;
        Debug.Log(transform.name + " take " + damage + " damage ");

        hpBar.SetHP((int)curentHP);
        if (curentHP <= 0)
        {
            Die();
            animator.SetTrigger("Mort");
        }
        else if (isAttacking == false)
        {
            animator.SetTrigger("Lovit");
        }
    }

    public virtual void Die()
    {
        Debug.Log(transform.name + " died");
        mort = true;
        GetComponent<Collider>().enabled = false;
        //GetComponent<EnemyController>().enabled = false;
        this.enabled = false;
        Object.Destroy(gameObject, 3.0f);
        //Destroy(gameObject);

        Instantiate(moare,transform.position, transform.rotation);

        //GetComponent<LootBag>().InstatiereLoot(transform.position);
        GetComponent<Drop>().PicaDrop();
    }
}
