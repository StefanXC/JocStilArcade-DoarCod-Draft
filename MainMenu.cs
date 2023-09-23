using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MainMenu : MonoBehaviour
{
    //public AudioMixer audioMixer;
    //[SerializeField] Slider sliderVolum;
    //public TMPro.TMP_Dropdown setareGrafica;

    public Image IncarcaFill;
    public GameObject IncarcaNivel;

    void Start()
    {

        //--------------------Incarca setari muzica ------------//
       /* if (!PlayerPrefs.HasKey("volumMuzica"))
        {
            PlayerPrefs.SetFloat("volumMuzica", 1);
            IncarcaSetMuzica();
        }
        else
        {
            IncarcaSetMuzica();
        }

        //---------------------Incarca setari grafice----------//
        if (!PlayerPrefs.HasKey("setareGrafica"))
        {
            PlayerPrefs.SetInt("setareGrafica", 2);
            IncarcaSetGraf();
        }
        else
        {
            IncarcaSetGraf();
        }*/
    }


    /*public void SchimbaVolum()
    {
        AudioListener.volume = sliderVolum.value;
        SalveazaSetMuzica();
    }
    */

    /*public void SetariGrafice(int graficIndex)
    {
        QualitySettings.SetQualityLevel(graficIndex);
        SalveazaSetGraf();
    }*/

    /*private void SalveazaSetMuzica()
    {
        PlayerPrefs.SetFloat("volumMuzica", sliderVolum.value);
    }*/

    /*private void IncarcaSetMuzica()
    {
        sliderVolum.value = PlayerPrefs.GetFloat("volumMuzica");
    }*/

    /*private void SalveazaSetGraf()
    {
        PlayerPrefs.SetInt("setareGrafica", setareGrafica.value);
    }*/

    /*private void IncarcaSetGraf()
    {
        setareGrafica.value = PlayerPrefs.GetInt("setareGrafica");
    }*/



    /*public void Setvolume (float volume)
    {
        audioMixer.SetFloat("volume", volume); //era deja comentat
    }
    */


    /*
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1); //era deja comentat

    } 
    */

    public void Play(int scenaId)
    {
        StartCoroutine(IncarcaScenaAsync(scenaId));
    }

    IEnumerator IncarcaScenaAsync(int scenaId)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scenaId);

        IncarcaNivel.SetActive(true);

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f);

            IncarcaFill.fillAmount = progress;

            yield return new WaitForSeconds(0.5f);
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
