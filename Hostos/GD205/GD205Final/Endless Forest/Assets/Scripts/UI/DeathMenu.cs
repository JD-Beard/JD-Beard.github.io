using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class DeathMenu : MonoBehaviour {

	public Image backgroundImg;
	public Animator gameOverAnim;

	// ref to the gameover background.
	//private bool menuShow = false; // a bool for when to show the game over menu.
//	private float menuTransition = 0.5f;  // a float for the game over menu transition.

	// Use this for initialization
	void Start () {
	
		gameOverAnim = GetComponent<Animator> ();
	
		//gameObject.SetActive (false); // start with the menu turned off.

	}

	// Update is called once per frame
	void Update () {
	
		//if (!menuShow) // if not the menu return.
			//return;

		//menuTransition += Time.deltaTime; // transition with a time.
		//backgroundImg.color = Color.Lerp (new Color (0, 0, 0, 0), Color.black, menuTransition);  // the transition color and time.
	}


	public void ToggleEndMenu(){

		gameOverAnim.SetTrigger ("GameOver");

		//gameObject.SetActive (true);  // turn on the game over menu and make it true.
		//menuShow = true;


	}
}
