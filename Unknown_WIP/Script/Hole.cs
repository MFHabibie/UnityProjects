using UnityEngine;
using System.Collections;

public class Hole : MonoBehaviour {

	public static bool takeHole;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter(Collider other){
		if (other.gameObject.tag == "Player") {
			CameraControl.targeting = false;
			takeHole = true;
		}
	}
}
