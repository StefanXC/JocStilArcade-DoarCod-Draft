using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ItemController : MonoBehaviour
{
    public Item Item;

    public ColectareITM colectareITM;

    public TextMeshProUGUI nume;


    void Start()
    {

        nume.text = Item.itemName;
        colectareITM = GetComponent<ColectareITM>();
        colectareITM.enabled = false;
    }
}
