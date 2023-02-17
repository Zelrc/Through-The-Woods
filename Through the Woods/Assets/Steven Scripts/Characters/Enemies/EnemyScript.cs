using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static DragLine;
using static InGameUI;
using UnityEngine.AI;

public enum enemyState
{
    IDLE,
    CHASE,
    ATTACK
}
public class EnemyScript : MonoBehaviour
{
    public EnemySOs enemy;

    SpriteRenderer image;

    public int health;

    public GameObject detectionRangeCircle;

    NavMeshAgent agent;

    Vector2 targetPos;

    LineRenderer lr;

    enemyState state;

    Animator anim;

    Coroutine deathCour;

    

    // Start is called before the first frame update
    void Start()
    {
        image = GetComponent<SpriteRenderer>();
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        lr = GetComponent<LineRenderer>();
        anim = GetComponent<Animator>();
        health = enemy.maxHealth;
        //image.sprite = enemy.art;
    }



    // Update is called once per frame
    void Update()
    {
        if(!ActionPhase)
        {
            if (detectionRangeCircle.GetComponent<DetectionRange>().detected)
            {
                if (Vector2.Distance(transform.position, detectionRangeCircle.GetComponent<DetectionRange>().target.transform.position) <= 1.2f)
                {
                    state = enemyState.ATTACK;
                    anim.SetBool("PlanAttack", true);
                    anim.SetBool("PlanMove", false);
                }
                else
                {
                    anim.SetBool("PlanAttack", false);
                    anim.SetBool("PlanMove", true);
                    state = enemyState.CHASE;
                    lr.enabled = true;
                    lr.positionCount = 2;
                    Vector2 startPos = transform.GetComponent<Renderer>().bounds.center;
                    lr.SetPosition(0, startPos);
                    lr.useWorldSpace = true;
                    lr.SetPosition(1, CalculateDrawingPoint(detectionRangeCircle.GetComponent<DetectionRange>().target));
                    targetPos = CalculatePoint(detectionRangeCircle.GetComponent<DetectionRange>().target);
                }
            }
            else
            {
                state = enemyState.IDLE;
            }
        }
        else
        {
            switch(state)
            {
                case enemyState.IDLE:
                    break;
                case enemyState.ATTACK:
                    anim.SetBool("PlanAttack", false);
                    anim.SetTrigger("Attack");
                    if(detectionRangeCircle.GetComponent<DetectionRange>().target.GetComponent<CharacterScripts>().parryBuff == false)
                    {
                        detectionRangeCircle.GetComponent<DetectionRange>().target.GetComponent<CharacterScripts>().health--;
                        detectionRangeCircle.GetComponent<DetectionRange>().target.GetComponent<CharacterScripts>().anim.SetTrigger("Hit");
                    }
                    else
                    {
                        //health--;
                        //GetHurt();
                    }
                    state = enemyState.IDLE;
                    break;
                case enemyState.CHASE:
                    agent.SetDestination(targetPos);
                    lr.enabled = false;
                    anim.SetBool("PlanMove", false);
                    if (agent.remainingDistance <= agent.stoppingDistance && agent.velocity.sqrMagnitude == 0f)
                    {
                        anim.SetBool("Walk", false);
                    }
                    else
                    {
                        anim.SetBool("Walk", true);
                    }
                    
                    break;

            }
        }

        if(health <= 0)
        {
            if(deathCour == null)
            {
                deathCour = StartCoroutine(deathAnim());
            }
        }
    }

    public void GetHurt()
    {
        anim.SetBool("Walk", false);
        anim.SetTrigger("Hit");
        
    }

    IEnumerator deathAnim()
    {
        anim.SetBool("PlanMove", false);
        anim.SetBool("PlanAttack", false);
        anim.SetTrigger("Dead");
        yield return new WaitForSeconds(2f);
        killCount++;
        Destroy(this.gameObject);
    }

    Vector2 CalculatePoint(GameObject target)
    {
        float dist = Vector2.Distance(transform.position, target.transform.position);
        //float desiredDistance = dist * 8 / 10;

        //Vector2 point = transform.position + target.transform.position * desiredDistance;

        Vector3 AB = target.transform.position - transform.position;
        Vector2 point = (transform.position + (0.5f * dist * AB.normalized));

        return point;
    }

    Vector2 CalculateDrawingPoint(GameObject target)
    {
        float dist = Vector2.Distance(transform.position, target.transform.position);
        //float desiredDistance = dist * 8 / 10;

        //Vector2 point = transform.position + target.transform.position * desiredDistance;

        Vector3 AB = target.transform.position - transform.position;
        Vector2 point = (transform.position + (0.8f * dist * AB.normalized));

        return point;
    }
}
