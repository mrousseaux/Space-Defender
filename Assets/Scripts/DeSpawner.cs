using UnityEngine;
using System.Collections;

public class DeSpawner : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D col){
		//Debug.Log ("DeSpawn Collision Detected.");
		Destroy (col.gameObject);
	}
}
