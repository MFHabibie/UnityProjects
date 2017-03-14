﻿using UnityEngine;
using System.Collections;

public class ButNext : MonoBehaviour {

	RaycastHit hit;
	public GameObject text3D;
	public static int index = 1;
	public GameObject item1;
	public GameObject item2;
	public GameObject item3;
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
			index += 1;
			if(index==2){
				item1.transform.position = new Vector3(-120f,9.328636f,28.06268f);
				item2.transform.position = new Vector3(13f,9.328636f,28.06268f);
				item3.transform.position = new Vector3(150f,9.328636f,28.06268f);
			}
			if(index==4){
				item1.transform.position = new Vector3(-120f,9.328636f,28.06268f);
				item2.transform.position = new Vector3(-120f,9.328636f,28.06268f);
				item3.transform.position = new Vector3(7f,9.328636f,28.06268f);
			}
	}*/
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.collider.gameObject == text3D) {
					index += 1;
					if(index==2){
						item1.transform.position = new Vector3(-120f,9.328636f,28.06268f);
						item2.transform.position = new Vector3(13f,9.328636f,28.06268f);
						item3.transform.position = new Vector3(150f,9.328636f,28.06268f);
					}
					if(index==4){
						item1.transform.position = new Vector3(-120f,9.328636f,28.06268f);
						item2.transform.position = new Vector3(-120f,9.328636f,28.06268f);
						item3.transform.position = new Vector3(7f,9.328636f,28.06268f);
					}
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
