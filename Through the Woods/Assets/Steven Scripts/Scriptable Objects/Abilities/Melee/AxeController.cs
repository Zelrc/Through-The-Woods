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
                        if (axeScript.character.AoECircle.GetComponent<EnemyDetectingAoE>().enemies.Length != 1)
                        {
                            if(axeScript.character.AoECircle.GetComponent<EnemyDetectingAoE>().enemies[0].GetComponent<EnemyScript>())
                            {
                                axeScript.character.AoECircle.GetComponent<EnemyDetectingAoE>().enemies[0].GetComponent<EnemyScript>().health -= axeScript.damage;
                                axeScript.character.AoECircle.GetComponent<EnemyDetectingAoE>().enemies[0].GetComponent<EnemyScript>().GetHurt(this.transform);

                                if (axeScript.character.AoECircle.GetComponent<EnemyDetectingAoE>().enemies[0].GetComponent<EnemyScript>().health <= 0)
                                {
                                    axeScript.character.AoECircle.GetComponent<EnemyDetectingAoE>().areEnemies = false;

                                    axeScript.character.AoECircle.GetComponent<EnemyDetectingAoE>().enemies = new Collider2D[] { };
                                }
                            }
                            //StartCoroutine(AnimationCour());
                            axeScript.active = false;
                            axeScript.character.AoECircle.SetActive(false);
                            axeScript.character.anim.SetTrigger("Attack");
                            //StartCoroutine(startAnimation());
                        }
                        else
                        {
                            axeScript.character.AoECircle.SetActive(false);
                        }

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

            if(!ActionPhase)
            {
                if (skillTurnOff)
                {
                    skillTurnOff = false;
                    axeScript.active = false;
                    axeScript.character.AoECircle.SetActive(false);
                }
            }

        }
    }

    IEnumerator startAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        axeScript.character.anim.SetTrigger("Attack");
    }
}
