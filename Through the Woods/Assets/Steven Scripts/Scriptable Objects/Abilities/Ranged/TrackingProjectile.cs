using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DragLine;

[CreateAssetMenu(fileName = "Ability", menuName = "Character/Abilities/TrackingProjectile")]
public class TrackingProjectile : AbilitySO
{
    public GameObject targetEnemy;
    public override void Activate(CharacterScripts character)
    {
        //character.AoECircle.SetActive(true);
        target = null;
        choosingTarget = true;
        Debug.Log("Choose ur target");
        Debug.LogWarning(choosingTarget);
    }

    public override void Deactivate(CharacterScripts character)
    {
        choosingTarget = false;
    }

    public override void UseSkill(CharacterScripts _character)
    {
        targetEnemy = target;
        choosingTarget = false;
        character = _character;
        
        if(targetEnemy.GetComponent<EnemyScript>())
        {
            active = true;
        }
        else
        {

        }
    }

    
}
