using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Proiectil : MonoBehaviour
{
    public float life = 3f;
    public CharacterStats myStats;

    void Awake()
    {
        Destroy(gameObject, life);
        myStats = GameObject.FindGameObjectWithTag("InamicRange").GetComponent<CharacterStats>();
    }

    void OnTriggerEnter(Collider hitInfo)
    {

        CharacterStats charStats = hitInfo.GetComponent<CharacterStats>();
        if(charStats != null)
        {
            if(hitInfo.name=="Personaj")
            charStats.TakeDamage(myStats.damage.GetValue());
        }
        Debug.Log(hitInfo.name);
        Destroy(gameObject);
        
    }

    
}
