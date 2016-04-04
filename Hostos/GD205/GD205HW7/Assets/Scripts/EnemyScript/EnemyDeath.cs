using UnityEngine;
using System.Collections;

public class EnemyDeath : MonoBehaviour {
	public GameObject enemyDeath;
	public GameObject ammoPickUp;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	void OnCollisionEnter(Collision col){

		if (col.collider.tag == "Bullet") {

			Instantiate (enemyDeath, transform.position, transform.rotation);
			Instantiate (ammoPickUp, transform.position, transform.rotation);
			Destroy (gameObject);
		}
	}
}
