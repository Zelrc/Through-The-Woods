using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDetectingAoE : MonoBehaviour
{
    public Collider2D[] enemies;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void GetTargets()
    {
        enemies = Physics2D.OverlapCircleAll(transform.position, transform.localScale.x);
        
           
    }

    

}
