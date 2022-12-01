using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Ability", menuName = "Character/Abilities/MeleeSlam")]
public class MeleeSlam : AbilitySO
{
    public override void Activate(CharacterScripts character)
    {
        character.AoECircle.SetActive(true);
        character.AoECircle.GetComponent<EnemyDetectingAoE>().GetTargets();

        foreach(Collider2D enemy in character.AoECircle.GetComponent<EnemyDetectingAoE>().enemies)
        {

        }
    }
}
