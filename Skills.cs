using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Skills : ScriptableObject
{

    public new string name;
    public float cooldownTime;
    public float activeTime;

    public virtual void Activate()
    {

    }


    
}
