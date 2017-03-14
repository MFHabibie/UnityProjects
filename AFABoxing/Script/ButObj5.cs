using UnityEngine;
using System.Collections;

public class ButObj5 : MonoBehaviour {

	RaycastHit hit;
	public GameObject Obj5;
	public Texture textur2;
	public Texture textur1;
	//public Light theLight;
	private HandController handController;
	
	void Start(){
		GameObject gameControllerObject = GameObject.FindWithTag ("HandControl");
		if (gameControllerObject != null) {
			handController = gameControllerObject.GetComponent <HandController>();
		}
		if(ScoreManage4.score4<=25000){
			Obj5.GetComponent<Renderer>().material.mainTexture = textur1;
		}
		else{
			Obj5.GetComponent<Renderer>().material.mainTexture = textur2;
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
		if(Obj5.GetComponent<Renderer>().material.mainTexture == textur2){
			Application.LoadLevel(9);
		}
	}
	
	// Update is called once per frame
	/*void Update () {
		if (Input.GetMouseButton(0))
		{
			Ray ray = Camera.mainCamera.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.collider.gameObject == Obj5) {
					Application.LoadLevel(9);
				}
			}
		}
	}

	void OnMouseEnter(){
		GUIText text = text3D.GetComponent<TextMesh>;
		text.color =
		//theLight.intensity = 8.0f;
	}

	void OnMouseExit(){
		//theLight.intensity = 0.0f;
	}*/ 
}
