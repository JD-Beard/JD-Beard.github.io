using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;


public class PlayerMotor : MonoBehaviour {

	private CharacterController controller; //character controlling ref.
	public float playerSpeed;
	public float playerSpeedControl;// player speed
	private Vector3 movePlayer; // where to move the player
	private float verticalSpeed = 0.0f;  // the vertical movement speed.
	private float gravity = 12.0f;  // gravity on the player.
	private float animationDuration = 2.0f; // ammount for the animation.
	public bool isDead; // a bool check for the playerDeath.
	public Animator playeranim; // the players animation refs.
	private ScoreManager thescoreManager; // refs for the score script.
	private StopBackgroundMusic Stoprunning;
	private StopRunningSound stopRun; // refs for the stop the running sound script.
	private GameOverSound gameOverSong;
	public DeathMenu deathmenu; // ref for the gameover menu.
	public ParticleSystem itemEffect; // ref for particle effects.
	public AudioClip[] audioClip; // array for the sounds effect in the game.
	int touchCount; // the touches.
	public float tapSpeed = 0.5f; // the speed of the taps
	int doubleTap = 0; // double tap var.
	int touches = 0; // touch var.





	// Use this for initialization
	void Start () {
	
		controller = GetComponent<CharacterController> ();// getting the controller.
		playeranim = GetComponent<Animator>(); // getting the animator.
		thescoreManager = FindObjectOfType<ScoreManager> (); // getting the score manager.
		stopRun = FindObjectOfType<StopRunningSound> (); // getting the runningsound script.
		Stoprunning = FindObjectOfType<StopBackgroundMusic>(); //find the backgroundmusic
		gameOverSong = FindObjectOfType<GameOverSound> (); // getting gameoversound.
		thescoreManager.scoreCount = 0; // set the score to 0
		thescoreManager.scoreIncreasing = true; // begin the score run time.

	
	}
	
	// Update is called once per frame
	void Update () {


		if (isDead) // if the player is not dead return the call.
			return;

		if (Time.time < animationDuration) { // check if the camera animation finish playing. if not do this.

			controller.Move (Vector3.forward * playerSpeed * Time.deltaTime); // begin moving the character.
		
			return;
		}

		movePlayer = Vector3.zero; // make sure the player is not moving.


		if (controller.isGrounded) {  // check if the player is on the floor.

			verticalSpeed = -0.5f;  //gravity

		} else {

			verticalSpeed -= gravity * Time.deltaTime; // if not turn gravity on.
		}

	

		movePlayer.x = Input.GetAxisRaw ("Horizontal") * playerSpeed; //X - Left and right // keyboard control to test the game.
		if (Input.GetMouseButton (0)) {
			
			if (Input.mousePosition.x > Screen.width / 2)                 // touch to move the player in the game.  
				
				movePlayer.x = playerSpeed- playerSpeedControl; // move right.
	    else
				movePlayer.x = -playerSpeed + playerSpeedControl; // move left.

		}


		//**----Double tap code---//
		touchCount = Input.touchCount; // what are the touch counts.
		foreach (Touch touch in Input.touches) { // a loop to check the touching.

			TouchPhase p = touch.phase; // the phase of the touching screen.
			touches++; // add the count of touches.

			if (p == TouchPhase.Began) { // when to begin the action

				if (touch.tapCount == 2) { // the count of taps needed

					playeranim.SetTrigger ("PlayerJump"); // player jump animation.
					verticalSpeed = 6f; // speed for the high for the player.
					PlaySound (2); // play sound effect.
					doubleTap++; // double tap refs.
				}
			}
		}
			


		movePlayer.y = verticalSpeed;  // up and down.

		movePlayer.z = playerSpeed; 


		controller.Move (movePlayer * Time.deltaTime);
						
				
	}			

			//**-----------------Moving the character with tilting the screen, Not using because there were alot of bugs that I couldnt fix in time.

		//if (Time.time < animationDuration) {

			//transform.Translate (Input.acceleration.x * Time.deltaTime * 0, -Input.acceleration.x * Time.deltaTime * 0, 0); 

		//} else {


			//movePlayer.x = Input.GetAxisRaw ("Horizontal") * playerSpeed;

	
			//transform.Translate (Input.acceleration.x * Time.deltaTime * 4, -Input.acceleration.x * Time.deltaTime * 4, 0); 
	
			
	

			//if (Input.GetMouseButton (0) && controller.isGrounded) {

			//	playeranim.SetTrigger ("PlayerJump"); // player jump animation.
				//verticalSpeed = 5f; // speed for the high for the player.
				//PlaySound (2); // play the jump sound effect.
			//} else {

				//verticalSpeed -= gravity * Time.deltaTime;
		//	}
			
		//**----------------End of the code for the tilt---------//
	

	



	public void SetSpeed(float modifier){ //Speed modifier for the player.

		playerSpeed = 6.0f + modifier; // increase the speed by 5 each time the game gets harder.

	}

	void OnControllerColliderHit(ControllerColliderHit hit){ // check if the player collider is near a object.

		if (hit.point.z > transform.position.z + 0.1f && hit.gameObject.tag == "Enemy") { // if so do this. checking for enemy tags and in front of the player Z axis.

			Death (); // kill the player.
		
		}
			

	}



	public void FinishThisLevel(){

		Stoprunning.isplaying = false;
		stopRun.StopRun();
	}
		

	public void Death(){ // the players death.
		
		isDead = true; // make the player = death.
		playeranim.SetTrigger ("PlayerRun"); // finish the run animation.
		thescoreManager.scoreIncreasing = false; // turn of the score from running.
		StartCoroutine (finishAnimation ()); // begin the finish animation.
		stopRun.StopRun(); // stop the running sound when dead.
		PlaySound(0); // play the death sound effect.
		Stoprunning.isplaying = false;

	



	}

	IEnumerator finishAnimation(){ // play the game over screen after the death animation finish.
		yield return new WaitForSeconds(1); // wait for 2 seconds.
		deathmenu.ToggleEndMenu (); // call the gameover menu.
		gameOverSong.GameoverSound();
	
	

	}

	public void OnTriggerEnter(Collider other) // the collider for the player touching the items.
	{
		if (other.tag == "Item") { // look for the item with a Tag.


			other.gameObject.SetActive (false); // if the player touch the item turn it off.
			Instantiate (itemEffect, transform.position, Quaternion.identity); // begin the particle effect for the item being touch.
			thescoreManager.gemCount++; // add one to the gem count.
			PlaySound (1); // play the pick up sound effect.

		}
			

	}



	void PlaySound(int clip){ // ref the array to add the sounds and play them.

		AudioSource audio = GetComponent<AudioSource> (); // get the audiosource for the array.
		audio.clip = audioClip [clip]; // add the sound to the array list.
		audio.Play (); // play the sound effects.

	}


		
}
