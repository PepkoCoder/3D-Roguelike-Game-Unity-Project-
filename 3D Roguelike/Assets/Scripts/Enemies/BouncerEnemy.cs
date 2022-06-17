using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncerEnemy : Enemy {

    Rigidbody rg;
    public Vector3 startDirection;
    Vector3 direction;
    public float speed;

    float bounceTime = 0.01f;
    float bounceTimer;

	// Use this for initialization
	void Start () {
       rg = GetComponent<Rigidbody>();
        direction = startDirection;
        UpdateRotation(direction);

        bounceTimer = 0;
    }

    public override void OnCollisionEnter(Collision other)
    {
        base.OnCollisionEnter(other);

        if (Time.time < bounceTimer) return;

        if (other.transform.tag == "Wall" || other.transform.tag == "Door")
        {
            RaycastHit rayHit;
            Physics.Raycast(transform.position, direction, out rayHit);

            direction = 2 * Vector3.Dot(direction, rayHit.normal.normalized) * rayHit.normal.normalized - direction;
            direction *= -1;

            UpdateRotation(direction);

            bounceTimer = Time.time + bounceTime;
        }
    }

    private void Update()
    {
        rg.velocity = direction * speed;
    }

    void UpdateRotation(Vector3 direction)
    {
        Transform graphics = transform.GetChild(0).transform;

        graphics.rotation = Quaternion.FromToRotation(transform.forward, direction);
    }
}
