using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DetectionRange : MonoBehaviour
{
    public bool detected= false;
    bool trueDetected;
    public GameObject target;
    GameObject parent;

    float longestDistance = 100;

    Collider2D[] targets;

    

    private void Start()
    {
        parent = transform.parent.gameObject;
    }

    private void Update()
    {
        targets = Physics2D.OverlapCircleAll(parent.transform.position, transform.localScale.x - 0.02f);

        trueDetected = false;
        if(targets != null)
        {
            foreach(Collider2D character in targets)
            {
                if(character.GetComponent<CharacterScripts>())
                {
                    detected = true;
                    trueDetected = true;
                    float distance = Vector2.Distance(parent.transform.position, character.transform.position);
                    if (distance < longestDistance)
                    {
                        longestDistance = distance;
                        target = character.gameObject;
                    }
                }
                else
                {
                    if(!trueDetected)
                    {
                        detected = false;
                    }
                }
            }
        }
        else
        {
            trueDetected = false;
            detected = false;
            target = null;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.green;
    //    Gizmos.DrawSphere(parent.transform.position, transform.localScale.x - 0.02f);
    //}
}
