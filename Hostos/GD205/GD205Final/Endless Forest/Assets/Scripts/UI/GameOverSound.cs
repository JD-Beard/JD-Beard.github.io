using UnityEngine;
using System.Collections;

public class GameOverSound : MonoBehaviour {

	public AudioSource gameOver;

	// Use this for initialization
	void Start () {

		gameOver = GetComponent<AudioSource> (); // getting the audiosource.

	}

	// Update is called once per frame
	void Update () {



	}

	public void GameoverSound(){ // function to be call for stopping the sound effect.


		gameOver.Play (); //  playing the sound effect.
	
	}
}