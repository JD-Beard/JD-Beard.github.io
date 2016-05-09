using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Timer : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
		PlayerPrefs.SetInt ("Level2", 1);
		StartCoroutine (Time ());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator Time(){

		yield return new WaitForSeconds (2f);
		SceneManager.LoadScene (4);



	}
}
