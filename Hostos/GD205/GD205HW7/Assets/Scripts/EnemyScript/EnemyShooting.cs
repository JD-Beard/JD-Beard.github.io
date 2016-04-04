using UnityEngine;
using System.Collections;

public class EnemyShooting : MonoBehaviour {


	public GameObject bullet;
	float timer;
	float DisplayTime = 0.2f;
	public float timeBetweenShots = 0.15f;
	private bool isShooting;


	// Use this for initialization
	void Start () {
		isShooting = true;
	}
	
	// Update is called once per frame
	void Update () {
		timer += Time.deltaTime;


		if (timer >= timeBetweenShots * DisplayTime) {

			StopShooting ();
		}

	}

	void OnTriggerStay(Collider co){

		if(co.GetComponent<UnityStandardAssets.Characters.FirstPerson.FirstPersonController>() && timer >=timeBetweenShots){



			GameObject check = (GameObject)Instantiate (bullet, transform.position, Quaternion.identity);
			check.GetComponent<enemyMoveBullet> ().target = co.transform;
			shootAtPlayer ();

		}

	}


	void StopShooting(){

		isShooting = false;
	}


	void shootAtPlayer(){
		timer = 0f;
		isShooting = true;

	}
}
