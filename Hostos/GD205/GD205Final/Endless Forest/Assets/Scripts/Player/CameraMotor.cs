using UnityEngine;
using System.Collections;

public class CameraMotor : MonoBehaviour {

	private Transform lookAtPlayer; // look at the player refs.
	private Vector3 startOffSet; // the offset to the camera.
	private Vector3 moveCamera; // move the camera on a vector3.

	private float transition = 0.0f; // the camera transition.
	private float animationDuration = 1.0f; // how long to play the animation.
	private Vector3 animationOffSet = new Vector3 (0, 5, 2); // in which the animation is offset by.

	// Use this for initialization
	void Start () {
	
		lookAtPlayer = GameObject.FindGameObjectWithTag ("Player").transform; // look for the player tag and look for him.
		startOffSet = transform.position - lookAtPlayer.position; // begin the offset and look at the player.
	}

	void Update(){

		moveCamera = lookAtPlayer.position + startOffSet; // move the camera, look at the player and do the offset.
		moveCamera.x = 0; // camera wont move on the x.
		moveCamera.y = Mathf.Clamp (moveCamera.y, 3, 5); // Clamp the camera in this position.
	
		if (transition > 1.0f) {   // if the transition is this do this.

			transform.position = moveCamera; //move the camera in this position.


		} else { // else do this.
			transform.position = Vector3.Lerp (moveCamera + animationOffSet, moveCamera, transition); // move the camera in all above refs.
			transition += Time.deltaTime * 1 / animationDuration; // timer for the animation.
			transform.LookAt(lookAtPlayer.position + Vector3.up); // look at the person after the animation.

		}



	}
	



}
