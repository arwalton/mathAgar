using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EyeController : MonoBehaviour {

	void Start () {
		
	}

	// Update is called once per frame
	void Update () {
		LookAt2D ();
	}

	void LookAt2D(){
		Vector3 dir = Camera.main.ScreenToWorldPoint (Input.mousePosition) - transform.position;
		float angle = Mathf.Atan2 (dir.y, dir.x) * Mathf.Rad2Deg;
		transform.rotation = Quaternion.AngleAxis (angle, Vector3.forward);
	}

}
