using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum CharacterSkills
{
    Fireball,
    Iceball,
    FireSword,
    IceSword,
    Earthquake,
    LightningSpear
}

[CreateAssetMenu(fileName = "Enemy", menuName = "Character/Player Characters")]
public class PlayerSOs : ScriptableObject
{
    public new string name;

    public int health;
    public int attack;

    public Animation anim;
    public Sprite art;

    public CharacterSkills Skill1;
    public CharacterSkills Skill2;
    public CharacterSkills Skill3;
    public CharacterSkills Skill4;
}
