﻿using UnityEngine;
using System.Collections;

public class FacePlayer : MonoBehaviour {

	public Transform Target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
		transform.LookAt (Target);
	}
}
