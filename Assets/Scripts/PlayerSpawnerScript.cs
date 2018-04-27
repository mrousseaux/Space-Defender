using UnityEngine;
using System.Collections;

public class PlayerSpawnerScript : MonoBehaviour {
	public GameObject playerObject;

	//shows transform gizmo
	void OnDrawGizmos(){
		Gizmos.DrawWireSphere (transform.position, 1f);
	}

	// Use this for initialization
	void Start () {
		GameObject player = Instantiate (playerObject, gameObject.transform.position, Quaternion.identity) as GameObject;
		player.transform.parent = gameObject.transform;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
