using UnityEngine;
using System.Collections;

public class Butlvl1 : MonoBehaviour {

	RaycastHit hit;
	public GameObject Obj;
	private HandController handController;
	// Use this for initialization
	void Start(){
		GameObject gameControllerObject = GameObject.FindWithTag ("HandControl");
		if (gameControllerObject != null) {
			handController = gameControllerObject.GetComponent <HandController>();
		}
	}
	
	/*public void OnCollisionEnter(Collision collision)
	{
		RigidHand leapObj = collision.gameObject.GetComponent<RigidHand>();
		
		/*if (leapObj)
		{
			Debug.Log(leapObj.maxVelocity.magnitude);
			rigidbody.AddForceAtPosition(leapObj.maxVelocity * 200, leapObj.transform.position);

		}
		
		//sound.playOneShot ();
		Application.LoadLevel (7);
	}*/
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.collider.gameObject == Obj) {
					Application.LoadLevel(7);
				}
			}
		}
	}

	void OnMouseEnter(){

	}
	
	void OnMouseExit(){

	}
}
