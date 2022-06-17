using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : Enemy {

    public float timeBetweenStates = 2f;
    float timer;

    public float rotationSpeed = 100;
    public float rotationDuration = 2f;
    float rotationTimer = 0;

    public Transform projectile;
    public Transform shootPosition;
    public float fireRate;
    float fireTimer = 0;

    public LayerMask ground;

    public Transform[] spawnPoints;
    public Transform enemy;

    State state = State.IDLE;
    bool jumped, startedJumpingAttack = true, canFall, spinned;

    Transform player;
    Rigidbody rg;
    Vector3 desiredPos;

    PlayerHealth ph;

    void Awake () {
        timer = Time.time + timeBetweenStates;

        player = GameObject.FindGameObjectWithTag("Player").transform;
        rg = GetComponent<Rigidbody>();

        ph = player.GetComponent<PlayerHealth>();

    }
	
	void Update () {
		
        //Set State
        if(Time.time > timer && state == State.IDLE && ph.health > 0)
        {
            timer = Time.time + timeBetweenStates;

            startedJumpingAttack = false;

            int r = Random.Range(0, 4);

            if (r == 0)
            {
                state = State.SPIN;
                rotationTimer = Time.time + rotationDuration;
            }
            else if (r == 1 || r == 2)
            {
                state = State.JUMP;
            }else if(r == 3)
            {
                state = State.SPAWN;
            }
        }

        //Jump State
        if(state == State.JUMP)
        {
            
            if (!startedJumpingAttack)
            {
                StartCoroutine(Jump());
                startedJumpingAttack = true;
                desiredPos = new Vector3(player.position.x, 40, player.position.z);
            }
            
            if (!canFall)
            {
                transform.position = Vector3.Lerp(transform.position, desiredPos, .1f);
            }

            if (transform.position.y <= 1f)
            {
                rg.useGravity = false;

                state = State.IDLE;
                timer = Time.time + timeBetweenStates;
                jumped = false;

                if (!jumped)
                {
                    rg.velocity = Vector3.zero;
                }
            }

        }

        if(state == State.SPIN)
        {
            if(Time.time > rotationTimer)
            {
                timer = Time.time + timeBetweenStates;
                state = State.IDLE;
            }

            transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime);

            if(Time.time > fireTimer)
            {
                fireTimer = Time.time + (60 / fireRate);
                Transform p = Instantiate(projectile, shootPosition.position + transform.forward, Quaternion.identity);
                p.forward = transform.forward;
            }
        }
        
        if(state == State.SPAWN)
        {
            int r = Random.Range(1, 4);

            for(int i = 0; i < r; i++)
            {
                FindObjectOfType<AudioManager>().Play("Slime");
                Instantiate(enemy, spawnPoints[Random.Range(0, spawnPoints.Length)].position, Quaternion.identity);
            }

            state = State.IDLE;
        }

        if (ph.health <= 0) state = State.IDLE;
	}

    IEnumerator Jump()
    {
        rg.useGravity = false;
        canFall = false;
        jumped = true;

        yield return new WaitForSeconds(.5f);

        canFall = true;
        rg.useGravity = true;
        rg.velocity = new Vector3(rg.velocity.x, Physics.gravity.y * 3, rg.velocity.z);
    }
}



public enum State
{
    SPIN,
    JUMP,
    SPAWN,
    IDLE
}
