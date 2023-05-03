using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DragLine;

public class BOTWController : MonoBehaviour
{
    public BOTW botwScript;
    // Start is called before the first frame update
    void Start()
    {
        botwScript.active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (botwScript.active)
        {
            if (ActionPhase)
            {
                if (!botwScript.playedSound)
                {
                    AudioManager.Instance.Play("BOTW");
                    botwScript.playedSound = true;
                }
                if (botwScript.targetAlly == this.gameObject)
                { 
                    this.gameObject.GetComponent<CharacterScripts>().anim.SetTrigger("Buff");
                    this.GetComponent<CharacterScripts>().BOTW = true;
                }
                else
                {
                    botwScript.targetAlly.GetComponent<CharacterScripts>().anim.SetTrigger("BOTW");
                    this.gameObject.GetComponent<CharacterScripts>().anim.SetTrigger("CastBOTW");
                    botwScript.targetAlly.GetComponent<CharacterScripts>().BOTW = true;
                }
                

                botwScript.active = false;
            }
        }
    }
}
