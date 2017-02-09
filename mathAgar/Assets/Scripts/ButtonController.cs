using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;


public class ButtonController : MonoBehaviour {

	public Text answerText;
	public Text pIntText;
	public Text operText;
	public Text eIntText;
	public bool isCorrect;

	public void updateAnswer(){
		string buttonText = EventSystem.current.currentSelectedGameObject.name;
		if (buttonText == "Delete") {
			if (answerText.text != "0")
				answerText.text = answerText.text.Substring (0, answerText.text.Length - 1);

			if (answerText.text.Length == 0) {
				answerText.text = "0";
			}
		} else {
			if (answerText.text == "0") {
				answerText.text = buttonText;
			} else {
				answerText.text = answerText.text + buttonText;
			}
		}
	}

	public void checkAnswer(){
		string oper = operText.text;
		int answer = Convert.ToInt32(answerText.text);
		int pInt = Convert.ToInt32(pIntText.text);
		int eInt = Convert.ToInt32(eIntText.text);

		switch (oper)	{
		case "-":
			if (answer == pInt - eInt) {
				isCorrect = true;
			}
			break;
		case "*":
			if (answer == pInt * eInt) {
				isCorrect = true;
			}
			break;
		case "/":
			if (answer == pInt / eInt) {
				isCorrect = true;
			}
			break;
		case "+": 
		default:
			if (answer == pInt + eInt) {
				isCorrect = true;
			}
			break;
		}
	}
}