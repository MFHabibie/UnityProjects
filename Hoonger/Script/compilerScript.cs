using UnityEngine;
using System.Collections;

public class compilerScript : MonoBehaviour {

	public Transform[] blockPlace;
	int placeIndex;

	public GameObject codeReader;

	public static bool codeReaderActive;

	public static bool readStatus;

	RaycastHit hit;

	// Use this for initialization
	void Start () {
		placeIndex = 0;
		codeReader.SetActive (false);
		codeReaderActive = false;
		codeReader.transform.position = new Vector3 (blockPlace[placeIndex].transform.position.x, codeReader.transform.position.y, codeReader.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {
			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) {
				if (hit.collider.gameObject == this.gameObject) {
					codeReaderActive = true;
				}
			}
		}

		if (codeReaderActive) {
			codeReader.SetActive (true);
		} 
		else {
			codeReader.SetActive (false);
		}

		if (readerScript.statusRead) {
			placeIndex++;
			codeReader.transform.position = new Vector3 (blockPlace [placeIndex].transform.position.x, codeReader.transform.position.y, codeReader.transform.position.z);
			readerScript.statusRead = false;
			//readStatus = false;
			readerScript.wait = 0.0f;
		}


	}
}
