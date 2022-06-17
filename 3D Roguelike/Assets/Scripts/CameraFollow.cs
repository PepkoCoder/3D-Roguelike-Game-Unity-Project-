using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {
    
    public float yOffset = 15;
    public float xzOffset = -10;
    public Transform player;
	
	// Update is called once per frame
	void LateUpdate () {

        Vector3 pos = new Vector3(player.position.x + xzOffset, yOffset, player.position.z + xzOffset);

        transform.position = Vector3.Lerp(transform.position, pos, .1f);

	}
}
