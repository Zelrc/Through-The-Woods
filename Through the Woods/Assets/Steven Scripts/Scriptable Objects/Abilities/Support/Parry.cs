using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DragLine;

[CreateAssetMenu(fileName = "Ability", menuName = "Character/Abilities/Parry")]
public class Parry : AbilitySO
{
    public override void Activate(CharacterScripts character)
    {

    }

    public override void Deactivate(CharacterScripts character)
    {
       
    }



    public override void UseSkill(CharacterScripts _character)
    {
        character = _character;
        active = true;
        //character.anim.SetTrigger("Jump");
        //character.anim.SetInteger("Direction", 0);

        
    }

}
