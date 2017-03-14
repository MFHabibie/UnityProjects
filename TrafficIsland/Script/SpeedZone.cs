using UnityEngine;
using System.Collections;

public class SpeedZone : MonoBehaviour {

	private static float acceler;

	// Use this for initialization
	void Update(){
		acceler = AIpoints.accel;
	}

	void OnTriggerEnter(Collider other){
		if(other.tag == "Speed"){
			AIpoints.accel += 15.0f;
		}
	}
}
