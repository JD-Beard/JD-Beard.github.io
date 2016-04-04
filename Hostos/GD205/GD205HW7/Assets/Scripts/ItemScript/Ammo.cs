using UnityEngine;
using System.Collections;


public class Ammo : MonoBehaviour {
	public GameObject ammoBox; //
	public float spinSpeed;
	public AudioSource soundItem;
	public float floatPower;
	public float randomRoation;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		//ammoBox.transform.Rotate (Vector3.right * Time.deltaTime * spinSpeed, Space.World);
		ammoBox.transform.GetComponent<Rigidbody>().AddForce(Vector3.up * floatPower);
		ammoBox.transform.Rotate (randomRoation, randomRoation, randomRoation);
	}



	void OnCollisionEnter(Collision col){

		if (col.gameObject.tag == "Player") {
			
			GameObject FirstPersonCharacter = GameObject.Find ("FirstPersonCharacter");
			Shooting shooting = FirstPersonCharacter.GetComponent<Shooting> ();
			shooting.ammo++;

			Destroy (gameObject);

		}

		if (col.gameObject.tag == "Player") {

			soundItem.Play ();

		}
	}


}