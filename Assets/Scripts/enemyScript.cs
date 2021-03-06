﻿using UnityEngine;
using System.Collections;

public class enemyScript : MonoBehaviour {
	public float health = 150f;
	public GameObject laserShot;
	public AudioClip audioHit;
	public float fireRate = 0.0001f;
	public int points = 50;
	public static int score;

	void start(){
		score = 0;
	}

	void OnTriggerEnter2D (Collider2D col){
		ProjectileScript laser = col.gameObject.GetComponent<ProjectileScript>();
		//if laser is a projectile, then do damage
		if(laser){
			//Debug.Log ("Enemy Hit Detected");
			health -= laser.damage;
			laser.Hit();
			AudioSource.PlayClipAtPoint(audioHit, transform.position, 0.5f);
			if(health <= 0f){
				//Debug.Log (gameObject+" destroyed.");
				score = score + points;
				print("Score: " + score);
				Destroy (gameObject);
			}
		}
	}

	void Update (){
		//fires enemy laser based on the probablity per second that the laser will go off. 
		float probability = Time.deltaTime * fireRate;
		if(Random.value < probability){
			FireLaser();
		}
	}
	void FireLaser(){
		GameObject laserFire = Instantiate (laserShot, new Vector3(transform.position.x,transform.position.y - 0.5f, transform.position.z), Quaternion.Euler(0,0,180)) as GameObject;
		laserFire.rigidbody2D.velocity = new Vector3(0f,-10f,0f);
		audio.Play ();
	}
}
