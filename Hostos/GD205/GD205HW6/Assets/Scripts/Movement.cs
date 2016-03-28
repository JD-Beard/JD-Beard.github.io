using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

	public GameObject enemy;
	public GameObject newEnemy;
	public Vector3 location;
	public float followSpeed;
	Vector3 nearby;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	



		location = enemy.transform.position;
		transform.LookAt (location);

		if (Vector3.Distance (location, transform.position) > 1f) {

			GetComponent<Rigidbody> ().AddForce (Vector3.Normalize (location - transform.position) * followSpeed);

		} else {
			GetComponent<Rigidbody> ().velocity = Vector3.zero;
			///GameObject temp = enemy;

			//MakeSpawn ();
			//Destroy (temp);

		}

		if (Input.GetMouseButtonDown (0)) {

			GameObject temp = enemy;
			MakeSpawn ();
			Destroy (temp);

		}





	}


	
	void MakeSpawn(){

			nearby = location + Random.insideUnitSphere * 2.5f;
			GameObject clone = Instantiate( newEnemy, nearby, Quaternion.identity) as GameObject;

			enemy = clone;

		}


		




	}

