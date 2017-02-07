using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public bool hasCollided;

	private Rigidbody2D rb;
	private int value;

	private const int SPEED = 5;

	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody2D>();
		value = 1;
	}

	// Controls the movement of the player
	void FixedUpdate () {
		float moveHorizontal = Input.GetAxis ("Horizontal");

		float moveVertical = Input.GetAxis("Vertical");

		Vector2 movement = new Vector2(moveHorizontal, moveVertical);

		rb.AddForce (movement * SPEED);
	}

	//Controls what happens when a player hits an enemy
	void OnTriggerEnter2D(Collider2D other){
		other.gameObject.SetActive (false);
	}
}
