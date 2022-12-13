using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static InGameUI;
using DG.Tweening;
using UnityEngine.AI;

public class CameraController : MonoBehaviour
{
    [SerializeField] Transform cameraPoint2;
    [SerializeField] Transform characterPoint2;

    [SerializeField] Transform cameraPoint3;
    [SerializeField] Transform characterPoint3;

    [SerializeField] int enemyThreshold1;
    [SerializeField] int enemyThreshold2;

    [SerializeField] GameObject MC;


    bool stage2 = false;
    bool stage3 = false;

    Camera camera;

    // Start is called before the first frame update
    void Start()
    {
        camera = Camera.main;
    }

    // Update is called once per frame
    void Update()
    {
        if(killCount >= enemyThreshold2 && !stage3)
        {
            camera.transform.DOMove(cameraPoint3.position, 1.0f);
            MC.GetComponent<NavMeshAgent>().ResetPath();
            MC.GetComponent<NavMeshAgent>().isStopped = false;
            MC.GetComponent<NavMeshAgent>().SetDestination(characterPoint3.position);
            MC.GetComponent<CharacterScripts>().health++;
            stage3 = true;
        }
        else if(killCount >= enemyThreshold1 && !stage2)
        {
            camera.transform.DOMove(cameraPoint2.position, 1.0f);
            MC.GetComponent<NavMeshAgent>().ResetPath();
            MC.GetComponent<NavMeshAgent>().isStopped = false;
            MC.GetComponent<NavMeshAgent>().SetDestination(characterPoint2.position);
            MC.GetComponent<CharacterScripts>().health++;
            stage2 = true;
        }
    }
}
