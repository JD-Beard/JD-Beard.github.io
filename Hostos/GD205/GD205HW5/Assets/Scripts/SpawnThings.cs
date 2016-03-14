using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class SpawnThings : MonoBehaviour {
	public AudioClip[] audioClip;
	public GameObject[] enemies;
	public Transform[] Spawnpoints;
	public float Spawntimer = 10f;
	public bool waitforPlayer = false;
	public bool startbuttonTimer = false;
	public float waveTimer;
	public bool startNextWave = false;



	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {

		if (startbuttonTimer == true) {
			waveTimer -= Time.deltaTime;           //Timer for the spawning.
		}

		if (waveTimer < 0) {

			CancelInvoke ("Spawn");        //cancel the spawning when the time run out.
			waveTimer = Time.time;     //reset waveTimer to spawn enemies.


		}
			


	}
		

	void enemyRun(){

		if (waitforPlayer == true) {
			InvokeRepeating ("Spawn", Spawntimer, Spawntimer); //keep spawning using a timer 


		} 
			
	}



	public void spawnButton(){
		startbuttonTimer = true; // turn 
		waitforPlayer = true;
		enemyRun ();   //check if the button is click, turned it to true and run enemyRun();
	
	}

	void Spawn(){

		int spawnIndex = Random.Range (0, Spawnpoints.Length);
		int objectIndex = Random.Range (0, enemies.Length);
		Instantiate (enemies [objectIndex], Spawnpoints [spawnIndex].position, Spawnpoints [spawnIndex].rotation);
		SpawnSound(0);

		//This is my same code I used for my random ball spawn, just copy and paste. I was lazying to do something different.
	}



	void SpawnSound(int clip){

		AudioSource audio = GetComponent<AudioSource> ();   //sound for the spawning
		audio.clip = audioClip[clip];
		audio.Play();
	}








 
}
