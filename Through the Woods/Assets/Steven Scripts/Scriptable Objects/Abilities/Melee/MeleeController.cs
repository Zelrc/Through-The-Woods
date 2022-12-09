using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeController : MonoBehaviour
{
    public MeleeSlam slamScript;

    void Update()
    {
        if(slamScript.active == true)
        {
            if(slamScript.character.AoECircle.GetComponent<EnemyDetectingAoE>().areEnemies == true)
            {
                
                slamScript.character.agent.isStopped = true;
                slamScript.character.AoECircle.GetComponent<EnemyDetectingAoE>().GetTargets();
                

                foreach (Collider2D enemy in slamScript.character.AoECircle.GetComponent<EnemyDetectingAoE>().enemies)
                {
                    if (enemy.GetComponent<EnemyScript>())
                    {
                        enemy.GetComponent<EnemyScript>().health -= slamScript.damage;
                    }

                }
                StartCoroutine(AnimationCour());
                slamScript.active = false;
                slamScript.character.AoECircle.SetActive(false);
            }

            
            
        }
    }

    IEnumerator AnimationCour()
    {
        //yield return null;
        yield return new WaitForSeconds(slamScript.animationTime);
        slamScript.character.agent.isStopped = false;
        Debug.Log("should continue to go");
    }
}
