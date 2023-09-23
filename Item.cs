using UnityEngine;

[CreateAssetMenu(fileName = "New Item" ,menuName = "Item/Create New Item")]
[System.Serializable]
public class Item : ScriptableObject
{
    public int id;
    public string itemName;
    public int value;
    public Sprite icon;

    public virtual void Use()
    {
        Debug.Log("Folosesti " + itemName);
    }

    public void RemoveFromInventory()
    {
        ManagerInventar.Instance.Remove(this);
    }
   
}
