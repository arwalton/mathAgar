using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public GameObject player;

	private Vector3 offset;

	// Use this for initialization
	void Start () {
		offset = transform.position - player.transform.position;
	}
	
	// Makes the camera follow the player without spinning
	void LateUpdate () {
		transform.position = player.transform.position + offset;
	}
}
