using UnityEngine;
using System.Collections;

public class BallSpawn : MonoBehaviour {

	public Vector3 ballSpeed = new Vector3 (10f, -10f, 0f);
	public ParticleSystem spark;
	public ParticleSystem spark2;
	public AudioClip[] audioClip;
	public float deathTimer;







	// Use this for initialization
	void Start () {
		//controlling particle to be off
		spark.GetComponent<ParticleSystem> ().enableEmission = false;
		spark2.GetComponent<ParticleSystem> ().enableEmission = false;

	}



	// Update is called once per frame
	void Update () {


		//giving movement to the ball
		GetComponent<Rigidbody> ().velocity = ballSpeed;

		deathTimer -= Time.deltaTime;

		if (deathTimer < 0) {

			Destroy (this.gameObject);

		}

	}






	//The ball collision with the objects
	void OnCollisionEnter(Collision collision){

		if (collision.collider.name == "leftPad" || collision.collider.name == "rightPad")
			ballSpeed.x = -ballSpeed.x;
		else if (collision.collider.name == "topPanel" || collision.collider.name == "bottomPanel")
			ballSpeed.z = -ballSpeed.z;
		

		if (collision.collider.name == "leftPanel" || collision.collider.name == "rightPanel") {
			ballSpeed.x = -ballSpeed.x;
		

		}
	}

	//adding the sound action to the array.
	void PlaySound(int clip){

		AudioSource audio = GetComponent<AudioSource> ();
		audio.clip = audioClip[clip];
		audio.Play();


	}

	//void PlayDeath(){
		

			//StartCoroutine(Death());    //Death Coroutine that wasnt working right.

	//}


	//Timer to stop the spark
	IEnumerator stopSpark(){

		yield return new WaitForSeconds(.4f);
		spark.GetComponent<ParticleSystem> ().enableEmission = false;
		spark2.GetComponent<ParticleSystem> ().enableEmission = false;
	}

	//IEnumerator Death(){

		  
			//spark.GetComponent<ParticleSystem> ().enableEmission = true;
			//spark2.GetComponent<ParticleSystem> ().enableEmission = true;          //Couldnt get the sound to work correctly while getting destroy.
			//StartCoroutine (stopSpark ());
		    //PlaySound (1);
		  // yield return new WaitForSeconds (1);
			//Destroy(this.gameObject);




	//}


}











