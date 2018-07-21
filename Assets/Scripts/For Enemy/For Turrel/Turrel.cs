using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Turrel : Enemy {
    public float angle = 90;
    public float rotationSpeed = 1;
    [SerializeField] Transform shootingPoint;
    [SerializeField] Missile missilePrefab;
    Missile missile;
    RaycastHit hit;
    NavMeshAgent agent;
	// Use this for initialization
	void Start () {
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        agent.SetDestination(new Vector3(1, 1, 1));
	}

    private void OnTriggerStay(Collider other)
    {
        CharacterController character = other.GetComponent<CharacterController>();
        if (character != null)
        {
            Vector3 characterPosition = character.transform.position - transform.position;
            float curAngle = Vector3.Angle(transform.forward, characterPosition);
            if (curAngle <= angle)
            {
                agent.isStopped = true;
                if (Physics.Raycast(transform.position, transform.forward, out hit))
                {
                    character = hit.transform.GetComponent<CharacterController>();
                    if (character != null)
                        if (missile == null)
                            missile = Instantiate(missilePrefab, shootingPoint.position, transform.rotation);
                    Quaternion rotationWay = Quaternion.LookRotation(characterPosition);
                    transform.rotation = Quaternion.Lerp(transform.rotation, rotationWay, rotationSpeed * Time.deltaTime);
                }
            }
            else
                agent.isStopped = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        CharacterController character = other.GetComponent<CharacterController>();
        if (character != null)
        {
            agent.isStopped = false;
        }
    }
}
