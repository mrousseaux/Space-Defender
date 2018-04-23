using UnityEngine;
using System.Collections;

public class EnemySpawnerScript : MonoBehaviour {
	public GameObject enemyType;
	public float width = 6f;
	public float hieght = 4f;
	public float speed = 1f;

	private PlaySpace playSpace;
	private bool movingRight = false;
	//shows the spawner in the game editor for easy editing.
	void OnDrawGizmos(){
		Gizmos.DrawWireCube(transform.position, new Vector3(width, hieght, 0));
	}
	// Use this for initialization
	void Start () {
		foreach(Transform child in transform){
			GameObject enemy = Instantiate (enemyType, child.transform.position, Quaternion.identity) as GameObject;
		enemy.transform.parent = child;
		}
		//bring in variables from the play space script. 
		playSpace = GameObject.FindObjectOfType<PlaySpace>();


	}
	
	// Update is called once per frame
	void Update () {
		enemyFormationMovement ();


	}


	//handles the formations back and forth movement
	void enemyFormationMovement(){
		if (movingRight) {
			transform.position += Vector3.right * speed * Time.deltaTime;
		} else {
			transform.position += Vector3.left * speed * Time.deltaTime;
		}
		
		float leftEdge = playSpace.minX + width/2;
		float rightEdge = playSpace.maxX-width/2;
		if(transform.position.x <= leftEdge || transform.position.x >= rightEdge){
			movingRight = !movingRight;
		}
		
		float newFormationX = Mathf.Clamp (transform.position.x, playSpace.minX+width/2, playSpace.maxX-width/2);
		transform.position = new Vector3(newFormationX, transform.position.y, transform.position.z); 
	}
}
