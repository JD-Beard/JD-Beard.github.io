using UnityEngine;
using System.Collections;

public class enemyMove : MonoBehaviour {
	
	public AudioClip[] audioClips;
	public Transform[] pathPoints;
	public float speed = 9f;
	public int waypoint = 0;
	Transform targetWayPoint;




	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	//enemies checking to see where to move toward.
		if (waypoint < this.pathPoints.Length) {

			if (targetWayPoint == null)
				targetWayPoint = pathPoints [waypoint];
			move ();


			}
		}




	void move(){
		//Move to the toward to my pathPoints.
		transform.position = Vector3.MoveTowards (transform.position, targetWayPoint.position, speed * Time.deltaTime);

		if (transform.position == targetWayPoint.position) {  //check my waypoint position.

			waypoint++;
			targetWayPoint = pathPoints [waypoint];  //this make the enemy follow the path using my array.
		}

		//Destroy the enemies when they reach the end path.
		if (waypoint == 6) {

			Destroy (this.gameObject);
		}
	}

		



	}


