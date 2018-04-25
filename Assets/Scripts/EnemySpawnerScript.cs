using UnityEngine;
using System.Collections;

public class EnemySpawnerScript : MonoBehaviour {
	public GameObject enemyType;
	public float width = 6f;
	public float hieght = 4f;
	public float speed = 1f;
	public float spawnDelay = 2f;
	public static int wave;

	private PlaySpace playSpace;
	private bool movingRight = false;
	//shows the spawner in the game editor for easy editing.
	void OnDrawGizmos(){
		Gizmos.DrawWireCube(transform.position, new Vector3(width, hieght, 0));
	}
	// Use this for initialization
	void Start () {
		wave = 1;
		print("Spawning Wave: " + wave);
		EnemySpawn ();
		//bring in variables from the play space script. 
		playSpace = GameObject.FindObjectOfType<PlaySpace>();


	}
	
	// Update is called once per frame
	void Update () {
		EnemyFormationMovement ();
		if (AllMembersAreDead()) {
			wave++;
			print("Spawning Wave: " + wave);
			EnemySpawn();
		}

	}

	//checks to see what the next free spawn position is
	Transform NextFreePosition(){
		foreach (Transform child in transform) {
			if(child.childCount <= 0){
				return child.transform;
			}
		}
		return null;
	}

	// checks to see if the enemy formation has any children left
	bool AllMembersAreDead (){
		foreach (Transform enemyFormationChildren in transform){
			if (enemyFormationChildren.childCount > 0){
				return false;
			}
		}
		return true;
	}

	//spawns the next enemy wave
	void EnemySpawn(){
		Transform spawnPositon = NextFreePosition ();

		if(spawnPositon){
			GameObject enemy = Instantiate (enemyType, spawnPositon.transform.position, Quaternion.identity) as GameObject;
			enemy.transform.parent = spawnPositon;
		}
		if (NextFreePosition()){
			Invoke("EnemySpawn",spawnDelay);
		}
	}

	//handles the formations back and forth movement
	void EnemyFormationMovement(){
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
