using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InGameUI;
using DG.Tweening;
using UnityEngine.AI;
using UnityEngine.UI;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform cameraPoint2;
    [SerializeField] Transform gretelPoint2;

    [SerializeField] Transform cameraPoint3;
    [SerializeField] Transform gretelPoint3;

    [SerializeField] Transform cameraPoint4;
    [SerializeField] Transform gretelPoint4;

    [SerializeField] Transform cameraPoint5;
    [SerializeField] Transform gretelPoint5;

    [SerializeField] Transform feyaPoint2;
    [SerializeField] Transform feyaPoint3;
    [SerializeField] Transform feyaPoint4;
    [SerializeField] Transform feyaPoint5;

    [SerializeField] Transform berthaPoint2;
    [SerializeField] Transform berthaPoint3;
    [SerializeField] Transform berthaPoint4;
    [SerializeField] Transform berthaPoint5;

    [SerializeField] int enemyThreshold1;
    [SerializeField] int enemyThreshold2;
    [SerializeField] int enemyThreshold3;
    [SerializeField] int enemyThreshold4;

    [SerializeField] GameObject MC;
    [SerializeField] GameObject Feya;
    [SerializeField] GameObject Bertha;

    [SerializeField] int stages;
    [SerializeField] bool feyaJoined;
    [SerializeField] bool berthaJoined;

    [SerializeField] Button actionButton;

    bool stage2 = false;
    bool stage3 = false;
    bool stage4 = false;
    bool stage5 = false;

    

    Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(killCount >= enemyThreshold1 && !stage2 && stages >= 2)
        {
            camera.transform.DOMove(cameraPoint2.position, 1.5f);
            MC.GetComponent<NavMeshAgent>().ResetPath();
            MC.GetComponent<NavMeshAgent>().isStopped = false;
            MC.GetComponent<NavMeshAgent>().SetDestination(gretelPoint2.position);
            if (MC.GetComponent<CharacterScripts>().health < MC.GetComponent<CharacterScripts>().character.maxHealth)
            {
                MC.GetComponent<CharacterScripts>().health++;
            }

            if(feyaJoined)
            {
                Feya.GetComponent<NavMeshAgent>().ResetPath();
                Feya.GetComponent<NavMeshAgent>().isStopped = false;
                Feya.GetComponent<NavMeshAgent>().SetDestination(feyaPoint2.position);
            }

            if (berthaJoined)
            {
                Bertha.GetComponent<NavMeshAgent>().ResetPath();
                Bertha.GetComponent<NavMeshAgent>().isStopped = false;
                Bertha.GetComponent<NavMeshAgent>().SetDestination(berthaPoint2.position);
            }

            StartCoroutine(TransitionCamera());
            stage2 = true;
        }
        else if(killCount >= enemyThreshold2 && !stage3 && stages >= 3)
        {
            camera.transform.DOMove(cameraPoint3.position, 1.5f);
            MC.GetComponent<NavMeshAgent>().ResetPath();
            MC.GetComponent<NavMeshAgent>().isStopped = false;
            MC.GetComponent<NavMeshAgent>().SetDestination(gretelPoint3.position);
            if (MC.GetComponent<CharacterScripts>().health < MC.GetComponent<CharacterScripts>().character.maxHealth)
            {
                MC.GetComponent<CharacterScripts>().health++;
            }

            if (feyaJoined)
            {
                Feya.GetComponent<NavMeshAgent>().ResetPath();
                Feya.GetComponent<NavMeshAgent>().isStopped = false;
                Feya.GetComponent<NavMeshAgent>().SetDestination(feyaPoint3.position);
            }

            if (berthaJoined)
            {
                Bertha.GetComponent<NavMeshAgent>().ResetPath();
                Bertha.GetComponent<NavMeshAgent>().isStopped = false;
                Bertha.GetComponent<NavMeshAgent>().SetDestination(berthaPoint3.position);
            }

            StartCoroutine(TransitionCamera());
            stage3 = true;
        }
        else if(killCount >= enemyThreshold3 && !stage4 && stages >= 4)
        {
            camera.transform.DOMove(cameraPoint4.position, 1.5f);
            MC.GetComponent<NavMeshAgent>().ResetPath();
            MC.GetComponent<NavMeshAgent>().isStopped = false;
            MC.GetComponent<NavMeshAgent>().SetDestination(gretelPoint4.position);
            if (MC.GetComponent<CharacterScripts>().health < MC.GetComponent<CharacterScripts>().character.maxHealth)
            {
                MC.GetComponent<CharacterScripts>().health++;
            }

            if (feyaJoined)
            {
                Feya.GetComponent<NavMeshAgent>().ResetPath();
                Feya.GetComponent<NavMeshAgent>().isStopped = false;
                Feya.GetComponent<NavMeshAgent>().SetDestination(feyaPoint4.position);
            }

            if (berthaJoined)
            {
                Bertha.GetComponent<NavMeshAgent>().ResetPath();
                Bertha.GetComponent<NavMeshAgent>().isStopped = false;
                Bertha.GetComponent<NavMeshAgent>().SetDestination(berthaPoint4.position);
            }

            StartCoroutine(TransitionCamera());
            stage4 = true;
        }
        else if(killCount >= enemyThreshold4 && !stage5 && stages >= 5)
        {
            camera.transform.DOMove(cameraPoint5.position, 1.5f);
            MC.GetComponent<NavMeshAgent>().ResetPath();
            MC.GetComponent<NavMeshAgent>().isStopped = false;
            MC.GetComponent<NavMeshAgent>().SetDestination(gretelPoint5.position);
            if (MC.GetComponent<CharacterScripts>().health < MC.GetComponent<CharacterScripts>().character.maxHealth)
            {
                MC.GetComponent<CharacterScripts>().health++;
            }

            if (feyaJoined)
            {
                Feya.GetComponent<NavMeshAgent>().ResetPath();
                Feya.GetComponent<NavMeshAgent>().isStopped = false;
                Feya.GetComponent<NavMeshAgent>().SetDestination(feyaPoint5.position);
            }

            if (berthaJoined)
            {
                Bertha.GetComponent<NavMeshAgent>().ResetPath();
                Bertha.GetComponent<NavMeshAgent>().isStopped = false;
                Bertha.GetComponent<NavMeshAgent>().SetDestination(berthaPoint5.position);
            }

            StartCoroutine(TransitionCamera());
            stage5 = true;
        }
    }

    IEnumerator TransitionCamera()
    {
        actionButton.interactable = false;
        yield return new WaitForSeconds(0.5f);
        if(feyaJoined && !berthaJoined)
        {
            while(!(Feya.GetComponent<NavMeshAgent>().pathStatus == NavMeshPathStatus.PathComplete && Feya.GetComponent<NavMeshAgent>().remainingDistance == 0 && MC.GetComponent<NavMeshAgent>().pathStatus == NavMeshPathStatus.PathComplete && MC.GetComponent<NavMeshAgent>().remainingDistance == 0))
            {
                yield return null;
            }
            actionButton.interactable = true;
        }
        else if (feyaJoined && berthaJoined)
        {
            while (!(Feya.GetComponent<NavMeshAgent>().pathStatus == NavMeshPathStatus.PathComplete && Feya.GetComponent<NavMeshAgent>().remainingDistance == 0 && MC.GetComponent<NavMeshAgent>().pathStatus == NavMeshPathStatus.PathComplete && MC.GetComponent<NavMeshAgent>().remainingDistance == 0 && Bertha.GetComponent<NavMeshAgent>().pathStatus == NavMeshPathStatus.PathComplete && Bertha.GetComponent<NavMeshAgent>().remainingDistance == 0))
            {
                yield return null;
            }
            actionButton.interactable = true;
        }
        else
        {
            while(!(MC.GetComponent<NavMeshAgent>().pathStatus == NavMeshPathStatus.PathComplete && MC.GetComponent<NavMeshAgent>().remainingDistance == 0))
            {
                yield return null;
            }
            actionButton.interactable = true;
        }
    }

    private bool CheckPathStatus()
    {
        if(feyaJoined)
        {
            if (Feya.GetComponent<NavMeshAgent>().pathStatus == NavMeshPathStatus.PathComplete && Feya.GetComponent<NavMeshAgent>().remainingDistance == 0 && MC.GetComponent<NavMeshAgent>().pathStatus == NavMeshPathStatus.PathComplete && MC.GetComponent<NavMeshAgent>().remainingDistance == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        else
        {
            if (MC.GetComponent<NavMeshAgent>().pathStatus == NavMeshPathStatus.PathComplete && MC.GetComponent<NavMeshAgent>().remainingDistance == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}
