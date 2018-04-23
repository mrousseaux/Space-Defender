﻿using UnityEngine;
using System.Collections;

public class PlaySpace : MonoBehaviour {
	public float minX;
	public float maxX;

	// Use this for initialization
	void Start () {
		//defines the edges of the play space by the constraints of the camera
		float cameraDistance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftBoundery = Camera.main.ViewportToWorldPoint (new Vector3(0,0,cameraDistance));
		Vector3 rightBoundery = Camera.main.ViewportToWorldPoint (new Vector3(1,0,cameraDistance));
		minX = leftBoundery.x;
		maxX = rightBoundery.x;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
