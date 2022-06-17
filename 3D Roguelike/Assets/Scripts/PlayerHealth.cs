using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : Health {

    float invincibilityTime = 1;
    float timer = 0;

    public GameObject hurtParticles;

    public override void GiveDamage(int damage, Vector3 knockback)
    {
        if(Time.time > timer)
        {
            base.GiveDamage(damage);
            GetComponent<PlayerMovement>().Knockback(knockback);
            GetComponent<PlayerAnimation>().Hurt();

            timer = Time.time + invincibilityTime;
                
            if(health <= 0)
            {
                health = 0;
            }

            GameObject h = (GameObject)Instantiate(hurtParticles, new Vector3(transform.position.x, 1.5f, transform.position.z), Quaternion.identity);
            Destroy(h, 2f);

            FindObjectOfType<AudioManager>().Play("PlayerHurt");
        }

    }

    public override void Die()
    {
        base.Die();

        FindObjectOfType<AudioManager>().Play("PlayerDie");
        GetComponent<PlayerAnimation>().Die();

        GetComponent<PlayerMovement>().enabled = false;
        GetComponent<PlayerShoot>().enabled = false;
        GetComponent<PlayerAnimation>().enabled = false;
    }
}
