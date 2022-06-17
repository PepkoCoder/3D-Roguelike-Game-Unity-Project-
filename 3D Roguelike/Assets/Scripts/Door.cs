using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour {

    public GameObject nextRoom;
    public Transform spawnPosition;

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            LevelManager.instance.NextRoom(nextRoom);

            Rigidbody playerRG = PlayerManager.instance.player.GetComponent<Rigidbody>();

            playerRG.isKinematic = true;
            PlayerManager.instance.player.transform.position = spawnPosition.position;
            playerRG.isKinematic = false;

        }
    }
}
