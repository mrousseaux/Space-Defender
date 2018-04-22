using UnityEngine;
using System.Collections;

public class MusicPlayerScript : MonoBehaviour {
	static MusicPlayerScript instance;
	void Awake () {
		Debug.Log ("Music Player Awake: " + GetInstanceID());

		if (instance != null) { //checks if an instance of this exists
			Destroy (gameObject); //destroy's itself if an instance already exists
			Debug.Log ("Music Player Copy Destroyed: " + GetInstanceID());
		} else {
			instance = this; //if instance is set to nothing, there is no instance. So set instance to this object.
			GameObject.DontDestroyOnLoad (gameObject);	//don't destroy this object.
		}
	}
	// Use this for initialization
	void Start () {
		Debug.Log ("Music Player Start: " + GetInstanceID());
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
