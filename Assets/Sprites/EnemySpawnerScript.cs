using UnityEngine;
using System.Collections;

public class EnemySpawnerScript : MonoBehaviour {
	public GameObject enemyType;
	public float width = 6f;
	public float hieght = 4f;
	public float speed = 1f;

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
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += Vector3.left * speed * Time.deltaTime;
	
	}
}
