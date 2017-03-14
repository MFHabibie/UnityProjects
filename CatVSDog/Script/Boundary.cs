using UnityEngine;
using System.Collections;

public class Boundary : MonoBehaviour {

	public GameObject bone;
	public GameObject fishBone;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerExit2D(Collider2D obj){
		if (obj.gameObject.tag == "Bone") {
			Destroy (bone.gameObject);
		}

		if (obj.gameObject.tag == "Fishbone") {
			Destroy (fishBone.gameObject);
		}
	}
}
