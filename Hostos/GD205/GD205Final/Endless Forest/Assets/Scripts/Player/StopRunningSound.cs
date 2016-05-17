using UnityEngine;
using System.Collections;

public class StopRunningSound : MonoBehaviour {


	public AudioSource stopRun;



	// Use this for initialization
	void Start () {
	
		stopRun = GetComponent<AudioSource> (); // getting the audiosource.


	}
	
	// Update is called once per frame
	void Update () {
	


	}

	public void StopRun(){ // function to be call for stopping the sound effect.


		stopRun.Stop (); // stop playing the sound effect.



	}
}
