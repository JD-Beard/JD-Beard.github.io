
using UnityEngine;
using System.Collections;

public class DeathPrefab : MonoBehaviour {

public	float deathTimer;


	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {


		deathTimer -= Time.deltaTime;
		if (deathTimer < 0) {

			Destroy (this.gameObject);
		}
	
	}
}
