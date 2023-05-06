using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;
using UnityEngine.AI;
using UnityEngine.EventSystems;

public class DragLine : MonoBehaviour
{
    Vector3 startPos;
    Vector3 endPos;
    Camera camera;
    LineRenderer lr;
    bool dragging;
    public static GameObject character;
    public static GameObject target;
    public static bool allyTarget = false;
    bool colliderBlock;
    float characterRadius = 0.5f;

    public static bool choosingTarget = false;

    public static bool ActionPhase = false;
    
    HashSet<GameObject> charactersMoving = new HashSet<GameObject>();

    Vector3 camOffset = new Vector3(0, 0, 10);

    public GameObject selectUI;
    public GameObject skillSelectUI;
    public GameObject skillInfoUI;
    public GameObject mainUI;

    public Button assignedConfirmSkillButton;
    public static Button confirmSkillButton;

    public static int CDint;
    public static int maxCDint;
    public int maxCD;
    public static bool enoughCD = true;

    public bool isTutorial = false;
    bool tutorialClick;
    bool tutorialMoved;
    public static bool tutorialAtk = false;

    public GameObject clickTutorial;
    public GameObject moveTutorial;
    public GameObject atkTutorial;
    public GameObject tutorialPanel;

    public static Action<CharacterScripts> characterCall;
    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
        confirmSkillButton = assignedConfirmSkillButton;
        CDint = maxCD;
        maxCDint = maxCD;
    }

    private void OnEnable()
    {
        InGameUI.closeSkillSelectUI += CloseSelectSkillUI;
        InGameUI.stopMovement += StopMoving;
    }

    private void OnDisable()
    {
        InGameUI.closeSkillSelectUI -= CloseSelectSkillUI;
        InGameUI.stopMovement -= StopMoving;
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if(!ActionPhase)
        {
            if (Input.GetMouseButtonDown(0))
            {
                if (!choosingTarget)
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

                        selectUI.SetActive(true);
                        selectUI.transform.position = character.transform.position;

                        if(isTutorial && !tutorialClick)
                        {
                            clickTutorial.SetActive(false);
                            tutorialClick = true;
                            moveTutorial.SetActive(true);

                        }

                        if(character.GetComponent<CharacterScripts>().SetMoved)
                        {
                            CDint += character.GetComponent<CharacterScripts>().CDcosted;
                            character.GetComponent<CharacterScripts>().SetMoved = false;
                        }
                    }
                    else if(EventSystem.current.currentSelectedGameObject != null)
                    {
                        
                    }
                    else
                    {
                        selectUI.SetActive(false);
                        mainUI.SetActive(false);
                        skillInfoUI.SetActive(false);
                        if(character.GetComponent<CharacterScripts>().AoECircle != null)
                        {
                            character.GetComponent<CharacterScripts>().AoECircle.SetActive(false);
                        }
                    }
                    skillSelectUI.SetActive(false);
                }
                else
                {
                    
                    if (hit.collider != null)
                    {
                        target = hit.transform.gameObject;

                        if((target.GetComponent<CharacterScripts>() && allyTarget) || (target.GetComponent<EnemyScript>() && !allyTarget))
                        {
                            skillSelectUI.SetActive(true);
                            skillSelectUI.transform.position = new Vector3(target.transform.position.x, target.transform.position.y + 1f, target.transform.position.z);
                            
                            if(enoughCD)
                            {
                                confirmSkillButton.interactable = true;
                            }
                            
                        }
                        
                        Debug.Log(target);
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

                    float distance = Mathf.Abs(Vector2.Distance(endPos, startPos));
                    Debug.Log(distance);

                    int CDcost = (int)(distance / 1.0f);
                    //character.GetComponent<CharacterScripts>().CDcosted = CDcost;

                    if (!colliderBlock && distance >= 1.0f && (CDint > CDcost)) //here calculate AP
                    {
                        charactersMoving.Add(character);
                        CDint -= CDcost;
                        character.GetComponent<CharacterScripts>().CDcosted = CDcost;
                        character.GetComponent<CharacterScripts>().SetMoved = true;
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
            selectUI.SetActive(false);
            foreach(GameObject currentCharacter in charactersMoving)
            {
                LineRenderer tempLR = currentCharacter.GetComponent<LineRenderer>();
                tempLR.enabled = false;
                currentCharacter.GetComponent<NavMeshAgent>().SetDestination(tempLR.GetPosition(1));
                //tempLR.enabled = false;
                //charactersMoving.Remove(currentCharacter);
                currentCharacter.GetComponent<CharacterScripts>().CDcosted = 0;
                currentCharacter.GetComponent<CharacterScripts>().SetMoved = false;
            }
            if (isTutorial && !tutorialMoved && tutorialClick && !tutorialAtk)
            {
                tutorialMoved = true;
                moveTutorial.SetActive(false);
                atkTutorial.SetActive(true);

            }

            if (isTutorial && tutorialAtk && tutorialClick && tutorialMoved)
            {
                tutorialPanel.SetActive(false);

            }
        }
    }

    public void CloseSelectSkillUI()
    {
        skillSelectUI.SetActive(false);
    }

    public void StopMoving()
    {
        foreach (GameObject currentCharacter in charactersMoving)
        {
            currentCharacter.GetComponent<NavMeshAgent>().isStopped = true;
            currentCharacter.GetComponent<NavMeshAgent>().ResetPath();
        }
        charactersMoving.Clear();
    }
    

    //private void OnDrawGizmos()
    //{
    //    Gizmos.color = Color.yellow;
    //    Gizmos.DrawSphere(endPos, 1f);
    //}
}
