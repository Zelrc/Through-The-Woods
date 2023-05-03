using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DragLine;

public class HealController : MonoBehaviour
{
    public Heal healScript;

    // Start is called before the first frame update
    void Start()
    {
        healScript.active = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (healScript.active)
        {
            if (ActionPhase)
            {
                if (!healScript.playedSound)
                {
                    AudioManager.Instance.Play("Heal");
                    healScript.playedSound = true;
                }
                if (healScript.targetAlly == this.gameObject)
                {
                    this.gameObject.GetComponent<CharacterScripts>().anim.SetTrigger("SelfHeal");
                }
                else
                {
                    healScript.targetAlly.GetComponent<CharacterScripts>().anim.SetTrigger("Heal");
                    this.gameObject.GetComponent<CharacterScripts>().anim.SetTrigger("CastHeal");
                }
                
                healScript.targetAlly.GetComponent<CharacterScripts>().health += 2;

                if (healScript.targetAlly.GetComponent<CharacterScripts>().health > healScript.targetAlly.GetComponent<CharacterScripts>().character.maxHealth)
                {
                    healScript.targetAlly.GetComponent<CharacterScripts>().health = healScript.targetAlly.GetComponent<CharacterScripts>().character.maxHealth;
                   
                }
                healScript.active = false;
            }
        }
    }
}
