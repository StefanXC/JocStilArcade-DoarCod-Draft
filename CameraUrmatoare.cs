using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraUrmatoare : MonoBehaviour
{
    public PlayerManager playerManager;
    public GameObject player;

    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Player")
        {
            playerManager.CameraUrmatoare();
            IncarcaCameraUrmatoare();
        }
        Debug.Log("Am atins " + collider.name);
    }

    public void IncarcaCameraUrmatoare()
    {

        
    }
}
