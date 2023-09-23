using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drop : MonoBehaviour
{

    public GameObject[] deDropat;
    public GameObject dropPoint;

 

    public List<Loot> lootList = new List<Loot>();

    Loot GetDropItem()
    {
        int randomNumber = Random.Range(1, 101); //1-100
        List<Loot> possibleItems = new List<Loot>();
        foreach (Loot item in lootList)
        {
            if (randomNumber <= item.dropChance)
            {
                possibleItems.Add(item);
                //return possibleItems;
            }
        }
        if (possibleItems.Count > 0)
        {
            Loot dropItem = possibleItems[Random.Range(0, possibleItems.Count)];
            Debug.Log(GetDropItem());
            return dropItem;
        }
        Debug.Log("Nu a picat nimic ");
        //Debug.Log(GetDropItem());
        return null;

        
    }
    


    // Update is called once per frame
    void Update()
    {
        
    }

    public void PicaDrop()
    {
        Instantiate(deDropat[Random.Range(0, 2)], dropPoint.transform.position, transform.rotation);
        //Debug.Log(GetDropItem());
        //Loot drop
    }

    /*public void InstatiereLoot(Vector3 spawnPos)
    {
        Loot dropItem = GetDropItem();
        if (dropItem != null)
        {
            GameObject lootGameObject = Instantiate(dropItemPrefab, spawnPos, Quaternion.identity);
            //lootGameObject.GetComponent<SpriteRenderer>().sprite = dropItem.lootSprite;
            //lootGameObject.GetComponent<GameObject>() = dropItem.lootGameObject;
        }
    }
    */
}
