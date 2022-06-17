using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {
    
    Rigidbody rg;

	// Use this for initialization
	void Start () {
        rg = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void Move(Vector3 movement)
    {
        movement.y = rg.velocity.y;
        rg.velocity = movement;
    }

    public void Knockback(Vector3 knockback)
    {
        rg.AddForce(knockback);
    }
}
