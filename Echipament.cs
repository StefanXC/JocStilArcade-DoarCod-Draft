using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "Echipament nou",menuName = "Inventory/Echipament")]
public class Echipament : Item
{

    public EchipamentSlot echipamentSlot;

    public int modifierArmura;
    public int modifierArma;


    public override void Use()
    {
        base.Use();

        ManagerEchipament.instance.Equip(this);
        RemoveFromInventory();
    }

}

public enum EchipamentSlot { Casca, Armura, Papuci, Arma, Scut}
