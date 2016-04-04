using UnityEngine;
using System.Collections;

public class GunAnimation : MonoBehaviour {
	public Animation Gun;
	public AudioSource gunSound;
	float timer;
	float DisplayTime = 0.2f;
	public float timeBetweenShots = 0.15f;
	private bool isPlaying;

	// Use this for initialization
	void Start () {
		isPlaying = true;

	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;

	    
		if (Input.GetMouseButtonDown (0) && timer >=timeBetweenShots) {
			
			soundAnimation ();
			Gun.Play ();
			gunSound.Play ();


		}
		if (timer >= timeBetweenShots * DisplayTime) {

			StopAnimation ();
		}


	}

	void StopAnimation(){

		isPlaying = false;
	}

	void soundAnimation(){
		timer = 0f;
		isPlaying = true;  //Playing animation and sound and reseting the timer and puting the source back to true.


	}
}
