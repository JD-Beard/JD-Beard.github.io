using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour {


	public float walkSpeed;  //player moving speed.
	private Vector3 dir;   //player directions.
	public GameObject pickupEffect; // pick up item effects
	private bool isDead; // player dead on a bool.
	//public GameObject resetbutton;
	//public GameObject levelSelect;
	//public GameObject mainMenu;
	//public GameObject mainbackground;
	private ScoreManager thescoreManager; // score script
	public Animator GameOver; // gameover animation.
	//public LayerMask whatIsGround;  //ground for the player
	//private bool isPlaying = false;  // Indicates if the player is playing the game.
	//public Transform contactPoint; // A ref to the contactpoint.
	public Animator anim;
	private Vector3 playerTurn;






	void Start () {
	
	
		isDead = false; //your not dead.
		dir = Vector3.zero;  //don't move the player.
		thescoreManager = FindObjectOfType<ScoreManager>(); //getting my score script.
		thescoreManager.scoreCount = 0; //start with a score of 0.
		anim.GetComponent<Animator>();




	}


	void Update () {
	
	

		if (Input.GetMouseButtonDown (0) && !isDead) {  // if mouse is down do this and if player is not dead.
			thescoreManager.scoreIncreasing =true ; //make the score true to begin counting.
			anim.SetTrigger ("PlayerMove");
			if (dir == Vector3.forward) {  //if player is moving forward then move left when click.
				
				dir = Vector3.left; // go left when the player was moving forward.
				transform.rotation = Quaternion.LookRotation(dir);

			} else {


				dir = Vector3.forward;  //else keep moving forward.

			

			}



		
		}

		float timeToMove = walkSpeed * Time.deltaTime;  // move the player * speed with time.
		transform.Translate (dir * timeToMove);//translate player direction with the timeToMove which is speed.



	}




	void OnTriggerEnter(Collider col){ //collider for the item pick up

		if (col.tag == "Item") {

			col.gameObject.SetActive (false); // make the item disappear when the player touch it.
			Instantiate (pickupEffect, transform.position, Quaternion.identity); // instantiate the pick up items in the game.
			thescoreManager.scoreCount += 3;  // the score for every item collected.
			thescoreManager.scoreText.text = "Score: " + thescoreManager.scoreCount.ToString (); // add the score to the display screen.

		}


	}

	void OnTriggerExit(Collider col){ //collider for the player.

		if (col.tag == "Floor") {

			RaycastHit hit; //raycast for the player

			Ray downRay = new Ray (transform.position, -Vector3.up); // cast a ray down to the floor to check the distance for death.

			if (!Physics.Raycast (downRay, out hit)) { // if the raycast is not touching the floor.

				isDead = true;  //kill the player
				thescoreManager.scoreIncreasing = false; //turn the score off when killed.
				GameEnds();

				//resetbutton.SetActive (true); //turn on the menu buttons.
				//levelSelect.SetActive (true); //turn on the menu buttons.
				//mainMenu.SetActive (true);//turn on the menu buttons.
				//mainbackground.SetActive (true); //turn on the menu buttons background.

				if (transform.childCount > 0) {
					transform.GetChild (0).transform.parent = null; // checking my child count is 0 if so make it null.
				}
			}
		}

	}


	private void GameEnds(){ //gameover animation being call function.


		GameOver.SetTrigger("GameOver"); // set the animation to true.
		thescoreManager.endScoreText.text = thescoreManager.scoreCount.ToString (); // display the score in the animation.
	


	}

	//private void IsGrounded(){


		//Collider[] colliders = Physics.OverlapSphere (contactPoint.position, .5f, whatIsGround);

			//for(int i = 0; i < colliders.Length; i++){

				//if(colliders[i].gameObject !=gameObject){

					//return true;
				//}
			//}
			//	return false;
	//}



}
