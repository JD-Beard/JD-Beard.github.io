using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartMenu : MonoBehaviour {

	public void ChangeToScene (string sceneToChangeTo){

		SceneManager.LoadScene (sceneToChangeTo);






	}

	public void ChangeToExit (int sceneToExitTo){

		Application.Quit ();
		Debug.Log("exit");

	}

}