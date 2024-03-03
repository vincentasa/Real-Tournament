using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    NavMeshAgent agent;
    Transform target;
    Health health;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        if (target == null) target = GameObject.Find("Player").transform;
    }

    void Update()
    {
        agent.destination = target.position;
    }
}