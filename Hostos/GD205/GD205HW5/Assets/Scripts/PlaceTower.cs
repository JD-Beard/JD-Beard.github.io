using UnityEngine;
using System.Collections;

public class PlaceTower : MonoBehaviour {

	public GameObject placeTower;
	private GameObject tower;
	public AudioClip placeSound;
	[HideInInspector][SerializeField] new AudioSource audio;  //Hide the audio in the inspector, was getting a yellow error. which was annoyying.

	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> (); // get sound.
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	private bool canPlaceTower(){

		return tower == null;           //check if any Tower is place.
	}

	void OnMouseUp(){

		if (canPlaceTower ()) {

			tower = (GameObject)
				Instantiate (placeTower, transform.position, Quaternion.identity); //place one of my tower in the place is available to.
			    audio.PlayOneShot(placeSound);   //play sound when place.
	

		}


	}
}
