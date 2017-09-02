using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour {

	public PlayerHealth playerHealth;
	public GameObject enemy;
	public float spawnTime = 3f;
	public int spawnAmount = 1;
	public Transform[] spawnPoints;

	void Start () {
		InvokeRepeating ("Spawn", spawnTime, spawnTime);
	}

	void Spawn () {
		if (playerHealth.currentHealth <= 0f) {
			return;
		}

		int spawnPointIndex = Random.Range (0, spawnPoints.Length);

		for (int i = 0; i < spawnAmount; i++) {
			Instantiate (enemy, spawnPoints [spawnPointIndex].position, spawnPoints [spawnPointIndex].rotation);
		}
	}

}
