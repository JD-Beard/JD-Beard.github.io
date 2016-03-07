using UnityEngine;
using System.Collections;

public class SpawnThings : MonoBehaviour {


	public GameObject[] Ball;
	public Transform[] Spawnpoints;
	public float Spawntimer = 10f;


	//public float sparkLight = 0.0f;
	//public float sparkLight1 = 0.0f;




	// Use this for initialization
	void Start () {

		InvokeRepeating ("Spawn", Spawntimer, Spawntimer);  //Repeating my spawn with my timer.
	}



	// Update is called once per frame
	void Update () {




	}

	void Spawn(){

		int spawnIndex = Random.Range (0,Spawnpoints.Length);  //Random spawn my balls using my array.

		int objectIndex = Random.Range (0, Ball.Length);

		Instantiate(Ball[objectIndex],Spawnpoints[spawnIndex].position,Spawnpoints[spawnIndex].rotation);





	}







}











