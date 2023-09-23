using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillHolder : MonoBehaviour
{
    public Skills skills;
    float cooldownTime;
    float activeTime;

    enum SkillState
    {
        ready,
        active,
        cooldown
    }

    SkillState state = SkillState.ready;

    public KeyCode key;

    void Update()
    {
        switch (state)
        {
            case SkillState.ready:
                if (Input.GetKeyDown(key))
                {
                    //skills.Activate(gameObject);
                    state = SkillState.active;
                    activeTime = skills.activeTime;
                }
                break;
            case SkillState.active:
                if(activeTime > 0)
                {
                    activeTime -= Time.deltaTime;
                }
                else
                {
                    state = SkillState.cooldown;
                    cooldownTime = skills.cooldownTime;
                }
                break;
            case SkillState.cooldown:
                if (activeTime > 0)
                {
                    activeTime -= Time.deltaTime;
                }
                else
                {
                    state = SkillState.ready;
                    
                }
                break;
        }

        
    }
}
