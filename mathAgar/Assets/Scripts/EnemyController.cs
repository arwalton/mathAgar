using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public int value;

	// Use this for initialization
	void Start () {
		value = Random.Range (1, 10);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
