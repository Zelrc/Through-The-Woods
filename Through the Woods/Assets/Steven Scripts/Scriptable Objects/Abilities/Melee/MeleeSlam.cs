using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ability", menuName = "Character/Abilities/MeleeSlam")]
public class MeleeSlam : AbilitySO
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
        //if(character.AoECircle.GetComponent<EnemyDetectingAoE>().areEnemies)
        //{
        //    character.agent.isStopped = true;



        //    character.AoECircle.GetComponent<EnemyDetectingAoE>().GetTargets();

        //    foreach (Collider2D enemy in character.AoECircle.GetComponent<EnemyDetectingAoE>().enemies)
        //    {
        //        if (enemy.GetComponent<EnemyScript>())
        //        {
        //            enemy.GetComponent<EnemyScript>().health -= damage;
        //        }

        //    }
        //}
        character = _character;
        active = true;
        playedSound = false;
    }

    

    

    
}
