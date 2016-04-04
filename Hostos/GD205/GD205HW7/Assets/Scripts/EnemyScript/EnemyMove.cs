using UnityEngine;
using System.Collections;


public class EnemyMove : MonoBehaviour {
	
	public GameObject Player;
	public Vector3 location;
	public float followSpeed;

	// Use this for initialization
	void Start () {
		location = Player.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		location = Player.transform.position;
		transform.LookAt (location);

		if (Vector3.Distance (location, transform.position) > 1f) {

			GetComponent<Rigidbody> ().AddForce (Vector3.Normalize (location - transform.position) * followSpeed);
		}else{

			GetComponent<Rigidbody> ().velocity = Vector3.zero;
	
	}




	}



}



