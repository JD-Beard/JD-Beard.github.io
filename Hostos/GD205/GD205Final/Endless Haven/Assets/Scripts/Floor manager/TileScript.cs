using UnityEngine;
using System.Collections;

public class TileScript : MonoBehaviour {


	public float fallDelay;  //the Floor time delay when falling.
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {

	}


	void OnTriggerExit(Collider other){   // if the floor collider is with player do this.

		if (other.tag == "Player") {

			TileManager.Instance.SpawnTile ();  //spawn my floors.
			StartCoroutine (FallDown ());  // begin my coroutine to drop the floor.
			Debug.Log ("Spawning");  // check for bugs! :)

		}
	}


	IEnumerator FallDown(){  //dropping floor script.

		yield return new WaitForSeconds (fallDelay);  // wait for the delay before falling.
		GetComponent<Rigidbody> ().isKinematic = false;  // turn the kinematic on the rigidbody false to drop the floor perfect.

		yield return new WaitForSeconds (4); // wait for 4 second.
		switch (gameObject.name) { //switch for my stack.

		case "LeftTile":
			TileManager.Instance.LeftTiles.Push (gameObject);
			gameObject.GetComponent<Rigidbody> ().isKinematic = true;  // where the push for the stack goes.
			gameObject.SetActive (false);
			break;

		case "TopTile":
			TileManager.Instance.TopTiles.Push (gameObject);
			gameObject.GetComponent<Rigidbody> ().isKinematic = true;  //where the push for the stack goes.
			gameObject.SetActive (false);
			break;

		}
	}

	}

