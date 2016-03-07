using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {


	public GameObject enemy;
	public GameObject ball;
	Vector3 move = new Vector3 (0f,0f,0f);
	float speed = 2.5f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

		//Pad Ai to move up and down in a range.
	
		float d = ball.transform.position.z - transform.position.z;

		if (d > 0) {
			move.z = speed * Mathf.Min (d, 1.5f);             //Give you a min and max range of where to turn back

		}

		if (d < 0) {

			move.z = -(speed * Mathf.Min (-d, 1.5f));              //Give you a min and max range of where to turn back
		}

		transform.position += move * Time.deltaTime;

		}

		}

		

