using UnityEngine;
using System.Collections;

public class LevelComplete : MonoBehaviour {


	public Animator levelComplete;


	// Use this for initialization
	void Start () {
	
	
		levelComplete = GetComponent<Animator> ();
	
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	public void CompleteLevel(){


		levelComplete.SetTrigger ("LevelComplete");




	}


}
