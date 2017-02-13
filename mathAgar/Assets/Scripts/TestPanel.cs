using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class TestPanel : MonoBehaviour {

	private ModalPanel modalPanel;
	private DisplayManager displayManager;

	private UnityAction myEnterAction;

	void Awake(){
		modalPanel = ModalPanel.Instance ();
		displayManager = DisplayManager.Instance ();

		myEnterAction = new UnityAction (testEnterFunction);
	}

	public void testEnterButton(){
		modalPanel.question (myEnterAction, "200");
	}

	void testEnterFunction(){
		displayManager.DisplayMessage ("You made the Enter button do something!");
	}

}
