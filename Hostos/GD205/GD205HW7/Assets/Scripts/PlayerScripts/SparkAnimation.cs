using UnityEngine;
using System.Collections;

public class SparkAnimation : MonoBehaviour {
	public GameObject spark;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

		if (Input.GetMouseButtonDown (0)) {


			Instantiate (spark, transform.position, transform.rotation);
		}
	}
}
