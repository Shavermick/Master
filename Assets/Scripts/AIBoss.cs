using UnityEngine;
using UnityEngine.AI;

public class AIBoss : MonoBehaviour {

    public string nameSpawn;

    public int maxHP;
    public int realHP;

    public int maxAttack;
    public int minAttack;

    public bool playerEnter;
    public bool spawnEnter;

    public bool fight;

    public GameObject playerTransform;
    public GameObject spawnBoss;

    public NavMeshAgent agent;

    public Animator animator;

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            playerEnter = true;
            spawnEnter = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            playerEnter = false;
        }
    }

    void Start () {
        
        realHP = maxHP;

        playerTransform = GameObject.Find("Kirito_def");

        spawnBoss = GameObject.Find(nameSpawn);

        agent = GetComponent<NavMeshAgent>();

        animator = GetComponent<Animator>();

        spawnEnter = true;
	}
	
	// Update is called once per frame
	void LateUpdate () {

        if (playerEnter && !spawnEnter)
        {
            agent.SetDestination(playerTransform.transform.position);
            animator.Play("walk");

            agent.autoBraking = false;

            if (Vector3.Distance(transform.position, playerTransform.transform.position) >= 10)
            {
                agent.stoppingDistance = 5;
            }            
        }
        else if (!playerEnter && !spawnEnter) 
        {
            agent.SetDestination(spawnBoss.transform.position);
            animator.Play("walk");
            agent.stoppingDistance = 0;
            agent.autoBraking = true;

            if (transform.position == spawnBoss.transform.position)
            {  
                spawnEnter = true;
            }
        }

        if (spawnEnter)
        {
            int Attack = Random.Range(minAttack, maxAttack + 1);
            animator.Play("stand");
        }
    }
}
