using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventListenerWAR : MonoBehaviour
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
        //Debug.Log("Atack inceput");
    }

    public void Slash1()
    {
        //Debug.Log("Anim check");
        playerCombat.Slashh();

    }

    public void Slash2()
    {
        //Debug.Log("Anim check");
        playerCombat.Slashh2();

    }

    public void slash3()
    {
        //Debug.Log("Anim check");
        playerCombat.Slashh3();

    }


    public void AtackFinalizat()
    {
        //Debug.Log("Atack Finalizat");
        myStats.isAttacking = false;
        controller.isAttacking = false;

    }

}
