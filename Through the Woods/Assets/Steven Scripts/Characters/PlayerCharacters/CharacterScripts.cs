using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;
using static DragLine;

public enum state
{
    Skill1,
    Skill2,
    Skill3
}
public class CharacterScripts : MonoBehaviour
{
    public PlayerSOs character;

    public int health;

    public GameObject AoECircle;

    public NavMeshAgent agent;

    public bool parryBuff = false;
    public bool BOTW = false;
    bool parryTurnOff = false;

    public bool usedSkill = false;
    bool usedSkillTurnOff = false;

    SpriteRenderer image;

    public Animator anim;

    public bool SetMoved;
    public int CDcosted;
    // Start is called before the first frame update
    
    void Start()
    {
        Debug.Log("Test");
        //image = GetComponent<SpriteRenderer>();
        //image.sprite = character.art;
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        anim = GetComponent<Animator>();

        health = character.maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if(parryBuff)
        {
            if(ActionPhase)
            {
                anim.SetBool("Parry", true);
            }
            else
            {
                anim.SetBool("Parry", false);
            }
        }
        else
        {
            anim.SetBool("Parry", false);
        }

        if(ActionPhase)
        {
            if(parryBuff || BOTW)
            {
                parryTurnOff = true;
            }
            else
            {
                parryTurnOff = false;
            }

            if(usedSkill)
            {
                usedSkillTurnOff = true;
            }
            else
            {
                usedSkillTurnOff = false;
            }
        }
        else
        {
            if(parryTurnOff)
            {
                BOTW = false;
                //character.Skill2.active = false; //need to change
                parryBuff = false;
                parryTurnOff = false;
                anim.SetTrigger("Idle");
            }

            if(usedSkillTurnOff)
            {
                usedSkill = false;
                usedSkillTurnOff = false;
            }
        }

        
    }
}
