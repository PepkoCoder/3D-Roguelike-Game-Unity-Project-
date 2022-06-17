using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour {

    public int maxHealth;

    //[HideInInspector]
    public int health;

	// Use this for initialization
	void Awake () {
        health = maxHealth;
	}
	
	// Update is called once per frame
	public virtual void Update () {
		
        if(health <= 0)
        {
            Die();
        }

	}

    public virtual void GiveDamage(int damage)
    {
        health -= damage;
    }

    public virtual void GiveDamage(int damage, Vector3 knockback)
    {
        health -= damage;
    }

    public virtual void Die()
    {

    }
}
