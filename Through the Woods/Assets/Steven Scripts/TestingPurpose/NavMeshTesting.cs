using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.AI;


public class NavMeshTesting : MonoBehaviour
{
    public Transform coordinate;
    public NavMeshAgent agent;
    // Start is called before the first frame update
    void Start()
    {
        
        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        agent.SetDestination(coordinate.position);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
