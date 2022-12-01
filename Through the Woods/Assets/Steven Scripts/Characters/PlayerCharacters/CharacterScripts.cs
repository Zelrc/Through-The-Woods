using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public enum state
{
    Skill1,
    Skill2,
    Skill3
}
public class CharacterScripts : MonoBehaviour
{
    public PlayerSOs character;

    int health;

    public GameObject AoECircle;


    SpriteRenderer image;
    // Start is called before the first frame update
    
    void Start()
    {
        image = GetComponent<SpriteRenderer>();
        image.sprite = character.art;

        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
