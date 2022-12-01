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
    bool colliderBlock;
    float characterRadius = 1f;

    static bool ActionPhase = false;
    
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
            if (Input.GetMouseButtonDown(0))
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

                        //lines.Add(newLine);
                        charactersMoving.Add(character);
                        Debug.Log(character);


                    }
                    else
                    {
                        lr.enabled = false;
                    }

                }
            }
        }
        else
        {
            //foreach(movingLines currentLines in lines)
            //{
            //    currentLines.character.transform.DOMove(currentLines.lr.GetPosition(1), 0.8f);
            //    currentLines.lr.SetPosition(0, currentLines.character.GetComponent<Renderer>().bounds.center);

            //    if(Vector2.Distance(currentLines.character.transform.position, currentLines.lr.GetPosition(1)) <= 0.5f)
            //    {
            //        Debug.Log("hi");
            //        currentLines.lr.enabled = true;
            //        currentLines.lr.enabled = false;
            //    }
            //}

            foreach(GameObject currentCharacter in charactersMoving)
            {
                Debug.Log(currentCharacter);
                LineRenderer tempLR = currentCharacter.GetComponent<LineRenderer>();
                //currentCharacter.transform.DOMove(tempLR.GetPosition(1), 0.8f);
                currentCharacter.GetComponent<NavMeshAgent>().SetDestination(tempLR.GetPosition(1));

                //tempLR.enabled = true;
                //tempLR.positionCount = 2;
                //tempLR.useWorldSpace = true;
                //tempLR.SetPosition(0, currentCharacter.GetComponent<Renderer>().bounds.center);

                tempLR.enabled = false;
                
                
                
            }

            //charactersMoving.Clear();
            //lines.Clear();
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
