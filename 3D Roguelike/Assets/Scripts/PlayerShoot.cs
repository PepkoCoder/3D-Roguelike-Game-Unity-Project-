using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {
    public Transform[] projectiles;
    public Transform[] shootPosition;

	PlayerAnimation anim;

	public float fireRate = 10f;
    public float bulletAmount = 1;
	float nextShotTime = 0f;

    public int projectileIndex = 0;

	void Start() {
        anim = GetComponent<PlayerAnimation>();
	}
	
	void Update() {
        if (Input.GetKey(KeyCode.Space) && Time.time >= nextShotTime)
        {
            anim.Shoot();
            nextShotTime = Time.time + (60 / fireRate);

            for(int i = 0; i < bulletAmount; i++)
            {
                Transform p = Instantiate(projectiles[projectileIndex], shootPosition[i].position, Quaternion.identity);
                p.forward = transform.forward;
                p = null;
            }

        }

        CheckUpgrades();
	}	  
    
    void CheckUpgrades()
    {
        if (bulletAmount > shootPosition.Length) bulletAmount = shootPosition.Length - 1;
        if (projectileIndex > projectiles.Length) projectileIndex = projectiles.Length - 1;
    }
}