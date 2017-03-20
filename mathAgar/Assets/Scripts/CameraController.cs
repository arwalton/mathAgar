using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject MovementTrigger;

	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - MovementTrigger.transform.position;
	}
	
	// Makes the camera follow the player without spinning
	void LateUpdate () {
		transform.position = MovementTrigger.transform.position + offset;
	}
}
