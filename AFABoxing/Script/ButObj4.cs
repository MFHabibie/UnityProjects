using UnityEngine;
using System.Collections;

public class ButObj4 : MonoBehaviour {

	RaycastHit hit;
	public GameObject Obj4;
	//public Light theLight;
	private HandController handController;
	
	void Start(){
		GameObject gameControllerObject = GameObject.FindWithTag ("HandControl");
		if (gameControllerObject != null) {
			handController = gameControllerObject.GetComponent <HandController>();
		}
	}
	
	/*public void OnCollisionEnter(Collision collision)
	{
		RigidHand leapObj = collision.gameObject.GetComponent<RigidHand>();
		
		if (leapObj)
		{
			Debug.Log(leapObj.maxVelocity.magnitude);
			GetComponent<Rigidbody>().AddForceAtPosition(leapObj.maxVelocity * 200, leapObj.transform.position);
			
		}
		Application.LoadLevel (4);
	}*/
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.collider.gameObject == Obj4) {
					Application.LoadLevel(4);
				}
			}
		}
	}

	void OnMouseEnter(){
		//GUIText text = text3D.GetComponent<TextMesh>;
		//text.color =
		//theLight.intensity = 8.0f;
	}

	void OnMouseExit(){
		//theLight.intensity = 0.0f;
	} 
}
