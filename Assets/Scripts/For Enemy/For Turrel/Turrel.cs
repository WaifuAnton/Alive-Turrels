using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Turrel : Enemy {
    public float angle = 90;
    [SerializeField] Transform rayCaster;
    RaycastHit hit;
    NavMeshAgent agent;
	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {
        agent.SetDestination(new Vector3(1, 1, 1));
	}

    private void OnTriggerStay(Collider other)
    {
        CharacterController character = other.gameObject.GetComponent<CharacterController>();
        if (character != null)
            if (Physics.Raycast(rayCaster.position, transform.forward, out hit))
            {

            }
    }

    private void OnTriggerExit(Collider other)
    {
        CharacterController character = other.gameObject.GetComponent<CharacterController>();
        if (character != null)
        {
            agent.isStopped = false;
        }
    }
}
