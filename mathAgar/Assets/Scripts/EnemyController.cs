using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Character {
	//public string value;


	//protected RigidBody2D rb;

	private const float TARDELAY = 5f; //How many seconds before getting a new target
	private const float MAXSPEED = 10; //How fast the enemy is allowed to travel
	private const float SPEED = .1f; //The modifier to addForce

	[SerializeField]
	private Vector3 target;

	void Awake () {
		rb = GetComponent<Rigidbody2D>();
		SetValue ();
	}

	void Start(){
		InvokeRepeating("SetTarget", 0f, TARDELAY);
	}
	
	// Update is called once per frame
	void Update () {
		if (rb.velocity.magnitude > MAXSPEED) {
			rb.velocity = Vector3.ClampMagnitude (rb.velocity, MAXSPEED);
		}
	}

	void LateUpdate(){
		Move ();
	}

	public override void SetValue ()
	{
		value = Random.Range (1, 10).ToString();
	}

	public override void Move ()
	{
		Seek ();
	}

	//Go to the target point
	public void Seek(){
		Vector2 movement = target - transform.position;
		rb.AddForce (movement * SPEED);
	}

	//pick a new Target for the enemy every so many seconds
	private void SetTarget(){
		target = new Vector3 (Random.Range (-300f,300f), Random.Range (-300f,300f), 0f);
	}
}
