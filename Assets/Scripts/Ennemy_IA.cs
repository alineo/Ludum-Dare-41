using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Ennemy_IA : MonoBehaviour {

    Transform target;
    NavMeshAgent agent;

    private void Start()
    {
        target = GameObject.Find("Character").transform;
        agent = GetComponent<NavMeshAgent>();
        
    }

    void Update() {
        agent.SetDestination(target.position);
    }
}
