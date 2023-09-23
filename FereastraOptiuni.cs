using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FereastraOptiuni : MonoBehaviour
{
    public float animOpen = 0.2f;
    public float animClose = 0.3f;
    public float delay = 0.2f;

    public Transform titlu;
    public Transform continut;
    public Transform optiuni;

    public CanvasGroup background;


    private void Start()
    {
          titlu.localScale = Vector3.zero;
          continut.localScale = Vector3.zero;
    }
        
    private void OnEnable()
    {
        background.alpha = 0;
        background.LeanAlpha(1, animOpen);
        
        optiuni.localPosition = new Vector3( 0, -Screen.height);
        optiuni.LeanMoveLocalY(0, animOpen).setEaseInOutExpo().delay = delay;        
        titlu.LeanScale(Vector3.one, 0.52f);
        continut.LeanScale(Vector3.one, 0.56f);

        //continut.localPosition = new Vector2(0, -Screen.height);
        //continut.LeanMoveLocalY(0, animOpen).setEaseInOutExpo().delay = delay + 1f ;

        /*
        Frame[0].localPosition = new Vector2(0, -Screen.height);
        Frame[0].LeanMoveLocalY(0, animOpen).setEaseInOutExpo().delay = delay;

        Frame[1].localPosition = new Vector2(0, -Screen.height);
        Frame[1].LeanMoveLocalY(0, animOpen).setEaseInOutExpo().delay = delay + 0.1f;
        */
    }

    public void CloseOption()
    {
        background.LeanAlpha(0, animClose);

        titlu.LeanScale(Vector3.zero, 0.3f).setEaseInBack();
        continut.LeanScale(Vector3.zero, 0.2f).setEaseInBack();

        optiuni.LeanMoveLocalY(-Screen.height, animClose).setEaseInExpo().setOnComplete(Inchide);
        //continut.LeanMoveLocalX(-Screen.height, animClose).setEaseInExpo().setOnComplete(Inchide);
        

        /*background.LeanAlpha(0, animClose);
        Frame[0].LeanMoveLocalY(-Screen.height, animClose).setEaseInExpo().setOnComplete(Inchide);
        Frame[1].LeanMoveLocalY(-Screen.height, animClose).setEaseInExpo().setOnComplete(Inchide);
        */

    }

    void Inchide()
    {
        gameObject.SetActive(false);
    }

}
