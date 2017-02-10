using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerController : MonoBehaviour {
	public ButtonController buttonController;

	private Rigidbody2D rb;
	private int value;

	private const int SPEED = 5;
	private ModalPanel modalPanel;
	private DisplayManager displayManager;
	private bool isCorrect;

	private UnityAction myEnterAction;


	void Awake(){
		rb = GetComponent<Rigidbody2D>();
		value = 1;
		isCorrect = false;
		modalPanel = ModalPanel.Instance ();
		displayManager = DisplayManager.Instance ();

		myEnterAction = new UnityAction (checkAnswer);
	}

	// Use this for initialization
	void Start () {
		
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
		modalPanel.question (myEnterAction);

//		other.gameObject.SetActive (false);
	}

	void checkAnswer(){
		isCorrect = buttonController.checkAnswer ();
		displayManager.DisplayMessage ("You did a thing, sort of...");
	}
}
