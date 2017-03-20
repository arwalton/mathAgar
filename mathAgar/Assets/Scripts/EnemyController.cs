using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//*****Important*****
//Enemies must be spawned with 

public class EnemyController : Character {
	//public int value;
	//protected RigidBody2D rb;

	//private GameObject closestObject;
	private EnemyMoveTrigger movementTrigger; //****When you instantiate an enemy, you must make a
										//movement trigger first, or else it will totally break.

	private const float TARDELAY = 5f; //How many seconds before getting a new target
	private const float MAXSPEED = 10; //How fast the enemy is allowed to travel
	private const float SPEED = 1f; //The modifier to addForce
	private const float DETECTIONRADIUS = 20f;
	private const float TILESKIP = 2.4f;

//	[SerializeField]
//	private Vector3 target;

	void Awake () {
//		rb = GetComponent<Rigidbody2D>();
		movementTrigger = GetMovementTrigger();
		SetValue ();
	}

	void Start(){
//		InvokeRepeating("SetRandomTarget", 0f, TARDELAY);
		StartMoving();
	}
	
	// Update is called once per frame
	void Update () {
//		if (rb.velocity.magnitude > MAXSPEED) {
//			rb.velocity = Vector3.ClampMagnitude (rb.velocity, MAXSPEED);
//		}

	}

	void FixedUpdate(){
		Move ();
	}

	public override void SetValue ()
	{
		value = Random.Range (1, 10);
	}

	public override void Move (){
		if (transform.position.x - movementTrigger.transform.position.x > TILESKIP / 2) {
			transform.position += new Vector3 (-TILESKIP, 0, 0);
		} else if (transform.position.x - movementTrigger.transform.position.x < -TILESKIP / 2) {
			transform.position += new Vector3 (TILESKIP, 0, 0);
		}

		if (transform.position.y - movementTrigger.transform.position.y > TILESKIP / 2) {
			transform.position += new Vector3 (0, -TILESKIP, 0);
		} else if (transform.position.y - movementTrigger.transform.position.y < -TILESKIP / 2) {
			transform.position += new Vector3 (0, TILESKIP, 0);
		}

/*
 * Little bit of testing here, I'm going to add an enemy movement trigger to the enemy and see if
 * it will follow it the way that the player does.
 * 
		Collider2D[] nearChars = Physics2D.OverlapCircleAll (transform.position, DETECTIONRADIUS,8);
	//	Debug.Log (nearChars.Length);
		if (nearChars.Length > 1) {
			closestObject = GetClosestObject (nearChars);
			SetTarget (closestObject.transform.position);
			if (closestObject.tag == "Enemy") {
				Flee ();
			} else {
				//Add more logic here to make it chase player sometimes and not other times.
				Seek ();
			}
		} else {
			Seek ();
		}
	}

	//Go to the target point
	public void Seek(){
		Vector2 movement = (target - transform.position).normalized;
		rb.AddForce (movement * SPEED);
	}

	public void Flee(){
		Vector2 movement = -(target - transform.position).normalized;
		rb.AddForce(movement * SPEED);
	}

	//pick a new Target for the enemy every so many seconds
	private void SetRandomTarget(){
		SetTarget(new Vector3 (Random.Range (-300f,300f), Random.Range (-300f,300f), 0f));
	}

	private void SetTarget(Vector3 newTarget){
		target = newTarget;
	}

	//Gets the closets game object. Will break if you pass it nearChars with a lenght of 1.
	private GameObject GetClosestObject(Collider2D[] nearChars){
		foreach (Collider2D col in nearChars) {
			if (col.transform.position != transform.position) {
				if (!closestObject) {
					closestObject = col.gameObject;
				} else {
					if (Vector3.Distance (transform.position, col.gameObject.transform.position) <
					    Vector3.Distance (transform.position, closestObject.transform.position)) { 
						closestObject = col.gameObject;
					}
				}
			}
		}
		return closestObject;*/
	}

	EnemyMoveTrigger GetMovementTrigger(){
		GameObject[] moveTriggers = GameObject.FindGameObjectsWithTag("EnemyMoveTrigger");
		foreach (GameObject trig in moveTriggers) {
			if (trig.transform.position == transform.position) {
				movementTrigger = trig.GetComponent<EnemyMoveTrigger> ();
				break;
			}
		}
		return movementTrigger;
	}

	void StartMoving(){
		movementTrigger.StartMoving ();
	}
}
