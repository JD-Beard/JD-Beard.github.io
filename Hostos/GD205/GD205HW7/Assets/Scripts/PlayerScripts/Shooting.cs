using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Shooting : MonoBehaviour {

	public GameObject bullet;      //Bullet
	public bool applyForce = true;  // Force
	public LineRenderer line;
	public int speed;        //bullet speed
	public int ammo = 50;   //total ammo
	public Vector3 shootFromHere;  //shot start from.
	public Text text;  //display of ammo.
	float timer;
	float DisplayTime = 0.2f;
	public float timeBetweenShots = 0.15f;
	bool isShooting;





	// Use this for initialization
	void Start () {
	
		line = gameObject.AddComponent<LineRenderer> ();
		isShooting = true;

	}
	
	// Update is called once per frame
	void Update () {

		timer += Time.deltaTime;
	
		shootFromHere = new Vector3( Camera.main.transform.position.x,Camera.main.transform.position.y, Camera.main.transform.position.z+3);   // add 1 so the bullet doesnt hit the player.

		text.text = "Ammo: " + ammo;

		if(Input.GetMouseButtonDown (0) && timer >=timeBetweenShots){
			if(ammo > 0){
			SpawnBulletPrefab();
			ammo--;

		}
	    }

		if (timer >= timeBetweenShots * DisplayTime) { //delaying on firing

			StopShooting ();
		} 
	}


	void StopShooting(){

		isShooting = false;
	}


	void SpawnBulletPrefab(){
		isShooting = true;
		timer = 0f;
		GameObject bulletCloned;
		bulletCloned = Instantiate (bullet, shootFromHere, Quaternion.identity) as GameObject;
		bulletCloned.gameObject.GetComponent<Rigidbody>().velocity = Camera.main.transform.forward * 100;

	}

	void SpawnBulletRayCast(){

		RaycastHit hit;
		Ray myRay = new Ray (shootFromHere, Camera.main.transform.forward);
		if (Physics.Raycast (myRay, out hit, Mathf.Infinity)) {

			Debug.Log ("hit");

			line.SetPosition (0, transform.position);
			line.SetPosition (1, hit.point);


		}
	}

	void OnTriggerEnter(Collider collision){

		if (collision.GetComponent<Collider>().tag == "Ammo"){

			Debug.Log ("Working?");
			//GameObject FirstPersonCharacter = GameObject.Find ("FirstPersonCharacter");
			//Shooting shooting = FirstPersonCharacter.GetComponent<Shooting> ();
			//shooting.ammo = 2;
			//Destroy (this.gameObject);
		}


	}

}



