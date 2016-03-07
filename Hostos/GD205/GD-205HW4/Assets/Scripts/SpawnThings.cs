using UnityEngine;
using System.Collections;

public class SpawnThings : MonoBehaviour {


	public GameObject[] Ball;                         //Array for objects which in my case is balls.
	public Transform[] Spawnpoints;                 //Array for spawn points
	public float Spawntimer = 10f;


	




	// Use this for initialization
	void Start () {

		InvokeRepeating ("Spawn", Spawntimer, Spawntimer);  //Repeating my spawn with my timer using my float.
	}



	// Update is called once per frame
	void Update () {




	}

	void Spawn(){

		int spawnIndex = Random.Range (0,Spawnpoints.Length);  //Random picking my spawn point using my array.

		int objectIndex = Random.Range (0, Ball.Length);    //Random spawning my ball

		Instantiate(Ball[objectIndex],Spawnpoints[spawnIndex].position,Spawnpoints[spawnIndex].rotation);  //clone my ball at the random location that I choose.





	}







}











