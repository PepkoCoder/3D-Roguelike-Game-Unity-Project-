using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimation : MonoBehaviour {

    public Transform graphics;
    Animator anim;

    float yRot;

	void Start () {
        anim = graphics.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        float hor = Input.GetAxisRaw("Horizontal");
        float ver = Input.GetAxisRaw("Vertical");

        if (hor <= -1) yRot = -90;
        else if (hor >= 1) yRot = 90;
        else if (ver >= 1 ) yRot = 0;
        else if (ver <= -1) yRot = 180;
        
        transform.rotation = Quaternion.Euler(0, yRot, 0);
    }

    public void SetMovement(float movement)
    {
        anim.SetFloat("Velocity", movement);
    }

    public void Shoot()
    {
        StartCoroutine(ShootAnimation());
    }

    public void Hurt()
    {
        anim.SetTrigger("Hurt");
    }

    public void Die()
    {
        anim.SetTrigger("Death");
    }

    IEnumerator ShootAnimation()
    {
        anim.SetBool("Shoot", true);
        yield return new WaitForSeconds(.05f);
        anim.SetBool("Shoot", false);
    }
}
