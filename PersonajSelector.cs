using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PersonajSelector : MonoBehaviour
{
    public int personajCurent;
    public GameObject[] personajele;

    void Start()
    {

        personajCurent = PlayerPrefs.GetInt("PersonajActiv", 0);
        foreach (GameObject personaje in personajele)
            personaje.SetActive(false);


        personajele[personajCurent].SetActive(true);

    }


}
