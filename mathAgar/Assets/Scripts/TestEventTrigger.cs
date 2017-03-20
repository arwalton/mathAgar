using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestEventTrigger : MonoBehaviour {

	void Update () {
		if (Input.GetKeyDown ("q")) {
			EventManager.TriggerEvent ("test");
		}
	}
}
