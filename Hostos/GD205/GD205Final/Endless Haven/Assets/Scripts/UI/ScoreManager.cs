using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text scoreText; //score text
	public float scoreCount;  //score count
	private float BestscoreCount; // best score count
	public float pointsPerSecond;  //count per second
	public bool scoreIncreasing; //a bool for the score to turn off and on.
	public Text endScoreText; // ref to the endscore text
	public Text BestScoreText; // ref to the bestscore text
	// Use this for initialization
	void Start () {

		if (PlayerPrefs.HasKey("BestScore")) {

			BestscoreCount = PlayerPrefs.GetFloat ("BestScore"); // saving the best score
		}
	}
	
	// Update is called once per frame
	void Update () {
	  
		if (scoreIncreasing) { // checking if my score is on

			scoreCount += pointsPerSecond * Time.deltaTime;  //if so begin the running score.

		}


		if (scoreCount > BestscoreCount) { // check to see if the score is higher then the best score and set the float to it.

			BestscoreCount = scoreCount;
			PlayerPrefs.SetFloat ("BestScore", BestscoreCount);
		}
			

		scoreText.text = "Score: " + Mathf.Round(scoreCount);  // make sure my score is on even round number.
		endScoreText.text = " " + Mathf.Round(scoreCount);  //end game score count being rounded to a whole number.
		BestScoreText.text = " " + Mathf.Round(BestscoreCount); //best game score being rounded to a whole number.
	}



}
