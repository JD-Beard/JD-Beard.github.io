using UnityEngine;
using System.Collections;

public class StopBackgroundMusic : MonoBehaviour {
	public AudioSource stopMusic;
	public bool isplaying;


	// Use this for initialization
	void Start () {

		stopMusic = GetComponent<AudioSource> (); // getting the audiosource.
		isplaying = true;
		return;

	

	}

	// Update is called once per frame
	void Update () {

		if (isplaying == false) {

			stopMusic.Stop ();
		}



	}
}



