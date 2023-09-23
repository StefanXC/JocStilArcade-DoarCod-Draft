using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HPbarScript : MonoBehaviour
{

    public Slider slider;
    public Gradient gradient;

    public Image fill;

    public TextMeshProUGUI HPtext;
   
    public void SetMaxHP(int hp)
    {
        slider.maxValue = hp;
        HPtext.text = hp.ToString();
        slider.value = hp;

        fill.color = gradient.Evaluate(1f);
    }

    public void SetHP(int hp)
    {
        slider.value = hp;
        HPtext.text = hp.ToString();

        fill.color = gradient.Evaluate(slider.normalizedValue);
    }
}
