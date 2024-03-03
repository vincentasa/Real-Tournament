using UnityEngine;
using UnityEngine.AI;

public class Enemy : MonoBehaviour
{
    Transform target;

    Health health;
    NavMeshAgent agent;

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