using UnityEngine;
using System.Collections;

public class Detection : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider obj){
		if (obj.gameObject.tag == "Chaser") {
			CameraControl.enemyAppear = true;
		}
	}
}
