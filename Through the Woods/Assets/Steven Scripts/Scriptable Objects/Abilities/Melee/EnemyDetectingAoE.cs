using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectingAoE : MonoBehaviour
{
    public Collider2D[] enemies;
    // Start is called before the first frame update
    public bool areEnemies = false;

    private void Update()
    {
        //if (enemies != null)
        //{
        //    for (int i = 0; i < enemies.Length; i++)
        //    {
        //        if (enemies[i].gameObject == this.transform.parent.gameObject)
        //        {
        //            enemies[i] = null;
        //        }
        //    }
        //}
    }
    public void GetTargets()
    {
        enemies = new Collider2D[] { };
        enemies = Physics2D.OverlapCircleAll(transform.position, transform.localScale.x);
     
        
        
        //if(enemies != null)
        //{
        //    for(int i = 0; i < enemies.Length; i++)
        //    {
        //        if (enemies[i].gameObject == this.transform.parent.gameObject)
        //        {
        //            enemies[i] = null;
        //        }

                
        //    }
        //}
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyScript>())
        {
            areEnemies = true;
        }
        
    }

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    if (collision.gameObject.GetComponent<EnemyScript>())
    //    {
    //        areEnemies = true;
    //    }
    //    else
    //    {
    //        areEnemies = false;
    //    }
    //}





}
