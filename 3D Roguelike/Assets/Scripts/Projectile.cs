using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour {

    public float moveSpeed = 15;
    public float timeToLive = 5;
    float spawnTime;

    public int damage;

    Rigidbody rg;
    public GameObject destroyParticles;

    private void Awake()
    {
        spawnTime = Time.time;
        rg = GetComponent<Rigidbody>();
    }

    void Update () {
        
        if(Time.time <= spawnTime + timeToLive)
        {
            rg.velocity = transform.forward * moveSpeed;

        } else
        {
            rg.useGravity = true;
        }

	}

    private void OnTriggerEnter(Collider other) 
    {
        FindObjectOfType<AudioManager>().Play("Projectile");

        if(other.GetComponent<Health>() != null)
        {
            other.GetComponent<Health>().GiveDamage(damage, (other.transform.position - transform.position).normalized);
        }

        GameObject dp = (GameObject)Instantiate(destroyParticles, transform.position, Quaternion.identity);


        Destroy(dp, 1);
        Destroy(gameObject);
    }
}
