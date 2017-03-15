using UnityEngine;
using System.Collections;

public class TriggerLog : MonoBehaviour {

	public GameObject tree;

	// Use this for initialization
	void Start () {
		if (PlayerController.moveActive) {
			tree.GetComponent<Rigidbody> ().drag = 15.0f;
		}
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void OnTriggerEnter(Collider obj){
		if (obj.gameObject.tag == "Player") {
			tree.GetComponent<Rigidbody> ().drag = 1.88f;
			Time.timeScale = 0.5f;
		}
	}

	void OnTriggerExit(Collider obj){
		if (obj.gameObject.tag == "Player") {
			Time.timeScale = 1.0f;
		}
	}
}
