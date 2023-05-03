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

    float detectionRange;

    bool moved = false;

    public Transform shootingPos;
    public Transform shootingPosUP;
    public GameObject projectile;

    GameObject bullet;

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

        if(enemy.type == EnemyType.Melee)
        {
            detectionRange = 1.2f;
        }
        else if(enemy.type == EnemyType.Ranged)
        {
            detectionRange = 15.0f;
        }
        else if(enemy.type == EnemyType.Boss)
        {
            detectionRange = 6.0f;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(!ActionPhase)
        {
            moved = false;
            anim.SetBool("Walk", false);
            if (detectionRangeCircle.GetComponent<DetectionRange>().detected && health > 0)
            {
                if(Vector2.Distance(transform.position, detectionRangeCircle.GetComponent<DetectionRange>().target.transform.position) < 0.6f)
                {

                }

                if (Vector2.Distance(transform.position, detectionRangeCircle.GetComponent<DetectionRange>().target.transform.position) <= detectionRange)
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
                    
                    if(enemy.type == EnemyType.Melee)
                    {
                        anim.SetTrigger("Attack");
                        if (!detectionRangeCircle.GetComponent<DetectionRange>().target.GetComponent<CharacterScripts>().parryBuff && !detectionRangeCircle.GetComponent<DetectionRange>().target.GetComponent<CharacterScripts>().BOTW)
                        {
                            detectionRangeCircle.GetComponent<DetectionRange>().target.GetComponent<CharacterScripts>().health -= 2;
                            detectionRangeCircle.GetComponent<DetectionRange>().target.GetComponent<CharacterScripts>().anim.SetTrigger("Hit");
                        }
                        else if(detectionRangeCircle.GetComponent<DetectionRange>().target.GetComponent<CharacterScripts>().parryBuff)
                        {
                            health--;
                            GetHurt(detectionRangeCircle.GetComponent<DetectionRange>().target.transform);
                        }
                    }
                    else if(enemy.type == EnemyType.Ranged)
                    {
                        Transform chosenShootingPos;
                        if(detectionRangeCircle.GetComponent<DetectionRange>().target.transform.position.y > transform.position.y)
                        {
                            chosenShootingPos = shootingPosUP;
                        }
                        else
                        {
                            chosenShootingPos = shootingPos;
                        }
                        anim.SetTrigger("Attack");
                        Vector3 aimDir = detectionRangeCircle.GetComponent<DetectionRange>().target.transform.position - chosenShootingPos.position;
                        float angle = Mathf.Atan2(aimDir.y, aimDir.x) * Mathf.Rad2Deg - 90f;
                        bullet = Instantiate(projectile, chosenShootingPos.position, chosenShootingPos.rotation);
                        Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                        rb.AddForce(aimDir * 2.5f, ForceMode2D.Impulse);
                    }
                    else if(enemy.type == EnemyType.Boss)
                    {
                        //Vector3 aimDir;
                        float attkDist = Vector2.Distance(transform.position, detectionRangeCircle.GetComponent<DetectionRange>().target.transform.position);
                        if (attkDist >= 4.0f)
                        {
                            Transform chosenShootingPos;
                            float force;
                            if (detectionRangeCircle.GetComponent<DetectionRange>().target.transform.position.y > transform.position.y)
                            {
                                chosenShootingPos = shootingPosUP;
                                force = 2.5f;
                                //aimDir = chosenShootingPos.position - detectionRangeCircle.GetComponent<DetectionRange>().target.transform.position;
                            }
                            else
                            {
                                chosenShootingPos = shootingPos;
                                force = 2.5f;
                                //aimDir = detectionRangeCircle.GetComponent<DetectionRange>().target.transform.position - chosenShootingPos.position;
                            }
                            anim.SetTrigger("Attack2");
                            Vector3 aimDir = detectionRangeCircle.GetComponent<DetectionRange>().target.transform.position - chosenShootingPos.position;
                            bullet = Instantiate(projectile, chosenShootingPos.position, chosenShootingPos.rotation);
                            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                            rb.AddForce(aimDir * force, ForceMode2D.Impulse);
                        }
                        else
                        {
                            targetPos = CalculatePoint(detectionRangeCircle.GetComponent<DetectionRange>().target);
                            anim.SetTrigger("Attack");
                            agent.SetDestination(targetPos);
                            if(Vector2.Distance(transform.position, detectionRangeCircle.GetComponent<DetectionRange>().target.transform.position) <=2)
                            {
                                if (!detectionRangeCircle.GetComponent<DetectionRange>().target.GetComponent<CharacterScripts>().parryBuff && !detectionRangeCircle.GetComponent<DetectionRange>().target.GetComponent<CharacterScripts>().BOTW)
                                {
                                    detectionRangeCircle.GetComponent<DetectionRange>().target.GetComponent<CharacterScripts>().health -= 3;
                                    detectionRangeCircle.GetComponent<DetectionRange>().target.GetComponent<CharacterScripts>().anim.SetTrigger("Hit");
                                }
                                else if (detectionRangeCircle.GetComponent<DetectionRange>().target.GetComponent<CharacterScripts>().parryBuff)
                                {
                                    health--;
                                    GetHurt(detectionRangeCircle.GetComponent<DetectionRange>().target.transform);
                                    agent.isStopped = true;
                                    agent.ResetPath();
                                }
                            }
                        }
                        
                    }
                    
                    state = enemyState.IDLE;
                    break;
                case enemyState.CHASE:
                    if(moved == false)
                    {
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
                        moved = true;
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

    public void GetHurt(Transform dmgSource)
    {
        anim.SetBool("Walk", false);
        anim.SetTrigger("Hit");
        Vector2 dir = (dmgSource.position - this.transform.position).normalized;

        StartCoroutine(Knockback(dir));
    }

    IEnumerator Knockback(Vector2 dir)
    {
        agent.isStopped = true;
        agent.ResetPath();
        agent.updatePosition = false;

        agent.angularSpeed = 0;
        agent.velocity = -dir * 5;

        yield return new WaitForSeconds(0.3f);

        agent.updatePosition = true;
        agent.angularSpeed = 120;
        agent.velocity = Vector2.zero;
        agent.isStopped = true;
        agent.ResetPath();
        anim.SetBool("Walk", false);
    }

    IEnumerator deathAnim()
    {
        anim.SetBool("PlanMove", false);
        anim.SetBool("PlanAttack", false);
        anim.SetBool("Dead", true);
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
