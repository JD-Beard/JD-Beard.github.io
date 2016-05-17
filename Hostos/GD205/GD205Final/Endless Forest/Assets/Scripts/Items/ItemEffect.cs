using UnityEngine;
using System.Collections;

public class ItemEffect : MonoBehaviour {

	public ParticleSystem itemPS; // ref to the particles.

	// Use this for initialization
	void Start () {
	

		itemPS.GetComponent<ParticleSystem> (); // get the component for particles.
	}
	
	// Update is called once per frame
	void Update () {
	
		if (!itemPS.isPlaying) { // check if the particles are playing. if so do this.

			Destroy (gameObject); // destroy the particles.
		}

	}
}
