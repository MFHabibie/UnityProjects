using UnityEngine;
using System.Collections;

public class ButObj6 : MonoBehaviour {

	RaycastHit hit;
	public GameObject Obj6;
	public Texture textur2;
	public Texture textur1;
	//public Light theLight;
	private HandController handController;
	
	void Start(){
		GameObject gameControllerObject = GameObject.FindWithTag ("HandControl");
		if (gameControllerObject != null) {
			handController = gameControllerObject.GetComponent <HandController>();
		}
		if(ScoreManage5.score5<=25000){
			Obj6.GetComponent<Renderer>().material.mainTexture = textur1;
		}
		else{
			Obj6.GetComponent<Renderer>().material.mainTexture = textur2;
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
		if(Obj6.GetComponent<Renderer>().material.mainTexture == textur2){
			Application.LoadLevel(10);
		}
	}
	
	// Update is called once per frame
	/*void Update () {
		if (Input.GetMouseButton(0))
		{
			Ray ray = Camera.mainCamera.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.collider.gameObject == Obj6) {
					Application.LoadLevel(10);
				}
			}
		}
	}

	void OnMouseEnter(){
		/*GUIText text = text3D.GetComponent<TextMesh>;
		text.color = 
		//theLight.intensity = 8.0f;
	}

	void OnMouseExit(){
		//theLight.intensity = 0.0f;
	}*/ 
}
