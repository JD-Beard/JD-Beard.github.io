using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class TileManager : MonoBehaviour {

	public GameObject[] tilePrefabs; //Hold my prefabs
	private float spawnZ = -6.0f; // the first tile being spawn
	private float tileLength = 8.0f; // the length of the tile.
	private int amnTilesOnScreen = 7; // the starting amount of tiles.
	private float startZone = 15.0f; // safezone beforeing deleting tiles for the player.
	private int lastPrefabIndex = 0; // the first tile to use.

	private Transform playerTransform; // player position.

	private List<GameObject> activeTiles; // list of objects
	// Use this for initialization
	void Start () {
		
		activeTiles = new List<GameObject> (); // get the list
		playerTransform = GameObject.FindGameObjectWithTag ("Player").transform; // get the player.


		for (int i = 0; i < amnTilesOnScreen; i++) { // for loop for spawning the tiles at the start.

			if (i < 4)
				SpawnTile (0); // spawn the first prefab
			else
			SpawnTile (); // spawn tiles.
		}


	
	}

	
	// Update is called once per frame
	void Update () {
	
		if (playerTransform.position.z - startZone > (spawnZ - amnTilesOnScreen * tileLength)) { // spawn a tile once I reach a distance.

			SpawnTile (); // spawn
			DeleteTile (); // delete the tile that I passby
		}

	}



	void SpawnTile(int prefabIndex = -1){

		GameObject go;
		if (prefabIndex == -1)
			go = Instantiate (tilePrefabs [RandomPrefabIndex ()]) as GameObject;
		else
			go = Instantiate (tilePrefabs [prefabIndex]) as GameObject;
		go.transform.SetParent (transform);
		go.transform.position = Vector3.forward * spawnZ;
		spawnZ += tileLength;
		activeTiles.Add (go);

		int spawnPickup = Random.Range (0, 2); // random range for spawning the gem tiles for the player.

		if (spawnPickup == 0) { // if 0 spawn tile.

			tilePrefabs[1].transform.GetChild(1).gameObject.SetActive(true); // ref to the gems of the tiles.
		}

	}

	void DeleteTile(){ // delete tile

		Destroy (activeTiles [0]); // destroy the tiles
		activeTiles.RemoveAt (0); // remove from list.

	}


	private int RandomPrefabIndex(){

		if (tilePrefabs.Length <= 1)
			return 0;

			int randomIndex = lastPrefabIndex;
		while (randomIndex == lastPrefabIndex){

			randomIndex = Random.Range(0, tilePrefabs.Length);
		}

		lastPrefabIndex = randomIndex;
		return randomIndex;
	}



	public void ResetGame(){

		Application.LoadLevel (Application.loadedLevel);  //load the restart the same level.

		//SceneManager.LoadScene ("Level1");


	}

	public void LevelSelect(){

		//Application.LoadLevel (1);  //load the level select screen.
		SceneManager.LoadScene("LevelSelect");

	}

	public void MainMenu(){

		//Application.LoadLevel (0);  //load the main menu screen.
		SceneManager.LoadScene("MainMenu");
	}


	public void NextLevel1(){

		SceneManager.LoadScene ("Level2");
	}

	public void NextLevel2(){

		SceneManager.LoadScene ("Level3");
	}

	public void NextLevel3(){

		SceneManager.LoadScene ("Level4");
	}
}

