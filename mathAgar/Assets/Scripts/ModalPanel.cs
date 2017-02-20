using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class ModalPanel : MonoBehaviour {

	public PlayerController player;
	public Text pInt;
	public Text oper;
	public Text eInt;
	public Text answer;
	public Button enter;
	public GameObject modalPanelObject;


	private static ModalPanel modalPanel;

	public static ModalPanel Instance(){
		if (!modalPanel) {
			modalPanel = FindObjectOfType (typeof(ModalPanel)) as ModalPanel;
			if (!modalPanel) {
				Debug.LogError ("There needs to be one active ModalPanel script on a GameObject in the scene.");
			}
		}
		return modalPanel;
	}

	public void question (UnityAction enterEvent, int enemyVal){
		modalPanelObject.SetActive (true);
		pInt.text = player.value.ToString();
		eInt.text = enemyVal.ToString();
		oper.text = player.oper;

		enter.onClick.RemoveAllListeners ();
		enter.onClick.AddListener (enterEvent);
		enter.onClick.AddListener (ClosePanel);

	}

	private void ClosePanel(){
		modalPanelObject.SetActive (false);
	}
}
