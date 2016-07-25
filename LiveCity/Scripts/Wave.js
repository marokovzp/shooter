#pragma strict

function Start () {
	animation["Wave"].layer = 1;
	animation["Wave"].wrapMode = WrapMode.Once;
}

function Update () {
	if(Input.GetKeyDown("e")){
	animation.Play("Wave");
	}
}


