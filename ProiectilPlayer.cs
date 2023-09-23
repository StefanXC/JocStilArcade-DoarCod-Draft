using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProiectilPlayer : MonoBehaviour
{
    public float life = 5f;

    public CharacterStats myStats;

    void Awake()
    {
        myStats = GameObject.Find("Personaj").GetComponent<CharacterStats>();
        Destroy(gameObject, life);
    }

    void OnTriggerEnter(Collider hitInfo)
    {

        InamicStats inamicStats = hitInfo.GetComponent<InamicStats>();
        if(inamicStats != null)
        {
            if(hitInfo.tag == "Inamic" || hitInfo.tag == "InamicRange")
            inamicStats.TakeDamage(myStats.damage.GetValue());
        }
        Debug.Log("Am lovit  "+ hitInfo.name);
        Destroy(gameObject);



    }

   
}
