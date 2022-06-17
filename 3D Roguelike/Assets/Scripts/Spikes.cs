using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spikes : MonoBehaviour {

    public int damage = 25;

    bool attacked = false;

    private void OnTriggerEnter(Collider other)
    {
        Health health = other.gameObject.GetComponent<PlayerHealth>();

        if (health != null && !attacked)
        {
            health.GiveDamage(damage, Vector3.one);
           
            attacked = true;
        }
    }

    void OnTriggerExit(Collider other)
    {
        attacked = false;
    }
}
