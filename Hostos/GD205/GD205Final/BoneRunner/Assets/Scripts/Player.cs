using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {

	public float speed;  //speed for the player
	private Vector3 dir;  //moving direction




	// Use this for initialization
	void Start () {

		dir = Vector3.zero;  //Making the player not move untill the screen is touch.
	}
	
	// Update is called once per frame
	void Update () {
	
		if (Input.GetMouseButtonDown (0)) {

			if (dir == Vector3.forward) {                //Check to see if the player is moving forward.

				dir = Vector3.left;                      //if so change dir to left.

			} else {
				dir = Vector3.forward;
			}

		}


		float amountToMove = speed * Time.deltaTime;

		transform.Translate (dir * amountToMove);

	}


}
