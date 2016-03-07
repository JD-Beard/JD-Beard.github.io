using UnityEngine;
using System.Collections;

public class BallMoving : MonoBehaviour {

	public Vector3 ballSpeed = new Vector3 (10f, -10f, 0f);
	public ParticleSystem spark;
	public ParticleSystem spark2;
	public AudioClip[] audioClip;


	




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

	

	}




	//The ball collision with the objects
	void OnCollisionEnter(Collision collision){

		if (collision.collider.name == "leftPad" || collision.collider.name == "rightPad")
			ballSpeed.x = -ballSpeed.x;
		else if (collision.collider.name == "topPanel" || collision.collider.name == "bottomPanel")
			ballSpeed.z = -ballSpeed.z;
		PlaySound (1);
		spark.GetComponent<ParticleSystem> ().enableEmission = true;
		spark2.GetComponent<ParticleSystem> ().enableEmission = true;
		StartCoroutine (stopSpark ());  //using a coroutine to stop the effect at once.

		if (collision.collider.name == "leftPanel" || collision.collider.name == "rightPanel") {
			ballSpeed.x = -ballSpeed.x;
			PlaySound (0);
			spark.GetComponent<ParticleSystem> ().enableEmission = true;
			spark2.GetComponent<ParticleSystem> ().enableEmission = true;
			StartCoroutine (stopSpark ());    //using a coroutine to stop the effect at once.
		
		}
	}

	//adding the sound action to the array.
	void PlaySound(int clip){

		AudioSource audio = GetComponent<AudioSource> ();
		audio.clip = audioClip[clip];
		audio.Play();


	}
		

	//Timer to stop the spark
	IEnumerator stopSpark(){

			yield return new WaitForSeconds(.4f);
		spark.GetComponent<ParticleSystem> ().enableEmission = false;
		spark2.GetComponent<ParticleSystem> ().enableEmission = false;
		}




		}



	
	
		





