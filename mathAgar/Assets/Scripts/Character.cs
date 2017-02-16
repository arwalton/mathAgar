using System.Collections;
using System.Collections.Generic;
using UnityEngine;

abstract public class Character : MonoBehaviour {

	public string value;

	protected Rigidbody2D rb;

	abstract public void Move ();

	abstract public void SetValue();

}
