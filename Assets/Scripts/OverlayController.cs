using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OverlayController : MonoBehaviour {
	public Text scoreDescription;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		scoreDescription.text = "Score " + enemyScript.score.ToString();
	
	}
}
