using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MeniuPauza : MonoBehaviour
{
    public static bool jocPePauza = false;

    public GameObject meniuPauzaUI; //obiectul din scena ce contine meniul de pauza

    public GameObject[] Inamici;

    public GameObject player;

    void Update()
    {
        //---test de apelare a fuctiilor ---//
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (jocPePauza)
            {
                Reia();
            }
            else
            {
                Pauza();
            }
        }
        //--------------------------//

    }

    public void GamePause()
    {
        /*if (GameIsPaused)
        {
            Resume();
        }
        else
        {
            Pause();
        } */
    }


    public void Reia() //fuctie apelata la apasarea butonului "Reia"
    {
        meniuPauzaUI.SetActive(false); //ascundem meniul care apare in momentul cand jocul este pe pauza

        Time.timeScale = 1f;

        jocPePauza = false;
        
        //GameObject playerController = GameObject.FindWithTag("Player"); 
        //playerController.GetComponent<PlayerController>().enabled = true;


        player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<PlayerCombat>().enabled = true;
        player.GetComponent<PlayerController>().enabled = true;


        Inamici = GameObject.FindGameObjectsWithTag("Inamic");
        //GameObject[] Inamic = GameObject.GameObject.FindWithTag("Player");
        //    GameObject.FindWithTag("Inamic");
        for (int i = 0; i< Inamici.Length; i++)
        {
            Inamici[i].GetComponent<EnemyController>().enabled = true;
            Inamici[i].GetComponent<EnemyCombat>().enabled = true;
            Inamici[i].GetComponentInChildren<Animator>().enabled = true;
        }

        

        //GameObject magnet = GameObject.FindWithTag("PowerUp");
        //magnet.GetComponent<PowerUpsManager>().enabled = true;

    }

    public void Pauza() //fuctia este apelata la apasarea butonului "Pauza"
    {
        meniuPauzaUI.SetActive(true); //facem vizibil meniul care apare cand jocul este pe pauza

        jocPePauza = true;

        //Time.timeScale = 0f;

        //GameObject playerController = GameObject.FindWithTag("Player"); //atribuim GameObject-ului obiectul cu eticheta "Player"
        //playerController.GetComponent<PlayerController>().enabled = false; //dezactivam scriptul "ControlPersonaj"

        player = GameObject.FindGameObjectWithTag("Player");

        player.GetComponent<PlayerCombat>().enabled = false;
        player.GetComponent<PlayerController>().enabled = false;
        //player.GetComponentInChildren<Animator>().enabled = false;

        Inamici = GameObject.FindGameObjectsWithTag("Inamic");
        //GameObject[] Inamic = GameObject.GameObject.FindWithTag("Player");
        //    GameObject.FindWithTag("Inamic");
        for (int i = 0; i < Inamici.Length; i++)
        {
            Inamici[i].GetComponent<EnemyController>().enabled = false;
            Inamici[i].GetComponent<EnemyCombat>().enabled = false;
            Inamici[i].GetComponentInChildren<Animator>().enabled = false;
        }

       

        //GameObject magnet = GameObject.FindWithTag("PowerUp");
        //magnet.GetComponent<PowerUpsManager>().enabled = false;

        Debug.Log("Pauza");

    }

    public void DeschideMeniu() //functia apelata la apasarea butonului "Meniu", acest buton incarca scena Meniu
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Meniu"); //incarca si trece ca scena activa Meniul
        Debug.Log("Meniu");
    }

    public void InchideJoc() //fuctie apelata la apasarea butonului "Inchide"
    {
        Debug.Log("Quitting game..");
        Application.Quit();
    }

    public void JoacaDinNou() //fuctie apelata la apasarea butonului "Reincearca" 
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); //reincarca scena actuala 
    }




}
