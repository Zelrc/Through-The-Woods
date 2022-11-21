using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum EnemyType
{
    Melee,
    Ranged
}

[CreateAssetMenu(fileName = "Enemy", menuName = "Character/Enemy")]
public class EnemySOs : ScriptableObject
{
    public new string name;

    public EnemyType type;

    public int AP;
    public int health;
    public int attack;

    public Animation anim;
    public Sprite art;
}
