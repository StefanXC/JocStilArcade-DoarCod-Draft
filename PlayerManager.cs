using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{
    public GameObject gameOverPanel; //ferestra ce apare cand personajul se loveste de un obstacol
    public bool jocTerminat = false; //booleanul in care vom stoca valoarea True daca eprsonajul atinge un obstacol


    //-----------------------------//
    public static int numarBanutzi;
    public static int baniT;
    public int banu;
    public int banutziT;
    //-----------------------------//


    public GameObject player;

    public GameObject[] porti;
    public GameObject poartaFinal;

    public GameObject[] Iteme;

    public GameObject[] StagiiInamici;
    public GameObject[] StagiuHarta;

    public GameObject[] Inamici;

    public GameObject[] Drop;

    public int stagiu = 0;

    public GameObject FinalPNL;

    public int final;
    public bool finalBOOL = false;

    public ManagerInventar managerInventar;

    /*#region Singleton;

    public static PlayerManager instance;

    private void Awake()
    {
        instance = this;
    }

    #endregion
    */


    void Start()
    {

        //managerInventar.LoadPlayer();



        porti = GameObject.FindGameObjectsWithTag("Poarta");
        poartaFinal = GameObject.FindGameObjectWithTag("PoartaFinal");

        for (int i = 0; i < porti.Length; i++)
        {
            porti[i].SetActive(false);
        }

        

        //poartaFinal.SetActive(false);


        //----------------------------------//
        StagiiInamici = GameObject.FindGameObjectsWithTag("StagiiInamici");

        for (int i =0; i < StagiiInamici.Length; i++)
        {
            StagiiInamici[i].SetActive(false);
        }

        StagiiInamici[0].SetActive(true);

        //-------------------------------//
        StagiuHarta = GameObject.FindGameObjectsWithTag("StagiuHarta");

        for (int i = 0; i < StagiuHarta.Length; i++)
        {
            StagiuHarta[i].SetActive(false);
        }

        StagiuHarta[0].SetActive(true);


        Inamici = GameObject.FindGameObjectsWithTag("Inamic");


        //Iteme = GameObject.FindGameObjectsWithTag("Drop");

        //for (int i = 0; i < Iteme.Length; i++)
        //{
        //    Iteme[i].GetComponent<ColectareITM>().enabled = false;
        //}  



        numarBanutzi = 0; //banii obtinuti în nivel vor fi la inceput 0 de fiecare data
        banutziT += numarBanutzi;

    }


    void Update()
    {
        int a = 0;
        Inamici = GameObject.FindGameObjectsWithTag("Inamic");


        foreach(GameObject inamic in Inamici)
        {
            if(inamic.GetComponent<InamicStats>().mort==false)
            {
                a++;
            }
        }


        if (/*Inamici.Length <= 0*/ a==0 && finalBOOL ==false)
        {
            
            porti[stagiu].SetActive(true);

            Drop = GameObject.FindGameObjectsWithTag("Drop");
            for (int i = 0; i < Drop.Length; i++)
            {
                Drop[i].GetComponent<ColectareITM>().enabled = true;
            }
        }
    }

    public void CameraUrmatoare()
    {

        //Inamici = GameObject.FindGameObjectsWithTag("Inamic")


        //FinalPNL.SetActive(true);
        //final = true;

        if (stagiu == final - 1)
        {
            FinalPNL.SetActive(true);
            finalBOOL = true;

            //player.GetComponent<PlayerController>().enabled = false;
        }
        else
        {

            Debug.Log("Ai intrat in urmatoarea camera!");

            stagiu++;

            StagiiInamici[stagiu].SetActive(true);
            StagiuHarta[stagiu].SetActive(true);

            player.GetComponent<PlayerCombat>().Inamici = GameObject.FindGameObjectsWithTag("Inamic");

            player.transform.position = new Vector3(0f, 0.5f, stagiu * 100f);
        }
        
    }



    public void EndGame() //functie apelata in momentul in care personajul se loveste de un obstacol
    {
        if (jocTerminat == false)
        {
            Debug.Log("Coliziune");

            jocTerminat = true;
            Debug.Log("Game over");
            gameOverPanel.SetActive(true);//apare fereastra de joc terminat
            Time.timeScale = 1f;

            GameObject playerController = GameObject.FindWithTag("Player");
            playerController.GetComponent<PlayerController>().enabled = false;

            //GameObject magnet = GameObject.FindWithTag("PowerUp");
            //magnet.GetComponent<PowerUpsManager>().enabled = false;




            //FindObjectOfType<PlayerController>().EndAnim();//apelam functia EndAim din scriptul ControlPersonaj
        }
        //if (scorMax < scor) //verificam daca scorul maxim de pana acum este mai mic de cat scorul obtinut acum
        //{
        //    scorMax = scor; //daca este adevarat vom atribuit scorul obtinut acum scorului maxim
        //}


    }
}
