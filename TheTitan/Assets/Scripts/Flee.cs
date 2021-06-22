using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Flee : MonoBehaviour
{
    private NavMeshAgent agent_1;
    public GameObject Enemy;
    public float EnemyDistanceRun = 20.0f;
    public bool canMove;
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.tag = "Jerry";
        agent_1 = GetComponent<NavMeshAgent>();
        canMove = true;
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        // botlar ile Tom arasýndaki mesafe ölçülür, eðer mesafe tom'un distance mesafesinden az ise kaçmaya baþlar.
        float distance = Vector3.Distance(transform.position, Enemy.transform.position);
        anim.SetBool("isRunning", false);

        if (canMove && distance < EnemyDistanceRun)
        {          
            Vector3 dirToEnemy = transform.position - Enemy.transform.position;

            Vector3 newPos = transform.position + dirToEnemy;

            anim.SetBool("isRunning", true);
            
            //yeni bir noktaya taþýr.
            agent_1.SetDestination(newPos);
            
        }
               
     }

}
