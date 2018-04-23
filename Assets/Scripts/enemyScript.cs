using UnityEngine;
using System.Collections;

public class enemyScript : MonoBehaviour {

	void OnTriggerEnter2D (Collider2D col){
		Debug.Log ("Enemy Hit Detected");
		Destroy (col.gameObject);
		Destroy (gameObject);
	}
}
