using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpgradeManager : MonoBehaviour {

    [SerializeField]
	private List<Vector3> spawns = new List<Vector3>();

    [SerializeField]
	private List<GameObject> upgrades = new List<GameObject>();

	void Start() {
		for(int i = 0; i < spawns.Count; i++) {
			int rand = Random.Range(0, upgrades.Count-1);

			Instantiate(upgrades[rand], spawns[i], Quaternion.identity);
		}
	}
}