using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
public class wolfControllder : MonoBehaviour {

    public Animator animator;
    public NavMeshAgent agent;
    public GameObject target;

	void Start () {

        agent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();

        target = GameObject.Find("Kirito_def");
	}

	void Update () {

        agent.SetDestination(target.transform.position);
        
        if (Vector3.Distance(agent.transform.position, target.transform.position) >= 20f)
        {
            animator.Play("01_Run");
            agent.speed = 10;
        }

        if (Vector3.Distance(agent.transform.position, target.transform.position) <= 16f && Vector3.Distance(agent.transform.position, target.transform.position) > agent.stoppingDistance)
        {
            animator.Play("02_walk");
            agent.speed = 7;
        }

        if (Vector3.Distance(agent.transform.position, target.transform.position) <= agent.stoppingDistance)
        {
            agent.speed = 0;
            animator.Play("04_Idle");
        }
    }
}
