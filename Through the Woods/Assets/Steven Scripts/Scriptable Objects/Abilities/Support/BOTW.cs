using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DragLine;

[CreateAssetMenu(fileName = "Ability", menuName = "Character/Abilities/BOTW")]
public class BOTW : AbilitySO
{
    public GameObject targetAlly;
    public override void Activate(CharacterScripts character)
    {
        //character.AoECircle.SetActive(true);
        target = null;
        choosingTarget = true;
        allyTarget = true;
        confirmSkillButton.interactable = false;
    }

    public override void Deactivate(CharacterScripts character)
    {
        choosingTarget = false;
    }

    public override void UseSkill(CharacterScripts _character)
    {
        targetAlly = target;
        choosingTarget = false;
        character = _character;
        playedSound = false;

        if (targetAlly.GetComponent<CharacterScripts>())
        {
            active = true;
        }
        else
        {

        }
    }
}
