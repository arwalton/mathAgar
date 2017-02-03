#pragma strict

public var player : GameObject;

private var offset : Vector3;


function Start () {
	offset = transform.position - player.transform.position;
}

//Makes the camera follow the player without spinning
function LateUpdate () {
	transform.position = player.transform.position + offset;
}
