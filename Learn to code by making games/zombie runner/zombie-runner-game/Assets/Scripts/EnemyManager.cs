using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

	public Transform enemySpawnPoints;
	private Transform[] spawnPoints;
	public bool SpawnEnemy;
	public GameObject Zombie;
//	public GameObject test;
	private float spawnTime = 3f;
	private Transform thisParentEnemySpawn;
	public float maxEnemySpawn = 10;

	// Use this for initialization
	void Start () {
		spawnPoints = enemySpawnPoints.GetComponentsInChildren<Transform> ();
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
		thisParentEnemySpawn = GetComponent<Transform> ();
	}

	// Update is called once per frame
	void Update () {
		if (SpawnEnemy) {
			Instantiate (Zombie, spawnPoints [0].transform.position, spawnPoints [0].transform.rotation);
		} else {
			SpawnEnemy = false;
		}
	}

	void Spawn() {
		float ttlSpawnedZombies = thisParentEnemySpawn.childCount;
		int selectedSpawnPointIndex = Random.Range (0, spawnPoints.Length);
		Debug.Log (ttlSpawnedZombies);

		if (ttlSpawnedZombies < maxEnemySpawn) {
			GameObject zombieSpawn = Instantiate (Zombie, spawnPoints[selectedSpawnPointIndex].transform.position, spawnPoints[selectedSpawnPointIndex].transform.rotation) 
				as GameObject;
			zombieSpawn.transform.parent = thisParentEnemySpawn;
		}
	}


}
