using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public EnemySOs enemy;

    SpriteRenderer image;

    public int health;

    // Start is called before the first frame update
    void Start()
    {
        
        image = GetComponent<SpriteRenderer>();
        //image.sprite = enemy.art;
    }

    

    // Update is called once per frame
    void Update()
    {
        
    }
}
