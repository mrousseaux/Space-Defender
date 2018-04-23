using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float shipSpeed = 10f;

	float minX;
	float maxX;
	// Use this for initialization
	void Start () {
		float cameraDistance = transform.position.z - Camera.main.transform.position.z;
		Vector3 leftBoundery = Camera.main.ViewportToWorldPoint (new Vector3(0,0,cameraDistance));
		Vector3 rightBoundery = Camera.main.ViewportToWorldPoint (new Vector3(1,0,cameraDistance));
		minX = leftBoundery.x;
		maxX = rightBoundery.x;
	}
	
	// Update is called once per frame
	void Update () {
		//player movement
		if (Input.GetKey(KeyCode.LeftArrow)){
			//Move player left
			transform.position += Vector3.left * shipSpeed * Time.deltaTime;
		}else if (Input.GetKey (KeyCode.RightArrow)) {
			//move player right
			transform.position += Vector3.right * shipSpeed * Time.deltaTime;
		}

		//clamps player to the play space
		float newShipX = Mathf.Clamp (transform.position.x, minX+0.5f, maxX-0.5f);
		transform.position = new Vector3(newShipX, transform.position.y, transform.position.z); 

	}
}
