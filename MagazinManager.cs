using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MagazinManager : MonoBehaviour
{
    public int personajCurent;
    public static int personajDeAnimat;

    public GameObject[] personaje;
    public GameObject[] personajeMagazin;

    public Image culoareButonCHA;
    public Image culoareButonUPGRADE;

    public Color portocaliuCUL; //culori folosite pentru butoanele personaje/imbunatatiri
    public Color albCUL;        // 

    public TextMeshProUGUI CharTXT;
    public TextMeshProUGUI UpgradeTXT;

    public ClasaPersonaje[] pers;
    public TextMeshProUGUI numePersonaj;
    public Button cumparaBTN;

    public PlayerManager playerManager;

    void Start()
    {
        //playerManager = GetComponent<PlayerManager>();

        foreach (ClasaPersonaje personaj in pers)
        {
            if (personaj.pret == 0)
                personaj.cumparat = true;
            else
                personaj.cumparat = PlayerPrefs.GetInt(personaj.nume, 0) == 0 ? false : true;

        }


        personajCurent = PlayerPrefs.GetInt("PersonajActiv", 0);
        foreach (GameObject personaj in personaje)
            personaj.SetActive(false);


        personaje[personajCurent].SetActive(true);


        //------------BUG FIX ( ca de fiecare data sa porneasca cu Characters portocaliu si upgrades alb)---//
        CharTXT.color = new Color(1, 1, 1);
        UpgradeTXT.color = new Color(0, 0, 0);

        culoareButonCHA.color = portocaliuCUL;
        culoareButonUPGRADE.color = albCUL;

    }

    void Update()
    {
        UpdateUI();

    }

    public void SelectCHAR() //se apeleaza atunci cand jucatorul selecteaza fereastra cu personaje
    {

        CharTXT.color = new Color(1, 1, 1);
        UpgradeTXT.color = new Color(0, 0, 0);

        culoareButonCHA.color = portocaliuCUL;
        culoareButonUPGRADE.color = albCUL;
    }

    public void SelectUPGRADE() //se apeleaza atunci cand jucatorul selecteaza fereastra cu imbunatatiri
    {

        CharTXT.color = new Color(0, 0, 0);
        UpgradeTXT.color = new Color(1, 1, 1);

        culoareButonCHA.color = albCUL;
        culoareButonUPGRADE.color = portocaliuCUL;
    }

    public void SelectarePersonaj(int character)
    {
        personaje[personajCurent].SetActive(false);

        //if(shopPers.clicked)

        personajCurent = character;
        Debug.Log("S-a selectat personajul " + personajCurent);

        personaje[personajCurent].SetActive(true);

        //PlayerPrefs.SetInt("PersonajActiv", personajCurent);

        ClasaPersonaje c = pers[personajCurent];
        if (!c.cumparat)
            return;

        PlayerPrefs.SetInt("PersonajActiv", personajCurent);
    }


    /*public void PersonajUrmator()
    {
        personaje[personajCurent].SetActive(false);

        personajCurent++;

        if (personajCurent == personaje.Length)
            personajCurent = 0;

        personaje[personajCurent].SetActive(true);

        PlayerPrefs.SetInt("PersonajActiv", personajCurent);

        ClasaPersonaje c = pers[personajCurent];
        if (!c.cumparat)
            return;
    } */

    /*public void PersonajAnterior()
    {
        personaje[personajCurent].SetActive(false);

        personajCurent--;

        if (personajCurent == -1)
            personajCurent = personaje.Length - 1;

        personaje[personajCurent].SetActive(true);

        ClasaPersonaje c = pers[personajCurent];
        if (!c.cumparat)
            return;

        PlayerPrefs.SetInt("PersonajActiv", personajCurent);
    } */

    /*((((public void CumparaPersonaj() //se apeleaza in momentul in care jucatorul apasa butonul "cumpara personaj" 
    {
        ClasaPersonaje c = pers[personajCurent];
        PlayerPrefs.SetInt(c.nume, 1);
        PlayerPrefs.SetInt("PersonajActiv", personajCurent); //personajul curent devine personajul proaspat cumparat
        c.cumparat = true; //valoarea booleanului devine TRUE, adica personajul este achizitionat

        playerManager.banutziT = playerManager.banutziT - c.pret; //luam din banii jucatorului pretul personajului
        playerManager.SavePlayer(); //salvam progresul

        //PlayerPrefs.SetInt("NumberOfCoins", PlayerPrefs.GetInt("NumberOfCoins", 0) - c.pret);
    }*/

    private void UpdateUI() //actualizam interfata magazinului sa nu afiseze informatii eronate
    {
        ClasaPersonaje c = pers[personajCurent];
        numePersonaj.text = pers[personajCurent].nume;

        if (c.cumparat) //verificam daca personajul este cumparat
        {
            cumparaBTN.gameObject.SetActive(false); //butonul "Cumpara" dispare
        }
        else
        {
            cumparaBTN.gameObject.SetActive(true); //butonul "Cumpara" apare si devine utilizabil
            cumparaBTN.GetComponentInChildren<TextMeshProUGUI>().text = "Cumpara-" + c.pret; //modificam textul butonului
            if (c.pret < /*PlayerPrefs.GetInt("NumberOfCoins",0)*/ playerManager.banutziT) //verificam daca jucatorul are mai multi bani decat pretul jucatorului
            {
                cumparaBTN.interactable = true; //facem butonul interactibil(se poate apasa)
            }
            else
            {
                cumparaBTN.interactable = false; //butonul nu va fi interactibil (nu se poate apasa)
            }
        }

    }

}
