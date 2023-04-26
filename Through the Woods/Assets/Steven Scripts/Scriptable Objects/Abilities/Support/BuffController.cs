using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DragLine;

public class BuffController : MonoBehaviour
{
    public Parry parryScript;

    private void Start()
    {
        parryScript.active = false;
    }
    // Update is called once per frame
    void Update()
    {
        if(parryScript.active)
        {
            if(ActionPhase)
            {
                this.GetComponent<CharacterScripts>().parryBuff = true;
                parryScript.active = false;
            }
        }
    }
}
