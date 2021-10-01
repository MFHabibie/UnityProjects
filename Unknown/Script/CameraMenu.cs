using UnityEngine;
using System.Collections;

public class CameraMenu : MonoBehaviour {

	Vector3 firstPosition;

	// Use this for initialization
	void Start () {
		firstPosition = new Vector3 (0.0f, 38.0f, -10.0f);
	}
	
	// Update is called once per frame
	void Update () {
		DelayMove ();
	}

	void DelayMove(){
		gameObject.transform.position = Vector3.Lerp (firstPosition, new Vector3 (0.0f, -6.0f, -10.0f), Time.time * 0.1f);
	}
}
