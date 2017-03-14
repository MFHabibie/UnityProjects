using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class ButTry5 : MonoBehaviour {
	
	private HandController handController;

	void Start(){
		GameObject gameControllerObject = GameObject.FindWithTag ("HandControl");
		if (gameControllerObject != null) {
			handController = gameControllerObject.GetComponent <HandController>();
		}
	}

	public void OnCollisionEnter(Collision collision)
	{
		RigidHand leapObj = collision.gameObject.GetComponent<RigidHand>();
		
		if (leapObj)
		{
			Debug.Log(leapObj.maxVelocity.magnitude);
			GetComponent<Rigidbody>().AddForceAtPosition(leapObj.maxVelocity * 200, leapObj.transform.position);

		}
		Application.LoadLevel (9);

		//sound.playOneShot ();
	}


	

}
