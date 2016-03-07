using UnityEngine;
using System.Collections;

public class ChangeScene : MonoBehaviour {

	public void ChangeToScene (string sceneToChangeTo){

		Application.LoadLevel (sceneToChangeTo);                    //Change scene using string.






}

	public void ChangeToExit (int sceneToExitTo){                              //Change scene using Int

		Application.Quit ();
		Debug.Log("exit");

	}

}
