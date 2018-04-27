using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class OverlayController : MonoBehaviour {
	public Text scoreDescription;
	public PlaySpace playSpace;
	// Use this for initialization
	void Start () {
		playSpace = GameObject.FindObjectOfType<PlaySpace>();
		//gameObject.transform.position = new Vector3 (playSpace.minX, 0, 0);
	}
	
	// Update is called once per frame
	void Update () {
		scoreDescription.text = "Score " + enemyScript.score.ToString();
	
	}
}
