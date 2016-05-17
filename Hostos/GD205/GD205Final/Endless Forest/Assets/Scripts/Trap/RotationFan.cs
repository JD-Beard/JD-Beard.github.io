using UnityEngine;
using System.Collections;

public class RotationFan : MonoBehaviour {

	private float spinSpeed = 5f; // the fan spin speed.

	// Use this for initialization
	void Start () {

	}

	// Update is called once per frame
	void Update () {
	
		transform.Rotate (2 ,spinSpeed * Time.deltaTime, 0); // the rotation for the fan moving.
	}
}
