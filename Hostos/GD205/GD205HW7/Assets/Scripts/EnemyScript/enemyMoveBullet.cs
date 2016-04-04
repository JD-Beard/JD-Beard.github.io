using UnityEngine;
using System.Collections;

public class enemyMoveBullet : MonoBehaviour {
	public float bulletSpeed;
	public Transform target;
	public AudioSource beamSound;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	


	}

	void FixedUpdate(){

		Vector3 dir = target.position - transform.position;
		GetComponent<Rigidbody> ().velocity = dir.normalized * bulletSpeed;
	}



	void OnCollisionEnter(Collision col){

		if (col.collider.tag == "MainCamera") {
			beamSound.Play ();
			Destroy (gameObject);

		}

		if (col.collider.tag == "MainCamera"){


			GameObject PlayerHealthBar = GameObject.Find ("PlayerHealthBar");
			PlayerHealth playerHealth = PlayerHealthBar.GetComponent<PlayerHealth> ();
			playerHealth.decreaseHealth ();

			}

			}
		

		}

	


