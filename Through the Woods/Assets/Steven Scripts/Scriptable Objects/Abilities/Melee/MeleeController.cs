using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeController : MonoBehaviour
{
    public MeleeSlam slamScript;

    private void Start()
    {
        slamScript.active = false;
    }
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
                        enemy.GetComponent<EnemyScript>().GetHurt();
                    }

                }
                //StartCoroutine(AnimationCour());
                slamScript.active = false;
                slamScript.character.AoECircle.SetActive(false);
                StartCoroutine(startAnimation());
            }

            
            
        }
    }

    IEnumerator startAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        slamScript.character.anim.SetTrigger("Attack");
    }
}
