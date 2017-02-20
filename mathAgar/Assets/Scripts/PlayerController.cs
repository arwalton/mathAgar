using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : Character {
	//public int value;
	//protected Rigidbody2D rb;
	public ButtonController buttonController;

	public string oper;

	private const float SPEED = 1.5f; //modifier to addForce
	private const float MAXSPEED = 13; //How fast the enemy is allowed to travel
	private ModalPanel modalPanel;
	private GameObject enemy;
	private Vector3 mousePosition;
	private UnityAction myEnterAction;
	private DisplayManager displayManager;

	[SerializeField]
	private bool isCorrect; //Makes it visible in the inspector, but it's still private


	void Awake(){
		rb = GetComponent<Rigidbody2D>();
		SetValue ();
		SetOper ();
		isCorrect = false;
		modalPanel = ModalPanel.Instance ();
		myEnterAction = new UnityAction (CheckAnswer);
		displayManager = DisplayManager.Instance ();
	}

	// Use this for initialization
	void Start () {
		
	}

	//Used to perform regular actions, happens once per frame, so not always even intervals.
	void Update(){
		//Checks if the question has been answered correctly, deactivates the enemy if
		//it has and unpauses the game
		if (isCorrect) {
			enemy.SetActive(false);
			isCorrect = false;
			Time.timeScale = 1;
		}

		//caps the player velocity at MAXSPEED
		if (rb.velocity.magnitude > MAXSPEED) {
			rb.velocity = Vector3.ClampMagnitude (rb.velocity, MAXSPEED);
		}
	}

	//Used to control physics actions. Happens at even intervals
	void FixedUpdate () {
		Move ();


		/*
		 * Old code, basic keyboard input, to be deleted when I'm happy with current movement
		float moveHorizontal = Input.GetAxis ("Horizontal");

		float moveVertical = Input.GetAxis("Vertical");

		Vector2 movement = new Vector2(moveHorizontal, moveVertical);

		rb.AddForce (movement * SPEED);
		*/
	}

	//Controls what happens when a player hits an enemy
	void OnTriggerEnter2D(Collider2D other){
		Time.timeScale = 0;
		enemy = other.gameObject;
		string tag = other.gameObject.tag;
		if (tag == "Enemy") {
			EnemyController enemyCon = other.GetComponent<EnemyController> ();
			modalPanel.question (myEnterAction, enemyCon.value);
		}
	}

	//Calls the buttonController to check the answer and set the flag.
	void CheckAnswer(){
		isCorrect = buttonController.CheckAnswer ();
		/*
		 * For Testing
		if (isCorrect) {
			displayManager.DisplayMessage ("You did it right.");
		} else {
			displayManager.DisplayMessage ("NOOOOOPE.");
		}
		*/
	}

	//The player will follow the mouse or finger on the screen for movement
	public override void Move(){
		mousePosition = Camera.main.ScreenToWorldPoint (Input.mousePosition);
		Vector2 movement = (mousePosition - transform.position).normalized;
		rb.AddForce (movement * SPEED);
	}

	public override void SetValue ()
	{
		value = 1;
	}

	public void SetOper(){
		oper = "+";
	}


}
