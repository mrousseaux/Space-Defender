using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {
	public float shipSpeed = 10f;

	private PlaySpace playSpace;
	// Use this for initialization
	void Start () {
		//bring in variables from the play space script. 
		playSpace = GameObject.FindObjectOfType<PlaySpace>();
	}
	
	// Update is called once per frame
	void Update () {
		//player movement
		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A)){
			//Move player left
			transform.position += Vector3.left * shipSpeed * Time.deltaTime;
		}else if (Input.GetKey (KeyCode.RightArrow) || Input.GetKey(KeyCode.D)) {
			//move player right
			transform.position += Vector3.right * shipSpeed * Time.deltaTime;
		}

		//clamps player to the play space
		float newShipX = Mathf.Clamp (transform.position.x, playSpace.minX+0.5f, playSpace.maxX-0.5f);
		transform.position = new Vector3(newShipX, transform.position.y, transform.position.z); 

	}
}
