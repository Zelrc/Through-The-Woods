using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum SkillType
{
    Melee,
    Projectile,
    AoE,
    Heal,
    SelfBuff
}
public class AbilitySO : ScriptableObject
{
    public new string name;

    public Sprite skillSprite;
    public SkillType type;

    public int CD;
    public bool active = false;

    public int damage;

    public CharacterScripts character;

    public float animationTime;
    public void Start()
    {
        

    }
     
    
    public virtual void Activate(CharacterScripts character)
    {
        
    }

    public virtual void UseSkill(CharacterScripts character)
    {

    }

    public virtual void Deactivate(CharacterScripts character)
    {

    }
}
