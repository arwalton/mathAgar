using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : Character {
	//public int value;
	//protected Rigidbody2D rb;
	public ButtonController buttonController;
	public GameObject movementTrigger;

	public string oper;

	private const float SPEED = 1.5f; //modifier to addForce
	private const float MAXSPEED = 13f; //How fast the player is allowed to travel
	private const float TILESKIP = 2.4f;
	private ModalPanel modalPanel;
	private GameObject enemy;
	private Vector3 mousePosition;
	private UnityAction myEnterAction;
	private DisplayManager displayManager;


	void Awake(){
//		rb = GetComponent<Rigidbody2D>();
		SetValue (1);
		SetOper ("+");
		modalPanel = ModalPanel.Instance ();
		displayManager = DisplayManager.Instance ();
	}

	// Use this for initialization
	void Start () {
		
	}

	//Used to perform regular actions, happens once per frame, so not always even intervals.
	void Update(){

	/*
		//caps the player velocity at MAXSPEED
		if (rb.velocity.magnitude > MAXSPEED) {
			rb.velocity = Vector3.ClampMagnitude (rb.velocity, MAXSPEED);
	
		}
	*/
	}

	//Used to control physics actions. Happens at even intervals
	void FixedUpdate () {
		Move ();

	}

	//Controls what happens when a player hits an enemy
	void OnTriggerEnter2D(Collider2D other){
		Time.timeScale = 0;
		enemy = other.gameObject.transform.parent.gameObject;
		if (enemy.gameObject.tag == "Enemy") {
			EventManager.StartListening ("Correct", CorrectAnswer);
			EventManager.StartListening ("Incorrect", IncorrectAnswer);
			EnemyController enemyCon = enemy.GetComponent<EnemyController> ();
			modalPanel.question (buttonController.CheckAnswer, enemyCon.value);
		}
	}

	public void OnTriggerEnter2DChild(Collider2D other){
		Time.timeScale = 0;
		enemy = other.gameObject.transform.parent.gameObject;
		if (enemy.gameObject.tag == "Enemy") {
			EventManager.StartListening ("Correct", CorrectAnswer);
			EventManager.StartListening ("Incorrect", IncorrectAnswer);
			EnemyController enemyCon = enemy.GetComponent<EnemyController> ();
			modalPanel.question (buttonController.CheckAnswer, enemyCon.value);
		}
	}


	//The player will follow the mouse or finger on the screen for movement
	public override void Move(){
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

	}

	void CorrectAnswer(){
		SetValue(value + enemy.GetComponent<EnemyController> ().value);
		enemy.SetActive(false);
		EventManager.StopListening ("Correct", CorrectAnswer);
		EventManager.StopListening ("Incorrect", IncorrectAnswer);
		Time.timeScale = 1;
	}

	void IncorrectAnswer(){
		EventManager.StopListening ("Correct", CorrectAnswer);
		EventManager.StopListening ("Incorrect", IncorrectAnswer);
		Time.timeScale = 1;
	}

	public override void SetValue(){
		value = 1;
	}

	public void SetValue (int val){
		value = val;
	}

	public void SetOper(string op){
		oper = op;
	}


}
