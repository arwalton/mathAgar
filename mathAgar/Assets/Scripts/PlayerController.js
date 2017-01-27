#pragma strict

public var speed : float; //Floating point to store player mvmt speed

private var rb : Rigidbody2D;


function Start () {
	rb = GetComponent.<Rigidbody2D>();
	speed = 5;
}

function FixedUpdate () {
	var moveHorizontal = Input.GetAxis ("Horizontal");

	var moveVertical = Input.GetAxis("Vertical");

	var movement = new Vector2(moveHorizontal, moveVertical);

	rb.AddForce (movement * speed);
}


