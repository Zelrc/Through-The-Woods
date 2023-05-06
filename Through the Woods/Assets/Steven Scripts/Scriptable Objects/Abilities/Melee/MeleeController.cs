using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DragLine;

public class MeleeController : MonoBehaviour
{
    public MeleeSlam slamScript;

    bool skillTurnOff= false;

    private void Start()
    {
        slamScript.active = false;
    }
    void Update()
    {
        if(slamScript.active == true)
        {
            slamScript.character.AoECircle.SetActive(true);
            if (ActionPhase)
            {
                //slamScript.character.agent.isStopped = false;
                
                skillTurnOff = true;

                if (slamScript.character.AoECircle.GetComponent<EnemyDetectingAoE>().areEnemies == true)
                {
                    slamScript.character.agent.ResetPath();
                    slamScript.character.agent.isStopped = true;
                    
                    slamScript.character.AoECircle.GetComponent<EnemyDetectingAoE>().GetTargets();

                    if(slamScript.character.AoECircle.GetComponent<EnemyDetectingAoE>().enemyList != null)
                    {
                        
                            foreach (Collider2D enemy in slamScript.character.AoECircle.GetComponent<EnemyDetectingAoE>().enemyList)
                            {
                                if (enemy.gameObject.GetComponent<EnemyScript>())
                                {
                                    enemy.GetComponent<EnemyScript>().health -= slamScript.damage;
                                    enemy.GetComponent<EnemyScript>().GetHurt(this.transform);


                                    //slamScript.character.AoECircle.GetComponent<EnemyDetectingAoE>().areEnemies = false;
                                        
                                    //slamScript.character.AoECircle.GetComponent<EnemyDetectingAoE>().enemyList = new List<Collider2D>();
                                }

                            }
                            //StartCoroutine(AnimationCour());
                            slamScript.active = false;
                            slamScript.character.AoECircle.SetActive(false);
                        slamScript.character.AoECircle.GetComponent<EnemyDetectingAoE>().enemyList.Clear();
                        slamScript.character.AoECircle.GetComponent<EnemyDetectingAoE>().areEnemies = false;
                        //StartCoroutine(startAnimation());
                        slamScript.character.anim.SetTrigger("AoE");
                        if (!slamScript.playedSound)
                        {
                            AudioManager.Instance.Play("MeleeSlam");
                            slamScript.playedSound = true;
                        }


                    }
                    else
                    {
                        slamScript.character.AoECircle.GetComponent<EnemyDetectingAoE>().areEnemies = false;
                    }

                    
                }
                else
                {
                    
                    //slamScript.character.AoECircle.SetActive(false);
                }
            }
            
            
                
                //slamScript.character.AoECircle.SetActive(false);
            
        }
        else
        {
            //if(ActionPhase)
            //{
            //    slamScript.character.AoECircle.SetActive(false);
            //}
            
        }

        if (!ActionPhase)
        {
            if (skillTurnOff)
            {
                skillTurnOff = false;
                slamScript.active = false;
                slamScript.character.AoECircle.SetActive(false);

            }
        }
    }

    IEnumerator startAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        slamScript.character.anim.SetTrigger("AoE");
    }
}
