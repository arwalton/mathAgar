using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public string value;

	void Awake () {
		value = Random.Range (1, 10).ToString();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
