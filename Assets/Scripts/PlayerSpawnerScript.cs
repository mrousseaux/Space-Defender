using UnityEngine;
using System.Collections;

public class PlayerSpawnerScript : MonoBehaviour {
	public GameObject playerObject;
	public int lives = 3;
//	public PlayerController playerController;
	public LevelManager levelManager;

	//shows transform gizmo
	void OnDrawGizmos(){
		Gizmos.DrawWireSphere (transform.position, 1f);
	}

	// Use this for initialization
	void Start () {
	//	playerController = GameObject.FindObjectOfType<PlayerController>();
		levelManager = GameObject.FindObjectOfType<LevelManager>();
		SpawnPlayer ();
	}
	
	// Update is called once per frame
	void Update () {
		if(lives <= 0){
			Debug.Log("GAME OVER");
		//	Application.LoadLevel ("Lose Screen");
			levelManager.LoadLevel("Lose Screen");
		}
		if(PlayerIsDead()){
			SpawnPlayer();
			lives--;
		}
		
	}

	void SpawnPlayer(){
		GameObject player = Instantiate (playerObject, gameObject.transform.position, Quaternion.identity) as GameObject;
		player.transform.parent = gameObject.transform;
	}

	bool PlayerIsDead(){
		if (gameObject.transform.childCount <= 0) {
			return true;
		} else {
			return false;
		}
	}
	                   
}
