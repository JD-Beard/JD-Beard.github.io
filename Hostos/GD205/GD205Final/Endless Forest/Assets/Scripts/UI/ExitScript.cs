using UnityEngine;
using System.Collections;

public class ExitScript : MonoBehaviour {

	public Animator exitAnim; // ref to the animation controller for the credit.
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void onClick(){


		exitAnim.SetTrigger("exitCredit");  // play the exit animation for the credit.
	}
}
