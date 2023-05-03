using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DragLine;

[CreateAssetMenu(fileName = "Ability", menuName = "Character/Abilities/AxeAttack")]
public class AxeAttack : AbilitySO
{
    public override void Activate(CharacterScripts character)
    {
        character.AoECircle.SetActive(true);
        
    }

    public override void Deactivate(CharacterScripts character)
    {
        character.AoECircle.SetActive(false);
    }



    public override void UseSkill(CharacterScripts _character)
    {
        character = _character;
        active = true;
        playedSound = false;
    }
}
