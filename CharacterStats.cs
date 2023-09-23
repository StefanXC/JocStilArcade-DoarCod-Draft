
using UnityEngine;

public class CharacterStats : MonoBehaviour
{
    public float maxHP = 100;
    public float curentHP { get; private set; }

    [SerializeField]
    float HPregen = 0;

    public Stat damage;
    public Stat armura;

    public HPbarScript hpBar;

    public Animator[] animator;

    public bool mort = false;

    public bool isAttacking = false;

    public int deAnimat;

    private void Awake()
    {
        curentHP = maxHP;
        hpBar.SetMaxHP((int)maxHP);
        deAnimat = PlayerPrefs.GetInt("PersonajActiv", 0);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            TakeDamage(10);
        }
        if(curentHP <= maxHP-HPregen && curentHP > 0)
        {
            RegenHP();
        }
    }

    public void RegenHP()
    {
        curentHP += HPregen*Time.deltaTime;
        hpBar.SetHP((int)curentHP);
    }

    public void TakeDamage(int damage)
    {
        damage -= armura.GetValue();
        damage = Mathf.Clamp(damage, 1, int.MaxValue);

        curentHP -= damage;
        Debug.Log(transform.name + " take " + damage + " damage ");

        hpBar.SetHP((int)curentHP);
        if (curentHP <= 0 )
        {
            Die();
            animator[deAnimat].SetTrigger("Mort");
        }
        else if (isAttacking == false)
        {
            animator[deAnimat].SetTrigger("Lovit");
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
    }
}
