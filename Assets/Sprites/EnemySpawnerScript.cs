using UnityEngine;
using System.Collections;

public class EnemySpawnerScript : MonoBehaviour {
	public GameObject enemyType;
	// Use this for initialization
	void Start () {
		Instantiate (enemyType, new Vector3(0,0,0), Quaternion.identity);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
