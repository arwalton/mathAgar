#pragma strict

public var speed : float; //Floating point to store player mvmt speed
public var hasCollided : boolean;

private var rb : Rigidbody2D; //Holds the rigidbody component of the player
private var value : int;


function Start () {
	rb = GetComponent.<Rigidbody2D>();
	speed = 5;
	value = 1;
}

//Controls the movement of the player
function FixedUpdate () {
	var moveHorizontal = Input.GetAxis ("Horizontal");

	var moveVertical = Input.GetAxis("Vertical");

	var movement = new Vector2(moveHorizontal, moveVertical);

	rb.AddForce (movement * speed);
}

//Controls what happens when a player hits an enemy
function OnTriggerEnter2D(other: Collider2D){
	
	other.gameObject.SetActive(false);
}

//