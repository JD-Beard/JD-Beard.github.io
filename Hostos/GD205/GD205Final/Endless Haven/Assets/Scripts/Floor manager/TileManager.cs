using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class TileManager : MonoBehaviour {


	public GameObject currentTile; // the main floor in the start of the game.
	public GameObject[] Tiles;  // array for the floor tiles to be place.

	private static TileManager instance;  //making this static to used the script from anywhere.

	private Stack<GameObject> leftTiles = new Stack<GameObject>();  //the stack to recycle my floor.
	public Stack<GameObject> LeftTiles{
		get{ return leftTiles; }
		set{ leftTiles = value; }
	}
	private Stack<GameObject> topTiles = new Stack<GameObject>(); //the stack to recycle my floor.
	public Stack<GameObject> TopTiles{
		get{ return topTiles; }
		set{ topTiles = value; }

	}

	private ScoreManager thescoreManager;



	public static TileManager Instance{  //making this static to be used from anywhere.

		get{ 

			if (instance == null) {

				instance = GameObject.FindObjectOfType<TileManager> ();  //check if the TileManager is working if not look for it.
			}

			return instance; }
	
	}

	void Start () {

		thescoreManager = FindObjectOfType<ScoreManager>();

		CreateTiles (30);  //Start the game with these many floor tiles.

		for (int i = 0; i < 40; i++) {
			SpawnTile ();  //a for loop to spawn my floor up to whatever I want.
		}
	}
	

	void Update () {
	
	}

	public void CreateTiles(int amount){  //The main recycle of my floor function.

		for (int i = 0; i < amount; i++) {

			leftTiles.Push (Instantiate (Tiles [0]));
			topTiles.Push (Instantiate (Tiles [1]));
			topTiles.Peek ().SetActive (false);
			topTiles.Peek ().name = "TopTile";
			leftTiles.Peek ().SetActive (false);   // a for loop to push and peek all of my tiles being used for a later time in the game.
			leftTiles.Peek ().name = "LeftTile";
		}

	}

	public void SpawnTile(){  //Spawn my floor tile function.

		if (leftTiles.Count == 0 || topTiles.Count == 0) {  // if their are no tiles spawn these many.

			CreateTiles (10);
		}

		int randomIndex = Random.Range (0,2);  //Spawn a random ammount to create the level design.

		if (randomIndex == 0) {  // 0 is my first child tile

			GameObject tmp = leftTiles.Pop ();
			tmp.SetActive (true);
			tmp.transform.position = currentTile.transform.GetChild (0).transform.GetChild (randomIndex).position;
			currentTile = tmp;

		} else if (randomIndex == 1) { // 1 is my 2nd child tiles.

			GameObject tmp = topTiles.Pop ();
			tmp.SetActive (true);
			tmp.transform.position = currentTile.transform.GetChild (0).transform.GetChild (randomIndex).position;
			currentTile = tmp;

		}

		int spawnPickupItem = Random.Range (0, 10); //spawn my pick items in the game at random.

		if (spawnPickupItem == 0) {

			currentTile.transform.GetChild (1).gameObject.SetActive (true); //Turn on the child of the pickupitem.
		}


		//currentTile =(GameObject) Instantiate (Tiles[randomIndex], currentTile.transform.GetChild (0).transform.GetChild (randomIndex).position, Quaternion.identity);
	}


	public void ResetGame(){

		Application.LoadLevel (Application.loadedLevel);  //load the restart the same level.
		thescoreManager.scoreCount = 0;



	}

	public void LevelSelect(){

		Application.LoadLevel (1);  //load the level select screen.


	}

	public void MainMenu(){

		Application.LoadLevel (0);  //load the main menu screen.
	}

}
