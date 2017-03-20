using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementTriggerController : MonoBehaviour {

	private Rigidbody2D rb;

	private const float SPEED = 1.5f; //modifier to addForce
	private const float MAXSPEED = 13; //How fast the enemy is allowed to travel
	private Vector3 mousePosition;

	void Awake(){
		rb = GetComponent<Rigidbody2D>();
	}

	void Update(){

		//caps the player velocity at MAXSPEED
		if (rb.velocity.magnitude > MAXSPEED) {
			rb.velocity = Vector3.ClampMagnitude (rb.velocity, MAXSPEED);
		}
	}

	void FixedUpdate () {
		Move ();
	}

	void Move(){
		mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector2 movement = (mousePosition - transform.position).normalized;
		rb.AddForce (movement * SPEED);
	}
}
