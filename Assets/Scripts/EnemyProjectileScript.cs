using UnityEngine;
using System.Collections;

public class EnemyProjectileScript : MonoBehaviour {

	public float damage = 100f;

	public void Hit(){

		Destroy (gameObject);
	}
}
