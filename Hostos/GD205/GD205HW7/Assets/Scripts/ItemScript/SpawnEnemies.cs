using UnityEngine;
using System.Collections;

public class SpawnEnemies : MonoBehaviour {

	public GameObject[] enemies;
	public Transform[] Spawnpoints;
	public float Spawntimer = 10f;
	public bool startingWave = true;
	public bool startNextWave = false;
	public float waveTimer;
	public float startTimer;

	// Use this for initialization
	void Start () {
		

	}
	
	// Update is called once per frame
	void Update () {
	
		if (startingWave == true) {
			startTimer -= Time.deltaTime;

		}
		if (startTimer < 0) {

			beginWave ();
		}
		if (waveTimer < 0) {

			CancelInvoke ("Spawn");
			startingWave = false;
			waveTimer = Time.time;
		}




	}

	void beginWave(){

		InvokeRepeating ("Spawn", Spawntimer, Spawntimer);
		waveTimer -= Time.deltaTime;
	}

	void enemyRun(){

		if (startNextWave == true) {
		   InvokeRepeating ("Spawn", Spawntimer, Spawntimer);
		}
	}





	void Spawn(){

		int spawnIndex = Random.Range (0, Spawnpoints.Length);
		int objectIndex = Random.Range (0, enemies.Length);
		Instantiate(enemies [objectIndex], Spawnpoints [spawnIndex].position, Spawnpoints [spawnIndex].rotation);

	}
}
