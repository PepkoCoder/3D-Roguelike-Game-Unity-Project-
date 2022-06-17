using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(PlayerController))]
public class PlayerMovement : MonoBehaviour {

    public float moveSpeed = 10f;

    PlayerController controller;
    PlayerAnimation anim;

    float yRot = 0;
    float hor;
    float ver;
    Vector3 movement;

    public float knockbackTime;
    public float knockbackAmmount;
    float knockbackCounter = 0;

    void Start () {
        controller = GetComponent<PlayerController>();
        anim = GetComponent<PlayerAnimation>();
	}
	
	void Update () {

        if(knockbackCounter <= 0)
        {
            hor = Input.GetAxisRaw("Horizontal");
            ver = Input.GetAxisRaw("Vertical");

            Vector3 moveDirection = new Vector3(hor, 0, ver);
            movement = moveDirection.normalized * moveSpeed;
            controller.Move(movement);
            anim.SetMovement(movement.normalized.magnitude);
        } else
        {
            knockbackCounter -= Time.deltaTime;
        }
    }

    public void Knockback(Vector3 direction)
    {

        if (knockbackCounter > 0) return;

        knockbackCounter = knockbackTime;

        direction = direction * knockbackAmmount;
        direction.y = knockbackAmmount;

        controller.Knockback(direction);
    }
}
