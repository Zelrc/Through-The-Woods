using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DragLine;

public class HammerController : MonoBehaviour
{
    public HammerAttack hammerScript;

    bool skillTurnOff = false;
    // Start is called before the first frame update
    private void Start()
    {
        hammerScript.active = false;
    }
    void Update()
    {
        if (hammerScript.active == true)
        {
            if (ActionPhase)
            {
                //hammerScript.character.agent.isStopped = false;

                skillTurnOff = true;
                if (hammerScript.character.AoECircle.GetComponent<EnemyDetectingAoE>().areEnemies == true)
                {
                    hammerScript.character.agent.ResetPath();
                    hammerScript.character.agent.isStopped = true;

                    hammerScript.character.AoECircle.GetComponent<EnemyDetectingAoE>().GetTargets();

                    if (hammerScript.character.AoECircle.GetComponent<EnemyDetectingAoE>().enemies != null)
                    {
                        //foreach (Collider2D enemy in hammerScript.character.AoECircle.GetComponent<EnemyDetectingAoE>().enemyList)
                        //{
                        Collider2D enemy = hammerScript.character.AoECircle.GetComponent<EnemyDetectingAoE>().enemyList[0];
                        if (enemy.gameObject.GetComponent<EnemyScript>())
                        {
                            enemy.GetComponent<EnemyScript>().health -= hammerScript.damage;
                            enemy.GetComponent<EnemyScript>().GetHurt(this.transform);

                            hammerScript.character.AoECircle.GetComponent<EnemyDetectingAoE>().areEnemies = false;

                            hammerScript.character.AoECircle.GetComponent<EnemyDetectingAoE>().enemyList.Remove(enemy);

                        }

                        //}
                        //StartCoroutine(AnimationCour());
                        hammerScript.active = false;
                        hammerScript.character.AoECircle.SetActive(false);
                        hammerScript.character.anim.SetTrigger("Attack");
                        if (!hammerScript.playedSound)
                        {
                            AudioManager.Instance.Play("AxeAttack");
                            hammerScript.playedSound = true;
                        }
                        //StartCoroutine(startAnimation());


                    }
                    else
                    {
                        hammerScript.character.AoECircle.GetComponent<EnemyDetectingAoE>().areEnemies = false;
                    }


                }
                else
                {

                    //hammerScript.character.AoECircle.SetActive(false);
                }
            }
            else
            {
                //if (skillTurnOff)
                //{
                //    skillTurnOff = false;
                //    hammerScript.active = false;
                //    hammerScript.character.AoECircle.SetActive(false);

                //}
                //hammerScript.character.AoECircle.SetActive(false);
            }

        }
        else
        {
            //if (ActionPhase)
            //{
            //    hammerScript.character.AoECircle.SetActive(false);
            //}



        }

        if (!ActionPhase)
        {
            if (skillTurnOff)
            {
                skillTurnOff = false;
                hammerScript.active = false;
                hammerScript.character.AoECircle.SetActive(false);
            }
        }
    }

    IEnumerator startAnimation()
    {
        yield return new WaitForSeconds(0.5f);
        hammerScript.character.anim.SetTrigger("Attack");
    }
}
