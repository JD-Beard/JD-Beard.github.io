using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour {

	public float max_Health = 100f;
	public float cur_Health = 0f;
	public GameObject HealthBar;
	// Use this for initialization
	void Start () {
	
		cur_Health = max_Health;

	}
	
	// Update is called once per frame
	void Update () {
	
		if (cur_Health < 0) {

			Application.LoadLevel ("Level01");

		}


	}

	public void decreaseHealth(){

		cur_Health -= 10f;
		float calc_Health = cur_Health / max_Health;
		SetHealthBar (calc_Health);
	}





       public void SetHealthBar(float myHealth){

		HealthBar.transform.localScale = new Vector3 (myHealth, HealthBar.transform.localScale.y, HealthBar.transform.localScale.z);
}
}

