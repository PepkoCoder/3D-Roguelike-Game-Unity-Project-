using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {

    public int damage;
    public Vector3 knockbackDir;

    public virtual void OnTriggerEnter(Collider other)
    {
        Health health = other.gameObject.GetComponent<PlayerHealth>();

        if (health != null)
        {

            if(knockbackDir == Vector3.zero)
            {
                knockbackDir = (other.transform.position - transform.position).normalized;
            }
            health.GiveDamage(damage, knockbackDir);

            if(GetComponent<ChargerEnemy>() != null)
            {
                GetComponent<ChargerEnemy>().Wait();
            }
        }
    }

    public virtual void OnCollisionEnter(Collision other)
    {
        Health health = other.gameObject.GetComponent<PlayerHealth>();

        if (health != null)
        {
            if (knockbackDir == Vector3.zero)
            {
                knockbackDir = (other.transform.position - transform.position).normalized;
            }
            health.GiveDamage(damage, knockbackDir);
        }
    }
}
