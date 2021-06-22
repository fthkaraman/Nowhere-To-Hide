using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Run : MonoBehaviour
{
    public NavMeshAgent agent;
    public Vector3 targetPos;
    public float speed = 12.0f; 
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();       
        anim = GetComponent<Animator>();
        targetPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //gösterilen hedefe ilerlemek için (TouchInputs)
        agent.speed = speed;
        agent.SetDestination(targetPos);
    }
}
