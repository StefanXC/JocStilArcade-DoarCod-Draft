using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerEchipament : MonoBehaviour
{
    #region Singleton

    public static ManagerEchipament instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion

    Echipament[] echipamentCurent;

    ManagerInventar managerInventar;

    void Start()
    {
        managerInventar = ManagerInventar.Instance;

        int numSlots = System.Enum.GetNames(typeof(EchipamentSlot)).Length;
        echipamentCurent = new Echipament[numSlots];
    }

    public void Equip(Echipament newItem)
    {
        int slotIndex = (int)newItem.echipamentSlot;

        Echipament oldItem = null;


        if(echipamentCurent[slotIndex] != null)
        {
            oldItem = echipamentCurent[slotIndex];

            managerInventar.Add(oldItem);
        }

        echipamentCurent[slotIndex] = newItem;

    }

    public void Unequip(int slotIndex)
    {
        if(echipamentCurent[slotIndex] != null)
        {
            Echipament oldItem = echipamentCurent[slotIndex];
                
            managerInventar.Add(oldItem);

            echipamentCurent[slotIndex] = null;
            
        }
    }
}
