#pragma strict

	var Speed : float = 40;

function Update () {
	if(Input.GetButton("Vertical") && Input.GetAxis("Vertical") < 0){
		transform.position += Vector3 (-0.1,0,0);
	}

	if(Input.GetButton("Vertical") && Input.GetAxis("Vertical") > 0){
		transform.position += Vector3 (0.1,0,0);
	}

	if(Input.GetButton("Horizontal") && Input.GetAxis("Horizontal") < 0){
		transform.position += Vector3 (0,0,0.1);
	}

	if(Input.GetButton("Horizontal") && Input.GetAxis("Horizontal") > 0){
		transform.position += Vector3 (0,0,-0.1);
	}
	
}