using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LootBag : MonoBehaviour
{

    public GameObject dropItemPrefab;
    public List<Loot> lootList = new List<Loot>();

   Loot GetDropItem()
    {
        int randomNumber = Random.Range(1, 101); //1-100
        List<Loot> possibleItems = new List<Loot>();
        foreach(Loot item in lootList)
        {
            if(randomNumber <= item.dropChance)
            {
                possibleItems.Add(item);
                //return possibleItems;
            }
        }
        if(possibleItems.Count > 0)
        {
            Loot dropItem = possibleItems[Random.Range(0, possibleItems.Count)];
            return dropItem;
        }
        Debug.Log("Nu a picat nimic ");
        return null;
    }

    public void InstatiereLoot(Vector3 spawnPos)
    {
        Loot dropItem = GetDropItem();
        if(dropItem != null)
        {
            GameObject lootGameObject = Instantiate(dropItemPrefab, spawnPos, Quaternion.identity);
            //lootGameObject.GetComponent<SpriteRenderer>().sprite = dropItem.lootSprite;
            //lootGameObject.GetComponent<GameObject>() = dropItem.lootGameObject;
        }
    }
}
