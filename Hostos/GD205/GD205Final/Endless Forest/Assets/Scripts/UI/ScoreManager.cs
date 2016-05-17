using UnityEngine;
using System.Collections;
using UnityEngine.UI;


public class ScoreManager : MonoBehaviour {

	public Text totalGemText; // ref to gemText in the game.
	public Text scoreText; // ref to scoretext in the game.
	public float scoreCount; // ref to the score value.
	private float bestScoreCount; // highest score value.
	public float pointsPerSecond; // the point per second in the game.
	public bool scoreIncreasing; // how the score will begin increasing.
	public Text endScoreText; // endscore in the menu.
	public Text bestScoreText; // highest score in the menu.
	private int difficultyLevel = 1; // beginning difficulty.
	private int maxDifficultyLevel = 10; // the max the difficulty can go.
	private int scoreToNextLevel = 3000; // which intervole the score is needed for the difficulty need to go up.
	private PlayerMotor playerMovement; // ref to the playermotor script.
	public AudioSource finishSong;


	//------------// Gem Refs.

	public Text GemText; // gem ref.
	public int gemCount; // the ammount of gems that is earn by the player.
	public int MaxGems; // the total ammount of gems to aquire.
	private int totalGems;
	//------------------// end of the ref



	//----------------Level Completed------//

	private LevelComplete levelDone;
	public Text Cscore;
	public Text Chighestscore;


	//-------------------End--------------//
	// Use this for initialization
	void Start () {
		finishSong = GetComponent<AudioSource> ();
		playerMovement = FindObjectOfType<PlayerMotor> (); // look for the playermotor script.
		levelDone = FindObjectOfType<LevelComplete>();
		if (PlayerPrefs.HasKey ("BestScore")) {

			bestScoreCount = PlayerPrefs.GetFloat ("BestScore");  // if the player has compelete, which is haskey get the saved data.
		}


		if (PlayerPrefs.HasKey ("totalGems")) {

			totalGems = PlayerPrefs.GetInt ("totalGems");  // if the player has compelete, which is haskey get the saved data.
		}


		//PlayerPrefs.SetInt ("Level2", 1);
		//PlayerPrefs.SetInt("Level1_totalGems" , totalGems);


	}
	
	// Update is called once per frame
	void Update () {
	
		if (scoreIncreasing) {

			scoreCount += pointsPerSecond * Time.deltaTime; // increase the score using a timer.
		}


		if (scoreCount >= scoreToNextLevel) { // if the score reach a point begin leveling up the game level.

			LevelUp ();
		}

		if (scoreCount > bestScoreCount) { // if the score is greater then the highest score overwrite it.


			bestScoreCount = scoreCount;
			PlayerPrefs.SetFloat ("BestScore", bestScoreCount); // place the new highest score.
		}



		if (gemCount > totalGems) {

			totalGems = gemCount;
		
			PlayerPrefs.SetInt ("Level1_totalGems", totalGems); // place the gem, for the level script.
			PlayerPrefs.SetInt ("totalGems", totalGems); // Keep the gems you have as save data.

		}

		if ((Application.loadedLevelName == "Level1" & totalGems > 29)) { // 30 gems needed to get to the next level

			PlayerPrefs.SetInt ("Level2", 1); // unlocked level 2.
			FinishLevel ();
			PlayerPrefs.DeleteKey ("totalGems");


		}

		if ((Application.loadedLevelName =="Level2" & totalGems > 29)) { // 30 gems needed to get to the next level

			PlayerPrefs.SetInt ("Level3", 1); // unlocked level 2.
			FinishLevel();
			PlayerPrefs.DeleteKey ("totalGems");
		}

		if ((Application.loadedLevelName =="Level3" & totalGems > 29)) { // 30 gems needed to get to the next level

			PlayerPrefs.SetInt ("Level4", 1); // unlocked level 2.
			FinishLevel();
			PlayerPrefs.DeleteKey ("totalGems");
		}


		if (totalGems == 29) {
			finishSong.Play();

		}


	

		scoreText.text = "Score: " + Mathf.Round (scoreCount); // make the score an whole number.
		endScoreText.text = " " + Mathf.Round (scoreCount); // make the score an whole number.
		bestScoreText.text = " " + Mathf.Round (bestScoreCount); // make the score an whole number.
		GemText.text = "Gems: " + (gemCount) + "/" + (MaxGems);// make the gem count and the max gem count.
		totalGemText.text =" " + (totalGems);
		Cscore.text = " " + Mathf.Round (scoreCount);
		Chighestscore.text = " " + Mathf.Round (scoreCount);






	}

	void LevelUp(){ // level up the game difficulty

		if (difficultyLevel == maxDifficultyLevel) // if the difficulty reach the highest point return.
			return;

		scoreToNextLevel *= 2; // increase by 2 intervole.
		difficultyLevel++; // + the difficulty.

		playerMovement.SetSpeed (difficultyLevel); // ref to the playermotor script to set the speed for the difficulty.


	}

	public void FinishLevel(){


		levelDone.CompleteLevel ();
		playerMovement.isDead = true;
		playerMovement.FinishThisLevel ();
		scoreIncreasing = false;
		playerMovement.playeranim.SetTrigger ("PlayerWins");
		playerMovement.FinishThisLevel ();

	}


}
