#pragma strict

var tikganda:AudioClip;

function OnTriggerEnter(o:Collider){
	Debug.Log("The Trigger Fired");
	GetComponent.<AudioSource>().PlayOneShot(tikganda);
}