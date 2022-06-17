using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class ChargerEnemy : Enemy {

    Transform player;
    NavMeshAgent agent;

    PlayerHealth ph;

    public float speed;

    public float waitTime = 1;
    float waitTimer = 0;

    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        player = GameObject.FindGameObjectWithTag("Player").transform;
        ph = player.GetComponent<PlayerHealth>();
        agent.speed = speed;
    }

    private void Update()
    {
        if(Time.time > waitTimer)
        {
            if(ph.health > 0)
            {
                agent.SetDestination(player.position);
            }
        }

    }

    public void Wait()
    {
        waitTimer = Time.time + waitTime;
    }
}
