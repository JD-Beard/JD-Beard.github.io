using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public Vector3 playerSpeed = new Vector3 (0f, 0f, 0f);
	public GameObject player;
	// Use this for initialization

	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//player movement of up and down.
	
		if (Input.GetKey ("up")) {

			player.transform.Translate (playerSpeed);
		}

		if (Input.GetKey ("down")) {

			player.transform.Translate (-playerSpeed);
		}
	}
}
