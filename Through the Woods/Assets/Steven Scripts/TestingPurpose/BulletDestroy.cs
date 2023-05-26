using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDestroy : MonoBehaviour
{
    public GameObject feya;
    private void Update()
    {
        if(!DragLine.ActionPhase)
        {
            Destroy(this.gameObject);
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<EnemyScript>())
        {
            collision.gameObject.GetComponent<EnemyScript>().health--;
            collision.gameObject.GetComponent<EnemyScript>().GetHurt(this.transform);
        }
        Destroy(this.gameObject);
    }
}
