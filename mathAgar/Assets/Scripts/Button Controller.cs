using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ButtonController : MonoBehaviour {

	public Text answerText;

	public void updateAnswer(){
		string buttonText = EventSystem.current.currentSelectedGameObject.name;
		if (buttonText == "Delete"){
			if (answerText.text != "0")
				answerText.text = answerText.text.Substring (0, answerText.text.Length - 1);

			if (answerText.text.Length == 0){
				answerText.text == 0;
			}
		}else if (buttonText == "Enter"){
			ModalPanel.
		}
	}
