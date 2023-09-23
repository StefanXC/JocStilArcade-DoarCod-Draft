using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Billboard : MonoBehaviour
{
    public Transform cam;
    public GameObject came;
    void Start()
    {
        came = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void LateUpdate()
    {
        //transform.LookAt(transform.position + cam.forward);
        transform.LookAt(transform.position + came.transform.forward);
    }
}
