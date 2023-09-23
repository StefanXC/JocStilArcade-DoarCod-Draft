using UnityEngine;
using TMPro;

public class FPScalculator : MonoBehaviour
{
    public TextMeshProUGUI FpsText;

    private float timp; //variabila in care vom stoca timpul
    private int numaraCadre; //variabila in care se va stoca numaratoarea cadrelor


    void Update()
    {
        timp += Time.deltaTime;

        numaraCadre++; //valaorea variabilei va creste la fiecare cadru generat de joc
        
        if(timp >= 1)
        {
            int frameRate = Mathf.RoundToInt(numaraCadre / timp);
            FpsText.text = frameRate.ToString() + "FPS"; // afisam rezultatul intr-un text

            timp -= 1;
            numaraCadre = 0;

        }
    }
}
