using UnityEngine;
using System.Collections;

public class TileManager : MonoBehaviour {

	//public GameObject leftTilePrefab;
	public GameObject topTilePrefab;
	public GameObject currentTile;

	// Use this for initialization
	void Start () {
	
		for (int i = 0; i < 10; i++) {

			SpawnTile ();
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}


	public void SpawnTile(){

		currentTile = (GameObject)Instantiate (topTilePrefab, currentTile.transform.GetChild(1).position, Quaternion.identity);

	}
}
