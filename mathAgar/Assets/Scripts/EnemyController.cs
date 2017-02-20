using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : Character {
	//public int value;


	//protected RigidBody2D rb;

	private GameObject closestObject;

	private const float TARDELAY = 5f; //How many seconds before getting a new target
	private const float MAXSPEED = 10; //How fast the enemy is allowed to travel
	private const float SPEED = 1f; //The modifier to addForce
	private const float DETECTIONRADIUS = 20f;

	[SerializeField]
	private Vector3 target;

	void Awake () {
		rb = GetComponent<Rigidbody2D>();
		SetValue ();
	}

	void Start(){
		InvokeRepeating("SetRandomTarget", 0f, TARDELAY);
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
		value = Random.Range (1, 10);
	}

	public override void Move (){
		Collider2D[] nearChars = Physics2D.OverlapCircleAll (transform.position, DETECTIONRADIUS);
	//	Debug.Log (nearChars.Length);
		if (nearChars.Length > 1) {
			closestObject = GetClosestObject (nearChars);
			SetTarget (closestObject.transform.position);
		}
		//Seek ();
		Flee();
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
		return closestObject;
	}

	void OnTriggerEnter2D(Collider2D other){

	}

	public void EnemyCollision(GameObject other){
		int otherValue = other.gameObject.GetComponent (value);
		value += otherValue;
		other.gameObject.SetActive (false);
	}
	
}
