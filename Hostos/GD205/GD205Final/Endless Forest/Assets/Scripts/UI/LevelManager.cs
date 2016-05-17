using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class LevelManager : MonoBehaviour {

	[System.Serializable]    //Force to show my list in the editor
	public class Level
	{
		public string LevelText;    //spring for the text on the level.
		public int UnLocked;       //Unlocking the level
		public bool IsInteractable;  //check to see if the level is lock or not.

		//public Button.ButtonClickedEvent OnClickEvent;  //button event for a click.
	}
	public GameObject levelButton;       //UI Button
	public Transform Spacer;       //spacer object.
	public List<Level> LevelList;   //Array list 




	// Use this for initialization
	void Start () {
		//DeleteAllSaveData (); // delete all the save data, used to test this script.
		FillList ();   // fill the grid with the level button.



	}

	void FillList(){             //this is the function for filling the list.

		foreach (var level in LevelList) {  //a loop to go through the list.

			GameObject newbutton = Instantiate (levelButton) as GameObject; //instantiate the level button as a new.
			LevelButton button = newbutton.GetComponent<LevelButton> ();  // Get the component of the levelbutton.
			button.LevelText.text = level.LevelText;  //change the text for each item on the list.

			if (PlayerPrefs.GetInt ("Level" + button.LevelText.text ) == 1) {

				level.UnLocked = 1;                  //first level unlocked.
				level.IsInteractable = true;     // if true* the button is interactable.
			}

			button.unlocked = level.UnLocked;
			button.GetComponent<Button> ().interactable = level.IsInteractable;  //get the component of interactable with the level.
			button.GetComponent<Button> ().onClick.AddListener (() => loadLevels ("Level" + button.LevelText.text));  //get the component when click to level the proper level.

			if (PlayerPrefs.GetInt ("Level" + button.LevelText.text + "_totalGems") > 10) {

				button.Star1.SetActive (true);  //set the star icon on the button
				//Debug.Log("fire");
			}


			if (PlayerPrefs.GetInt ("Level" + button.LevelText.text + "_totalGems") >= 20) {

				button.Star2.SetActive (true);  //set the star icon on the button
			}


			if (PlayerPrefs.GetInt ("Level" + button.LevelText.text + "_totalGems") >= 30) {

				button.Star3.SetActive (true);  //set the star icon on the button
			}





			newbutton.transform.SetParent (Spacer);  //make sure the button is being placed within the spacer object.
			newbutton.transform.localScale = new Vector3 (1, 1, 1); //Keep my prefab size localscale.
		}

		SaveAll ();  //run save data.
	}


	void SaveAll(){  //Save all the game data.

		if (PlayerPrefs.HasKey ("Level1")) {   //check to see if the player has the first level unlock.

			return;  //if not return the value.

		} else {  // or else check all the button value for unlocking.



			GameObject[] allButtons = GameObject.FindGameObjectsWithTag ("LevelButton"); //check to see my gameobject has the tag levelbutton.
			foreach (GameObject buttons in allButtons) {   //for loop to check all my buttons.

				LevelButton button = buttons.GetComponent<LevelButton> ();
				PlayerPrefs.SetInt ("Level" + button.LevelText.text, button.unlocked);  //check all button if their unlocked.
			}

		}
	}


	void DeleteAllSaveData(){ //Delete all of the save data.

		PlayerPrefs.DeleteAll ();

	}


	void loadLevels(string value){


		SceneManager.LoadScene (value); //load the scene with the value/


	}


}