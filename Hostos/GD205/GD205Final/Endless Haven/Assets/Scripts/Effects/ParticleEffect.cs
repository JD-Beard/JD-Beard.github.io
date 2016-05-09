using UnityEngine;
using System.Collections;

public class ParticleEffect : MonoBehaviour {


	private ParticleSystem UpEffect;  
	// Use this for initialization
	void Start () {
	

		UpEffect = GetComponent<ParticleSystem> (); //Get Component.
	}
	
	// Update is called once per frame
	void Update () {
	
		if (!UpEffect.isPlaying) { //check if playing.

			Destroy (gameObject);  //destroy.
		}


	}
}
