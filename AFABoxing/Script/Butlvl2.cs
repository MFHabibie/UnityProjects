using UnityEngine;
using System.Collections;

public class Butlvl2 : MonoBehaviour {

	RaycastHit hit;
	public GameObject Obj;
	public Texture textur2;
	public Texture textur1;
	private ScoreManage scorr;
	private HandController handController;
	// Use this for initialization
	void Start () {
		GameObject gameControllerObject = GameObject.FindWithTag ("HandControl");
		if (gameControllerObject != null) {
			handController = gameControllerObject.GetComponent <HandController>();
		}
		scorr = gameObject.GetComponent<ScoreManage>();
		if(ScoreManage3.score3<=20000){
			Obj.GetComponent<Renderer>().material.mainTexture = textur1;
		}
		else{
			Obj.GetComponent<Renderer>().material.mainTexture = textur2;
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
		if(Obj.GetComponent<Renderer>().material.mainTexture == textur2){
			Application.LoadLevel(11);
		}
	}*/
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.collider.gameObject == Obj) {
					if(Obj.GetComponent<Renderer>().material.mainTexture == textur2){
					Application.LoadLevel(11);
					}
				}
			}
		}
	}

	void OnMouseEnter(){

	}
	
	void OnMouseExit(){

	}
}
