using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public Transform playerSpawnPoints; //parent of spawn points
	public bool ReSpawn = false;

	private Transform[] SpawnPoints;
	private bool lastToggle = false;

	// Use this for initialization
	void Start () {
		SpawnPoints = playerSpawnPoints.GetComponentsInChildren<Transform> ();
		Debug.Log (SpawnPoints.Length);
	}
	
	// Update is called once per frame
	void Update () {

		if (lastToggle != ReSpawn) {
			Respawn ();
			ReSpawn = false;
		} else {
			lastToggle = ReSpawn;
		}
		 
	}

	private void Respawn() {
		int i = Random.Range (1, SpawnPoints.Length);
		transform.position = SpawnPoints [i].transform.position;
	}
}
