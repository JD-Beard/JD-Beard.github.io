using UnityEngine;
using System.Collections;

public class FadingScene : MonoBehaviour {

	public Texture2D fadeOutTexture;   // refs to the texture for a overlay.
	public float fadeSpeed = 0.8f;
	private int drawDepth = -1000;
	private float alpha = 1.0f;
	private int fadeDir = -1;


	void OnGUI(){


		alpha += fadeDir * fadeSpeed * Time.deltaTime; // fade out/ in

		alpha = Mathf.Clamp01 (alpha); //clamp the color from 0 to 1.

		GUI.color = new Color (GUI.color.r, GUI.color.g,GUI.color.b, alpha); // set the color for the fade.
		GUI.depth = drawDepth; // draw a black texture.
		GUI.DrawTexture ( new Rect (0, 0, Screen.width, Screen.height), fadeOutTexture); // draw the texture to fit the full screen.
	}

	public float BeginFade(int direction){ // fade in a direction.

		fadeDir = direction;
		return(fadeSpeed);

	}

	void OnLevelWasLoaded(){

		BeginFade (-1);

	}
}
