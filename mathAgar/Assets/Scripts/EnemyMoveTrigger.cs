using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMoveTrigger : MonoBehaviour {

	private Rigidbody2D rb;
	private GameObject closestObject;
	private bool startMoving = false;
//	private List<GameObject> enemies;
	private bool isClosest;
	private GameObject player;

	private const float TARDELAY = 5f; //How many seconds before getting a new target
	private const float SPEED = 1.3f; //modifier to addForce
	private const float MAXSPEED = 10; //How fast the enemy is allowed to travel
	private const float DETECTIONRADIUS = 40f;

	[SerializeField]
	private Vector3 target;

	void Awake(){
//		enemies = EnemyManager.GetEnemies ();
		rb = GetComponent<Rigidbody2D> ();
		player = GameObject.FindGameObjectWithTag ("MoveTrigger");
	}

	// Use this for initialization
	void Start () {
		InvokeRepeating("SetRandomTarget", 0f, TARDELAY);
		InvokeRepeating("PlayerWarning", 0f, .2f);
//		StartCoroutine ("ProximityCheck");
	}
	
	// Update is called once per frame
	void Update () {
		//caps the enemy velocity at MAXSPEED
		if (rb.velocity.magnitude > MAXSPEED) {
			rb.velocity = Vector3.ClampMagnitude (rb.velocity, MAXSPEED);
		}
	}

	void FixedUpdate(){
		if (startMoving) {
			Move ();
		}
	}

	void Move(){
		if (isClosest) {
			Flee ();
		} else {
			Seek ();
		}

	/*	Collider2D[] nearChars = Physics2D.OverlapCircleAll (transform.position, DETECTIONRADIUS,8);
			Debug.Log (nearChars.Length);
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
	//	}*/
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

//	private GameObject GetClosestObject(Collider2D[] nearChars){
//		foreach (Collider2D col in nearChars) {
//			if (col.transform.position != transform.position) {
//				if (!closestObject) {
//					closestObject = col.gameObject;
//				} else {
//					if (Vector3.Distance (transform.position, col.gameObject.transform.position) <
//						Vector3.Distance (transform.position, closestObject.transform.position)) { 
//						closestObject = col.gameObject;
//					}
//				}
//			}
//		}
//		return closestObject;
//	}

	public void StartMoving (){
		startMoving = true;
	}

	/*
	public GameObject GetClosest(){
		GameObject closest = null;
		GameObject self = null;
		foreach(GameObject enemy in enemies){
			float dist = Vector3.Distance (transform.position, enemy.transform.position);
			if (dist < DETECTIONRADIUS){
				if (!self) {
					self = enemy;
				}else if(!closest){
					if (dist < Vector3.Distance (transform.position, self.transform.position)) {
						closest = self;
						self = enemy;
					} else {
						closest = enemy;
					}
				} else if (dist < Vector3.Distance (transform.position, self.transform.position)) {
					closest = self;
					self = enemy;
				} else if (dist < Vector3.Distance(transform.position, closest.transform.position)){
					closest = enemy;
				}
			}
		}
		return closest;
	}

	IEnumerator ProximityCheck(){
		GameObject closest = GetClosest ();
		if (closest) {
			target = closest.transform.position;
			isClosest = true;
		} else {
			isClosest = false;
		}
		yield return new WaitForSeconds(.2f);
	}
	*/

	void PlayerWarning(){
		if (Mathf.Abs (Vector3.Distance (transform.position, player.transform.position)) < DETECTIONRADIUS) {
			target = player.transform.position;
			isClosest = true;
		} else {
			isClosest = false;
		}
	}
}
