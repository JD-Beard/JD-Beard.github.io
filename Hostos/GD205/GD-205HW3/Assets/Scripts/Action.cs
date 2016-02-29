using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Action : MonoBehaviour {

	public GameObject textThing;
	public GameObject roomText;
	public GameObject Key;
	public GameObject Skeleton;
	public GameObject Death;
	public GameObject Bomb;
	int roomX;
	int roomY;
	bool hasLock;
	bool hasKey;
	float gameTimer;
	float attackTimer;
	float attack1Timer;


	// Use this for initialization
	void Start () {

		roomX = 0;
		roomY = 0;
		hasLock = false;
		hasKey = false;
		gameTimer = 1.5f;
		attackTimer = 5.0f;
		attack1Timer = 3.0f;


	
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown ("up")) {
			roomX++;

			if (roomX > 6) {
				roomX--;
			} else if (hasLock) {
				roomX++;
			}

		}


		if (Input.GetKeyDown ("down")) {
			
			if (roomX > 0) {
				roomX--;
			} else if (hasLock) {
				roomX--;
			}
		}

		//Movement for X


		if (Input.GetKeyDown ("right")) {
			roomY++;

			if (roomY > 6) {
				roomY--;
			} else if (hasLock) {
				roomY++;
			}
		}


		if (Input.GetKeyDown ("left")) {
			
			if (roomY > 0) {
				roomY--;
			} else if (hasLock) {
				roomY--;
			}
		}


		//Movement for Y


		//Game information and guidelines


		textThing.GetComponent<Text> ().text = roomX + " , " + roomY;

		if (roomX == 1 && roomY == 0 ) {
			roomText.GetComponent<Text> ().text = "This room is so dark!";
		}

		if (roomX == 2 && roomY == 0 ) {

			roomText.GetComponent<Text> ().text = "Maybe you should look for a light source!";
		}

		if (roomX == 3 && roomY == 0 ) {

			roomText.GetComponent<Text> ().text = "You smell something strange in this path.";
		}

		if (roomX == 4 && roomY == 0 ) {

			roomText.GetComponent<Text> ().text = "You can hear a loud knocking nearby.";
		}

		if (roomX == 5 && roomY == 0 ) {

			roomText.GetComponent<Text> ().text = "You sense something powerful near you!";
		}

		if (roomX == 6 && roomY == 0 ) {

			roomText.GetComponent<Text> ().text = "You can hear a loud crackling sound nearby.";
		}

		if (roomY == 1 && roomX ==0) {

			roomText.GetComponent<Text> ().text = "You can see a beware sign by the door!";
		}

		if (roomY == 2 && roomX ==0) {

			roomText.GetComponent<Text> ().text = "You can see a large bucket that has water!";
		}

		if (roomY == 3 && roomX ==0) {

			roomText.GetComponent<Text> ().text = "You hear someone screaming for help!";
		}

		if (roomY == 4 && roomX == 0) {

			roomText.GetComponent<Text> ().text = "You notice the floor is cover in oil!";
		}

		if (roomY == 5 && roomX == 0) {

			roomText.GetComponent<Text> ().text = "You can see a firetorch by the wall! beware of the oil on the ground.";
		}

		if (roomY == 6 && roomX == 0) {

			roomText.GetComponent<Text> ().text = "The room is getting darker by the minute!";
		}

		//start of 1-0
			if (roomX == 1 && roomY == 1) {
			roomText.GetComponent<Text> ().text = "You are feeling tired must rest soon.";
		}
			

		if (roomX == 1 && roomY == 2) {

			roomText.GetComponent<Text> ().text = "You can see a prison cell across from you!";
		}

		if (roomX == 1 && roomY == 3) {

			roomText.GetComponent<Text> ().text = "This prison cell needs a key to open.";
		}

		if (roomX == 1 && roomY == 4) {

			roomText.GetComponent<Text> ().text = "You try to kick the prison cell door open.";
		}

		if (roomX == 1 && roomY == 5) {

			roomText.GetComponent<Text> ().text = "You hurt your foot kicking the cell.";
		}
		if (roomX == 1 && roomY == 6) {

			roomText.GetComponent<Text> ().text = "You can barely walk due hurting your foot.";
		}

		//Start of 2-0

		if (roomX == 2 && roomY == 1) {

			roomText.GetComponent<Text> ().text = "This dungeon is completely cover in darkness. ";
		}

		if (roomX == 2 && roomY == 2) {

			roomText.GetComponent<Text> ().text = "The room is becoming cold and you can barely breath.";
		}

		if (roomX == 2 && roomY == 3) {

			roomText.GetComponent<Text> ().text = "You must rush to the nearest door you can find.";
		}

		if (roomX == 2 && roomY == 4) {

			roomText.GetComponent<Text> ().text = "You finally find a door but it won't open.";
		}

		if (roomX == 2 && roomY == 5) {

			roomText.GetComponent<Text> ().text = "You try to kick it open.";
		}

		if (roomX == 2 && roomY == 6) {

			roomText.GetComponent<Text> ().text = "This door won't open must keep looking around.";
		}

		//start 3-0
		if (roomX == 3 && roomY == 1) {

			roomText.GetComponent<Text> ().text = "You cover your nose from the strong smell.";
		}

		if (roomX == 3 && roomY == 2) {

			roomText.GetComponent<Text> ().text = "You continue looking for a path way out of this maze.";
		}
		if (roomX == 3 && roomY == 3) {

			roomText.GetComponent<Text> ().text = "You see a danger sign by the wall.";
		}
		if (roomX == 3 && roomY == 5) {

			roomText.GetComponent<Text> ().text = "You gotta get outta here!";
		}

		if (roomX == 3 && roomY == 6) {

			roomText.GetComponent<Text> ().text = "You find it hard to breathe.";
		}

		//start 4-0
		if (roomX == 4 && roomY == 1) {

			roomText.GetComponent<Text> ().text = "You continue following the knocking noise.";
		}

		if (roomX == 4 && roomY == 2) {

			roomText.GetComponent<Text> ().text = "You can see a bright light coming from the hallway across from you.";
		}

		if (roomX == 4 && roomY == 4) {

			roomText.GetComponent<Text> ().text = "You must continue looking for the key to this door.";
		}

		if (roomX == 4 && roomY == 5) {

			roomText.GetComponent<Text> ().text = "You see a shining object on the floor.";
		}

		if (roomX == 4 && roomY == 6) {

			roomText.GetComponent<Text> ().text = "You notice the shining object, is just a coin.";
		}

		//start 5-0

		if (roomX == 5 && roomY == 2) {

			roomText.GetComponent<Text> ().text = "Beware of the hole in the ground.";
		}

		if (roomX == 5 && roomY == 3) {

			roomText.GetComponent<Text> ().text = "You can see a lever by the wall.";
		}

		if (roomX == 5 && roomY == 4) {

			roomText.GetComponent<Text> ().text = "You try to pull the lever but it seems stuck!";
		}

		if (roomX == 5 && roomY == 5) {

			roomText.GetComponent<Text> ().text = "You look around to see if you find anything.";
		}

		//start 6-0

		if (roomX == 6 && roomY == 1) {

			roomText.GetComponent<Text> ().text = "You can feel some bones on the ground.";
		}

		if (roomX == 6 && roomY == 3) {

			roomText.GetComponent<Text> ().text = "You can hear something walking toward you!";
		}

		if (roomX == 6 && roomY == 4) {

			roomText.GetComponent<Text> ().text = "There is a banging noise coming from the hallway!";
		}

		if (roomX == 6 && roomY == 5) {

			roomText.GetComponent<Text> ().text = "You continue to run away from the noise.";
		}

		if (roomX == 6 && roomY == 6) {

			roomText.GetComponent<Text> ().text = "You reach the end of the hallway and there are no doors around.";
		}





		if (roomX == 5 && roomY == 6) {
			hasKey = true;
			roomText.GetComponent<Text> ().text = "You have found a strange key! \n might be of used for a door!";

		}

		//key revel itsself
		if (hasKey == true){
			Key.GetComponent<RawImage> ().color = new Color (255f, 255f, 255f, 255f);
	}
				


		//Lock door and open door
		if (hasKey == true && roomX == 4 && roomY == 3) {
				roomText.GetComponent<Text> ().text = "Game Over! \n You have escape this dungeon! Congratulations.";
		} else if (hasKey == false && roomX == 4 && roomY ==3) {
				roomText.GetComponent<Text> ().text = "You see a strange door. You notice its lock!";
			}


		if (roomX == 3 && roomY == 4) {
			roomText.GetComponent<Text> ().text = "You see a bomb! run away before its too late!";
			Bomb.GetComponent<RawImage> ().color = new Color (255f, 255f, 255f, 255f);
			attackTimer -= Time.deltaTime;
			if (attackTimer < 0) {
				roomText.GetComponent<Text> ().text = "You have been killed! Game over!";
				attack1Timer -= Time.deltaTime;
			}

			if (attack1Timer < 0) {
				Application.LoadLevel ("Scene1");
			}
		
		} else if (roomX + roomY <= 6) {
			Bomb.GetComponent<RawImage> ().color = new Color (255f, 255f, 255f, 0f);
		} else if (roomX + roomY > 6) {

			Bomb.GetComponent<RawImage> ().color = new Color (255f, 255f, 255f, 0f);
		}

		if (roomX == 5 && roomY == 1) {

			roomText.GetComponent<Text> ().text = "You have fallen in a trap! Game Over!";
			Death.GetComponent<RawImage> ().color = new Color (255f, 255f, 255f, 255f);
			gameTimer -= Time.deltaTime;
			if (gameTimer < 0) {
				
				Application.LoadLevel ("Scene1");
			}
		}


		if (roomX == 6 && roomY == 2) {
		
			roomText.GetComponent<Text> ().text = "A skeleton has risen, You must run away before it kills you!";
			Skeleton.GetComponent<RawImage> ().color = new Color (255f, 255f, 255f, 255f);
			attackTimer -= Time.deltaTime;
			if (attackTimer < 0) {
				roomText.GetComponent<Text> ().text = "You have been killed! Game over!";
				attack1Timer -= Time.deltaTime;
			}
			if (attack1Timer < 0) {
				Application.LoadLevel ("Scene1");
			}
		} else if (roomX+roomY < 8) {

			Skeleton.GetComponent<RawImage> ().color = new Color (255f, 255f, 255f, 0f);
		}
				
		

		

	}



}
