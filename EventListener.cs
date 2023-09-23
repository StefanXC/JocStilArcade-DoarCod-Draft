using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventListener : MonoBehaviour
{
    public PlayerCombat playerCombat;
    public CharacterStats myStats;
    public PlayerController controller;

    // Start is called before the first frame update
    void Start()
    {
        //playerCombat = GameObject.Find("")
    }

    public void IncepeAtack()
    {
        myStats.isAttacking = true;
        controller.isAttacking = true;
        Debug.Log("Atack inceput");
    }

    public void AnimEvent()
    {
        Debug.Log("Anim check");
        playerCombat.Lanseaza();
       
    }

    
    public void AtackFinalizat()
    {
        Debug.Log("Atack Finalizat");
        myStats.isAttacking = false;
        controller.isAttacking = false;
        
    }

}
