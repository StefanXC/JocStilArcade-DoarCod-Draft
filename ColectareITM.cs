using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColectareITM : MonoBehaviour
{
    public Transform player;
    public float vitDeMiscare = 60f;

    public Item Item;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        //Iteme = GameObject.FindGameObjectsWithTag("Drop");
    }

    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, player.position, vitDeMiscare * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("Am colectat arc");
        if (other.tag == "Player")
            Pickup();

    }

    void Pickup()
    {
        ManagerInventar.Instance.Add(Item);
        Destroy(gameObject);
    }
}
