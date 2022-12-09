using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectingAoE : MonoBehaviour
{
    public Collider2D[] enemies;
    // Start is called before the first frame update
    public bool areEnemies = false;

    public void GetTargets()
    {
        enemies = Physics2D.OverlapCircleAll(transform.position, transform.localScale.x);
        
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyScript>())
        {
            areEnemies = true;
        }
    }

    



}
