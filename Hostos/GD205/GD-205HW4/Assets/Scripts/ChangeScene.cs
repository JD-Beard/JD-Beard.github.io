﻿using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	public void ChangeToScene (string sceneToChangeTo){

		Application.LoadLevel (sceneToChangeTo);






}

	public void ChangeToExit (int sceneToExitTo){

		Application.Quit ();
		Debug.Log("exit");

	}

}