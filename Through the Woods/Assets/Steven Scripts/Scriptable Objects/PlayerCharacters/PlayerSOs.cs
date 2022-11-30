using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterSkills
{
    LeechAxe,
    AxeSlam,
    GretelParry,
    HomingProjectile,
    Heal,
    BlessingOfTheWind
}
public enum CharacterNames
{
    Hanzel,
    Gretel,
    Fairy
}

[CreateAssetMenu(fileName = "Player", menuName = "Character/Player Characters")]
public class PlayerSOs : ScriptableObject
{
    public new CharacterNames name;

    public int maxHealth;

    public Sprite art;
    public Sprite portrait;

    public AbilitySO Skill1;
    public AbilitySO Skill2;
    public AbilitySO Skill3;
    //public CharacterSkills Skill4;
}
