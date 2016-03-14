using UnityEngine;
using System.Collections;

public class MoveBullet : MonoBehaviour {
	public float speed;
	public Transform target;



	// Use this for initialization
	void Start () {
	

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void FixedUpdate(){

		Vector3 dir = target.position - transform.position;
		GetComponent<Rigidbody> ().velocity = dir.normalized * speed;

		// Used to move my bullet in the dir I want.
	


	}

	void OnTriggerEnter(Collider Col){             

		HealthBar life = Col.GetComponentInChildren<HealthBar> ();  //child of the enemy health.

		if (life) {

			life.decreaseHealth ();
			Destroy (gameObject);  //destroy the bullet on impact.



			//This is checking for collider for my HealthBar script and gameobject.
			// To take away the health points if its hit.

		}

	}
}
