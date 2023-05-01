using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectingAoE : MonoBehaviour
{
    public Collider2D[] enemies;
    // Start is called before the first frame update
    public bool areEnemies = false;

    public List<Collider2D> enemyList;

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

        //enemyList = new List<Collider2D>();

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
            enemyList = new List<Collider2D>();
            if (!enemyList.Contains(collision))
            {
                enemyList.Add(collision);
            }
        }


    }

    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    areEnemies = true;

    //    if (!enemyList.Contains(collision))
    //    {
    //        enemyList.Remove(collision);
    //    }

    //    if(enemyList.Count == 0)
    //    {
    //        areEnemies = false;
    //    }
    //}

    //private void OnTriggerStay2D(Collider2D collision)
    //{
    //    enemies = new Collider2D[] { };

    //    if (collision.gameObject.GetComponent<EnemyScript>())
    //    {
    //        areEnemies = true;

    //        if (!enemyList.Contains(collision))
    //        {
    //            enemyList.Add(collision);
    //        }

    //    }
    //    else if (collision.gameObject.GetComponent<CharacterScripts>())
    //    { 

    //    }
    //    else
    //    {
    //        areEnemies = false;
    //    }
    //}





}
