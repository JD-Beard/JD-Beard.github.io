using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {

	TextMesh hBar;



	// Use this for initialization
	void Start () {

		hBar = GetComponent < TextMesh> (); 
		//audio = GetComponent<AudioSource> ();
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.forward = Camera.main.transform.forward; //make health bar face camera at all times.

	}

	public int startHealth(){


		return hBar.text.Length;         
	}

	public void decreaseHealth(){

		if (startHealth () > 1)
			hBar.text = hBar.text.Remove (hBar.text.Length - 1);
		else
			Destroy (transform.parent.gameObject);
		    


		    
		


	
}


}
