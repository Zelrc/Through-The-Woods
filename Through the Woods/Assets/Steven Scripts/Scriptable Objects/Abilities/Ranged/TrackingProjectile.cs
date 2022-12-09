using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DragLine;

public class TrackingProjectile : AbilitySO
{
    GameObject targetEnemy;
    public override void Activate(CharacterScripts character)
    {
        //character.AoECircle.SetActive(true);
        target = null;
        choosingTarget = true;
    }

    public override void Deactivate(CharacterScripts character)
    {
        choosingTarget = false;
    }

    public override void UseSkill(CharacterScripts _character)
    {
        //if()
        targetEnemy = target;
        character = _character;
        active = true;
        choosingTarget = false;
    }

    
}
