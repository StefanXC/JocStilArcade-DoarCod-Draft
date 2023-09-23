using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

[System.Serializable]
public class ManagerInventar : MonoBehaviour
{

    #region Singleton

    public static ManagerInventar Instance;

    public void Awake()
    {
        if(Instance != null)
        {
            Debug.LogWarning("S-au gasit mai multe inventare");
            return;
        }

        Instance = this;
        //File_path = Application.persistentDataPath + "/Inventory.txt";

        //CreateItemDictionary();

    }

    #endregion


    public delegate void OnItemChanged();
    public OnItemChanged onItemChangedCallback;


    public List<Item> Items = new List<Item>();

    //public List<ItemCodat> Cod = new List<ItemCodat>();

    public List<int> Dani = new List<int>();

    public Item Arc;
    public Item Sabie;

    public int level = 0;


    public Transform ItemContent;
    public GameObject InventoryItem;

   
    void Start()
    {
        Debug.Log(level);
        //foreach (var itemSiNum in FindAnyObjectByType<inve)

        //if(Dani!=null)
            //LoadPlayer();

        LoadPlayer();
        LoadPlayer();
    }



    Item item;

    public void Add(Item item)
    {
        Items.Add(item);
        SavePlayer();
        
    }

    public void Remove(Item item)
    {
        Items.Remove(item);
        SavePlayer();
    }

    public void UseItem()
    {
        if(item != null)
        {
            item.Use();
        }
    }



    public void ListItems()
    {
        foreach(Transform item in ItemContent)
        {
            Destroy(item.gameObject);
        }

        foreach (var item in Items)
        {
            GameObject obj = Instantiate(InventoryItem, ItemContent);
            var itemName = obj.transform.Find("ItemName").GetComponent<TextMeshProUGUI>();
            var itemIcon = obj.transform.Find("ItemIcon").GetComponent<Image>();

            itemName.text = item.itemName;
            itemIcon.sprite = item.icon;

        }
    }

    public void SavePlayer()
    {
        Salveaza();
        SaveSystem.SavePlayer(this);
        Debug.Log("Am salvat");
    }
    

    
    public void LoadPlayer()
    {
        Incarca();

        


        PlayerData data = SaveSystem.LoadPlayer();

        Dani = data.Dani;

        Debug.Log("Jocul a fost incarcat");
    }
    

    public void Salveaza()
    {
        Dani.Clear();
        Debug.Log(Items.Count);
        for (int i = 0; i < Items.Count; i++)
        {

            if (Items[i].id == 1)
            {
                Dani.Insert(i, 1);
                //Dani[i] = 1;
                //Debug.Log("ai un arc");
            }
            if (Items[i].id == 2)
            {
                Dani.Insert(i, 2);
                //Debug.Log("ai o sabie");
            }

        }
    }

    public void Incarca()
    {
        Items.Clear();
        for (int i = 0; i < Dani.Count; i++)
        {
            if (Dani[i] == 1)
            {
                //Items[i].id = 1;
                Items.Insert(i, Arc);

                //Debug.Log("ai un arc");
            }
            if (Dani[i] == 2)
            {
                Items.Insert(i, Sabie);
                //Debug.Log("ai o sabie");
            }
        }
    }

    /*internal void SaveInventory()
    {
        /using (StreamWriter sw = new StreamWriter(File_path))
        {
            foreach (KeyValuePair<Item , int> kvp in item)
            {
               /Item item = kvp.Key;
                int count = kvp.Value;

                string itemID = HashItem(item).ToString();

                sw.WriteLine(itemID + SPLIT_CHAR + count);
            }
        }
    }*/

    /*internal Dictionary<Item, int> LoadInventory()
    {
        if (!File.Exists(File_path))
        {
            Debug.LogWarning("Fisierul nu a fost gasit");
            return null; ;
        }

        Dictionary<Item, int> inventory = new Dictionary<Item, int>();

        string line = "";

        using (StreamReader sr = new StreamReader(File_path))
        {

            while ((line = sr.ReadLine()) != null) 
            {
                int key = int.Parse( line.Split(SPLIT_CHAR)[0] );
                Item item = CodItem[key];
                int count = int.Parse(line.Split(SPLIT_CHAR)[1]);

                inventory.Add(item, count);
            }
        }

        return inventory;
    }
    */

    //private static Dictionary<int, Item> CodItem = new Dictionary<int, Item>();


    //private static int HashItem(Item item) => Animator.StringToHash(item.itemName);

    //private static string File_path = "NULL";

    //const char SPLIT_CHAR = '_';

    //[SerializeField] private ManagerInventar inventoryToSave = null;

    //[SerializeField] private Inve




    //public int ceva;

    /*private void CreateItemDictionary()
    {
        Item[] allItems = Resources.FindObjectsOfTypeAll<Item>(); 

        foreach (Item i in allItems)
        {
            int key = HashItem(i);

            if (CodItem.ContainsKey(key))
                CodItem.Add(key, i);
        }
    }
    */
}
