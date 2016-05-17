using UnityEngine;
using System.Collections;

public class SpinItem : MonoBehaviour {


	public GameObject Item; // ref to the item in the game.
	private float spinSpeed = 30f; // the speed in which to spin.
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	

		Item.transform.Rotate (Vector3.down * Time.deltaTime * spinSpeed, Space.World); // rotate the item with time and speed plus world.
	}
}
