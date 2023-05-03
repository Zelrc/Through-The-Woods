using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HammerAttack", menuName = "Character/Abilities/HammerAttack")]
public class HammerAttack : AbilitySO
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
    }
}
