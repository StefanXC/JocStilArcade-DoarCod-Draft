using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotireDrop : MonoBehaviour
{

    public Vector3 pozitieDrop; //Vector3 folosit pentru modificarea coordonatelor camerei

    public float min = -2; //valoarea minima a coordonatei Ox
    public float max = 2;  //valoarea maxima a coordonatei Ox

    public float viteza = 1; //viteza de miscare pentru ambele axe pe care le vom modifica

    public bool misca = true;


    public float animOpen = 0.2f;    //
    public float animClose = 0.3f;  //variabile folosite pentru animatii
    public float delay = 0.2f;


    public float vitezaRotatie = 50;


    void Start()
    {
        //gameObject.LeanMoveLocalY(10, animOpen).setEaseInOutExpo().delay = delay;
    }


    void FixedUpdate()
    {
        transform.Rotate(0, vitezaRotatie * Time.deltaTime, 0);

        //gameObject.LeanMoveLocalY(5, animOpen).setEaseInOutExpo().delay = delay;
        //gameObject.LeanMoveLocalY(-5, animOpen).setEaseInOutExpo().delay = delay;


         Misca();

        pozitieDrop = new Vector3(transform.position.x, pozitieDrop.y, transform.position.z);
        transform.position = pozitieDrop;
    }


    public void Misca()
    {
        if (pozitieDrop.y <= max && misca == true)
        {
            pozitieDrop.y += viteza */*(transform.position.y % min)**/ Time.deltaTime; //valoarea coordonatei Oy creste
        }

        

        if (pozitieDrop.y >= max - 1)
        {
            misca = false;
        }

        if (pozitieDrop.y > min && misca == false)
        {
            pozitieDrop.y -= viteza */*( transform.position.y % max)**/Time.deltaTime; //valoarea coordonatei Oy descreste
        }

        if (pozitieDrop.y <= min + 1)
        {
            misca = true;
        }
    }

    
}
