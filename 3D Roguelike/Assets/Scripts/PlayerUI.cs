using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour {

    PlayerHealth ph;
    PlayerMovement pm;
    PlayerShoot ps;

    GameObject player;

    public Transform[] hearts;

    float health = 0;

    public Text weaponIndex;
    public Text speed;

    // Use this for initialization
    void Start () {

        player = GameObject.FindGameObjectWithTag("Player");

        if(player != null)
        {
            ph = player.GetComponent<PlayerHealth>();
            pm = player.GetComponent<PlayerMovement>();
            ps = player.GetComponent<PlayerShoot>();
        }

        health = ph.health;

        ShowHearts();
	}
	
	void Update () {
		
        if(ph.health < health)
        {
            HideHearts();
        } else if(ph.health > health)
        {
            ShowHearts();
        }

        health = ph.health;

        weaponIndex.text = "" + (ps.projectileIndex + 1);
        speed.text = "" + pm.moveSpeed;
	}

    void HideHearts()
    {

        for(int i = ph.health; i < hearts.Length; i++)
        {
            hearts[i].gameObject.SetActive(false);
        }

    }
    void ShowHearts()
    {

        for (int i = 0; i < ph.health; i++)
        {
            hearts[i].gameObject.SetActive(true);
        }

    }

}
