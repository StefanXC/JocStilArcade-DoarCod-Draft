using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerData
{
    //public int level;
    public List<int> Dani = new List<int>();

    //public List<int> Dani = new List<int>();

    public PlayerData(ManagerInventar managerInventar)
    {
        Dani = managerInventar.Dani;
    
    }
}
