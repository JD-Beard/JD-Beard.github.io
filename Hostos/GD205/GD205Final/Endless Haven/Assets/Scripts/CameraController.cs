using UnityEngine;
using System.Collections;

public class CameraController : MonoBehaviour {

	public PlayerMovement thePlayer;
	public Vector3 lastPlayerPosition;
	private float distanceToMove;
	// Use this for initialization
	void Start () {
	
		thePlayer = FindObjectOfType<PlayerMovement> ();
		lastPlayerPosition = thePlayer.transform.position;
	}

	// Update is called once per frame
	void Update () {

		distanceToMove = thePlayer.transform.position.z - lastPlayerPosition.z;
		transform.position = new Vector3 (transform.position.x, transform.position.y, transform.position.z + distanceToMove);
		lastPlayerPosition = thePlayer.transform.position;

	}
}
