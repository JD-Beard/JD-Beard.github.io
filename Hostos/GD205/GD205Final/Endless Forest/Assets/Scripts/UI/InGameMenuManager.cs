using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class InGameMenuManager : MonoBehaviour {

	public void ChangeToScene(string sceneToChangeTo){ //change to the scene in the menu.

		SceneManager.LoadScene (sceneToChangeTo);
	}

	public void ChangeToExit(int sceneToExitTo){ // change to the exit scene when the player quits.

		Application.Quit ();
		Debug.Log ("exit");
	}
}
