using UnityEngine;
using System.Collections;

public class Shooting : MonoBehaviour {


	public GameObject bullet;
	public float spinSpeed;
	public GameObject towerHead;
	public AudioClip bulletSound;
	[HideInInspector][SerializeField] new AudioSource audio;
	// Use this for initialization
	void Start () {
		audio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		towerHead.transform.Rotate (Vector3.up * Time.deltaTime *spinSpeed,Space.World);  // used to rotation my towerhead for a cool effects! Juice!


	}

	void OnTriggerEnter(Collider co){    //check to see if my enemymoving script is near the range of the collider and if
		                                           //so shoot at it.

		if(co.GetComponent<enemyMove>()){

			GameObject check = (GameObject)Instantiate (bullet, transform.position, Quaternion.identity);
			check.GetComponent<MoveBullet> ().target = co.transform;
			audio.PlayOneShot(bulletSound);

	}
}
}
