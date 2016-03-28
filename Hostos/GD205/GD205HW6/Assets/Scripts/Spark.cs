using UnityEngine;
using System.Collections;

public class Spark : MonoBehaviour {


	public GameObject pop;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
	
	

		if (Input.GetMouseButtonDown (0)) {

			Instantiate (pop, transform.position, Quaternion.identity);


		}




	}







        
}
