using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class CharacterSelect : MonoBehaviour
{
    public int personajCurent;

    public GameObject[] personaje;
    public GameObject[] personaje2;
    public GameObject[] shopPers;


    public ClasaPersonaje[] pers;
    public TextMeshProUGUI numePersonaj;

    //public PlayerManager playerManager;

  
    void Start()
    {

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

        foreach (GameObject personaj2 in personaje2)
            personaj2.SetActive(false);

        personaje[personajCurent].SetActive(true);
        personaje2[personajCurent].SetActive(true);
    }

    void Update()
    {
        UpdateUI();
    }

    public void SelectarePerspnaj(int character)
    {
        personaje[personajCurent].SetActive(false);
        personaje2[personajCurent].SetActive(false);


        personajCurent = character;
        Debug.Log("S-a selectat personajul " + personajCurent);

        personaje[personajCurent].SetActive(true);
        personaje2[personajCurent].SetActive(true);

        PlayerPrefs.SetInt("PersonajActiv", personajCurent);

        ClasaPersonaje c = pers[personajCurent];
        if (!c.cumparat)
            return;

        PlayerPrefs.SetInt("PersonajActiv", personajCurent);
    }

    public void UpdateUI()
    {
        ClasaPersonaje c = pers[personajCurent];
        numePersonaj.text = pers[personajCurent].nume;
    }
}
