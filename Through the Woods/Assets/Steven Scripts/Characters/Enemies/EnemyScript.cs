using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyScript : MonoBehaviour
{
    public EnemySOs enemy;

    SpriteRenderer image;


    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(After1Frame());
        image = GetComponent<SpriteRenderer>();
        image.sprite = enemy.art;
    }

    IEnumerator After1Frame()
    {
        yield return null;
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
