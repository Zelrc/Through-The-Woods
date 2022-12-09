using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;
using UnityEngine.AI;

public class DragLine : MonoBehaviour
{
    Vector3 startPos;
    Vector3 endPos;
    Camera camera;
    LineRenderer lr;
    bool dragging;
    public static GameObject character;
    public static GameObject target;
    bool colliderBlock;
    float characterRadius = 0.5f;

    public static bool choosingTarget = false;

    public static bool ActionPhase = false;
    
    HashSet<GameObject> charactersMoving = new HashSet<GameObject>();

    Vector3 camOffset = new Vector3(0, 0, 10);

    public static Action<CharacterScripts> characterCall;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if(!ActionPhase)
        {
            if(!choosingTarget)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if(!choosingTarget)
                    {
                        if (hit.collider != null && hit.transform.tag == "Character")
                        {
                            lr = hit.transform.GetComponent<LineRenderer>();

                            lr.enabled = true;
                            lr.positionCount = 2;
                            startPos = hit.transform.GetComponent<Renderer>().bounds.center;
                            lr.SetPosition(0, startPos);
                            character = hit.transform.gameObject;
                            lr.useWorldSpace = true;
                            dragging = true;

                            characterCall?.Invoke(character.GetComponent<CharacterScripts>());
                        }
                    }
                    else
                    {
                        if(hit.collider != null)
                        {
                            target = hit.transform.gameObject;
                        }
                    }
                    
                }
                if (dragging)
                {
                    if (Input.GetMouseButton(0))
                    {
                        if (colliderBlock)
                        {
                            //show red
                        }

                        endPos = camera.ScreenToWorldPoint(Input.mousePosition) + camOffset;

                        lr.SetPosition(1, endPos);
                    }

                    if (Physics2D.CircleCast(endPos, characterRadius, Vector2.zero, 0))
                    {
                        colliderBlock = true;
                    }
                    else
                    {
                        colliderBlock = false;
                    }

                    if (Input.GetMouseButtonUp(0))
                    {

                        dragging = false;

                        if (!colliderBlock)
                        {
                            charactersMoving.Add(character);
                        }
                        else
                        {
                            lr.enabled = false;
                        }

                    }
                }
            }
            
            
        }
        else
        {

            foreach(GameObject currentCharacter in charactersMoving)
            {
                LineRenderer tempLR = currentCharacter.GetComponent<LineRenderer>();
                currentCharacter.GetComponent<NavMeshAgent>().SetDestination(tempLR.GetPosition(1));
                tempLR.enabled = false;

            }
            StartCoroutine(changePhase());
        }
    }

    IEnumerator changePhase()
    {
        yield return new WaitForSeconds(0.8f);
        ActionPhase = false;
    }

    public void OnActionStage()
    {
        ActionPhase = true;
    }

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawSphere(endPos, 1f);
    //}
}
