using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour {

    protected PlayerHealth ph;
    protected PlayerMovement pm;
    protected PlayerShoot ps;

    protected bool isPlayer = false;

	protected virtual void OnTriggerEnter(Collider other)
    {

        if(other.tag == "Player")
        {
            isPlayer = true;
            ph = other.GetComponent<PlayerHealth>();
            pm = other.GetComponent<PlayerMovement>();
            ps = other.GetComponent<PlayerShoot>();
        }

        if (!isPlayer) return;
    }

    void Update()
    {
        transform.Rotate(Vector3.up * 80 * Time.deltaTime);
    }

    protected void Die()
    {
        Destroy(gameObject);
    }
}
