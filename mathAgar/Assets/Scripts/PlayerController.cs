using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour {
	public ButtonController buttonController;

	private Rigidbody2D rb;
	public string value;
	public string oper;

	private const int SPEED = 5;
	private ModalPanel modalPanel;
	private DisplayManager displayManager;
	private GameObject enemy;

	[SerializeField]
	private bool isCorrect;

	private UnityAction myEnterAction;


	void Awake(){
		rb = GetComponent<Rigidbody2D>();
		value = "1";
		oper = "+";
		isCorrect = false;
		modalPanel = ModalPanel.Instance ();
		displayManager = DisplayManager.Instance ();

		myEnterAction = new UnityAction (checkAnswer);
	}

	// Use this for initialization
	void Start () {
		
	}

	void Update(){
		if (isCorrect) {
			enemy.SetActive(false);
			isCorrect = false;
		}
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
		enemy = other.gameObject;
		string tag = other.gameObject.tag;
		if (tag == "Enemy") {
			EnemyController enemy = other.GetComponent<EnemyController> ();
			modalPanel.question (myEnterAction, enemy.value);
		}
	}

	void checkAnswer(){
		isCorrect = buttonController.checkAnswer ();
		if (isCorrect) {
			displayManager.DisplayMessage ("You did it right.");
		} else {
			displayManager.DisplayMessage ("NOOOOOPE.");
		}
	}
}
