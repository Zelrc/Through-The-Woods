using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DragLine;

public class BuffController : MonoBehaviour
{
    public Parry parryScript;
    // Update is called once per frame
    void Update()
    {
        if(parryScript.active)
        {
            if(ActionPhase)
            {
                this.GetComponent<CharacterScripts>().parryBuff = true;
            }
        }
    }
}
