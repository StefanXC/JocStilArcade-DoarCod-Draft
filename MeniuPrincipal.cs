using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;
using UnityEngine.UI;

public class MeniuPrincipal : MonoBehaviour
{
    public AudioMixer audioMixer;
    [SerializeField] Slider sliderVolum;
    public TMPro.TMP_Dropdown setareGrafica;

    public Image IncarcaFill;
    public GameObject IncarcaNivel;

    void Start()
    {

        //--------------------Incarca setari muzica ------------//
        if (!PlayerPrefs.HasKey("volumMuzica"))
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
            PlayerPrefs.SetInt("setareGrafica", 1);
            IncarcaSetGraf();
        }
        else
        {
            IncarcaSetGraf();
        }



    }


    public void SchimbaVolum() //fuctia primeste valoarea curenta a slider-ului de volum (primeste valoarea doar cand jucatorul modifica valoarea curenta)
    {
        AudioListener.volume = sliderVolum.value;
        SalveazaSetMuzica();
        //Debug.Log("Am schimbat volumul" + sliderVolum.value);
    }

    public void SetariGrafice(int graficIndex)
    {
        QualitySettings.SetQualityLevel(graficIndex);
        SalveazaSetGraf();
        Debug.Log("a fost selectata calitatea graficii " + graficIndex);
    }

    private void SalveazaSetMuzica() //functia salveaza valoarea curenta a slider-ului de volum
    {
        PlayerPrefs.SetFloat("volumMuzica", sliderVolum.value);
    }

    private void IncarcaSetMuzica() //functia cauta in memoria jocului valoarea salvata anterioara
    {
        sliderVolum.value = PlayerPrefs.GetFloat("volumMuzica");
    }

    private void SalveazaSetGraf() //functia salveaza setarea de grafica curenta aleasa de jucator
    {
        PlayerPrefs.SetInt("setareGrafica", setareGrafica.value);
    }

    private void IncarcaSetGraf() //functia cauta in memoria jocului valoarea salvata anterioara
    {
        setareGrafica.value = PlayerPrefs.GetInt("setareGrafica");
    }



    /*public void Setvolume (float volume)
    {
        audioMixer.SetFloat("volume", volume);
    }
    */


    /*
    public void PlayGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);

    } 
    */

    public void Play(int scenaId)
    {
        StartCoroutine(IncarcaScena(scenaId));
    }

    IEnumerator IncarcaScena(int scenaId)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(scenaId);

        IncarcaNivel.SetActive(true);

        while (!operation.isDone) //asteptam pana cand urmatoarea scena este complet incarcata
        {
            float progress = Mathf.Clamp01(operation.progress / 0.9f); //Math.Clamp01 daca valaorea este negativa va deveni 0 ;i daca valoarea este mai mare decat 1 va deveni 1

            IncarcaFill.fillAmount = progress;
    
            yield return new WaitForSeconds(0.5f); //fuctia va mai astepta jumatate de secunda pentru a fi siguri ca scena s-a incarcat
        }
    }

    public void QuitGame()
    {
        Application.Quit();
    }
}
