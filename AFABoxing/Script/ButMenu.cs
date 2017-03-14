using UnityEngine;
using System.Collections;

public class ButMenu : MonoBehaviour {

	RaycastHit hit;
	public GameObject text3D;
	//public Light theLight;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKey(KeyCode.Escape))
		{
			Application.LoadLevel(1);
		}
	}

	void OnMouseEnter(){
		/*GUIText text = text3D.GetComponent<TextMesh>;
		text.color =*/ 
		//theLight.intensity = 8.0f;
	}

	void OnMouseExit(){
		//theLight.intensity = 0.0f;
	}
}
