using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartMenu : MonoBehaviour {



	public Animator creditAnim; //ref to the controller for the credit animtion.





	public void ChangeToScene(string sceneToChangeTo){ //change to the scene in the menu.

		SceneManager.LoadScene (sceneToChangeTo);

	

		//Application.LoadLevel(sceneToChangeTo);
	}

	public void ChangeToExit(int sceneToExitTo){ // change to the exit scene when the player quits.

		Application.Quit ();
		Debug.Log ("exit");
	}


	// Use this for initialization
	void Start () {


	}
	
	// Update is called once per frame
	void Update () {
	



	}

	public void onClick(){

		creditAnim.SetTrigger ("startCredit");  // begin the animation for the credits.



	}





	}

