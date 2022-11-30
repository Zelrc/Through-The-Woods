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

    public GameObject area;

    public int CD;
    public bool active;

    

    public void Start()
    {
        

    }
     
    
    public virtual void Activate()
    {
        
    }
}
