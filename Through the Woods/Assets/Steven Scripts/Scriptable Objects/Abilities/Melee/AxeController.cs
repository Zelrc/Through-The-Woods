using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DragLine;

public class AxeController : MonoBehaviour
{
    public AxeAttack axeScript;

    bool skillTurnOff = false;

    private void Start()
    {
        axeScript.active = false;
    }
    void Update()
    {
        if (axeScript.active == true)
        {
            if (ActionPhase)
            {
                //axeScript.character.agent.isStopped = false;

                skillTurnOff = true;
                if (axeScript.character.AoECircle.GetComponent<EnemyDetectingAoE>().areEnemies == true)
                {
                    axeScript.character.agent.ResetPath();
                    axeScript.character.agent.isStopped = true;

                    axeScript.character.AoECircle.GetComponent<EnemyDetectingAoE>().GetTargets();

                    if (axeScript.character.AoECircle.GetComponent<EnemyDetectingAoE>().enemies != null)
                    {
                        //foreach (Collider2D enemy in axeScript.character.AoECircle.GetComponent<EnemyDetectingAoE>().enemyList)
                        //{
                        Collider2D enemy = axeScript.character.AoECircle.GetComponent<EnemyDetectingAoE>().enemyList[0];
                            if (enemy.gameObject.GetComponent<EnemyScript>())
                            {
                                enemy.GetComponent<EnemyScript>().health -= axeScript.damage;
                                enemy.GetComponent<EnemyScript>().GetHurt(this.transform);

                                axeScript.character.AoECircle.GetComponent<EnemyDetectingAoE>().areEnemies = false;

                                axeScript.character.AoECircle.GetComponent<EnemyDetectingAoE>().enemyList.Remove(enemy);
                                
                            }

                        //}
                        //StartCoroutine(AnimationCour());
                        axeScript.active = false;
                        axeScript.character.AoECircle.SetActive(false);
                        axeScript.character.anim.SetTrigger("Attack");

                        if(!axeScript.playedSound)
                        {
                            AudioManager.Instance.Play("AxeAttack");
                            axeScript.playedSound = true;
                        }
                        //StartCoroutine(startAnimation());


                    }
                    else
                    {
                        axeScript.character.AoECircle.GetComponent<EnemyDetectingAoE>().areEnemies = false;
                    }


                }
                else
                {

                    //axeScript.character.AoECircle.SetActive(false);
                }
            }
            else
            {
                //if (skillTurnOff)
                //{
                //    skillTurnOff = false;
                //    axeScript.active = false;
                //    axeScript.character.AoECircle.SetActive(false);

                //}
                //axeScript.character.AoECircle.SetActive(false);
            }
            
        }
        else
        {
            //if (ActionPhase)
            //{
            //    axeScript.character.AoECircle.SetActive(false);
            //}

            

        }

        if (!ActionPhase)
        {
            if (skillTurnOff)
            {
                skillTurnOff = false;
                axeScript.active = false;
                axeScript.character.AoECircle.SetActive(false);
            }
        }
    }

    IEnumerator startAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        axeScript.character.anim.SetTrigger("Attack");

    }
}
