using UnityEngine;
using System.Collections;

public class blockCrawl : MonoBehaviour {
	
	RaycastHit hit;
	public static Vector3 startPosition;
	public static bool blockActive;
	public Transform charc;
	public GameObject Human;
	BoxCollider collidHuman;

	public float moveStep;

	// Use this for initialization
	void Start () {
		startPosition = transform.position;

		blockActive = false;
		moveStep = 50.0f;
	}

	// Update is called once per frame
	void Update () {
		if (Input.GetMouseButton (0)) {

			Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (ray, out hit)) {
				if (hit.collider.gameObject == this.gameObject) {
					blockActive = false;
				}
			}
		}
	}

	void OnMouseDrag(){
		if (!blockActive) {
			moveBlock ();
		}
	}

	void OnMouseUp(){
		if (!blockActive) {
			transform.position = startPosition;
		}
	}

	public void moveBlock(){
		var posVec = Input.mousePosition;
		posVec.z = transform.position.z - Camera.main.transform.position.z;
		posVec = Camera.main.ScreenToWorldPoint(posVec);

		transform.position = Vector3.MoveTowards(transform.position, posVec, Time.maximumDeltaTime);
	}

	public void charTiarap(){
		charc.transform.position = Vector3.MoveTowards (charc.transform.position, new Vector3 (charc.transform.position.x + moveStep, charc.transform.position.y, charc.transform.position.z), Time.deltaTime);

		collidHuman = Human.GetComponent<BoxCollider>();

		collidHuman.size = new Vector3(0.07f,0.05f,0.07f);
		collidHuman.center = new Vector3(0f,0.02f,-0.03f);
	}

	public void charBangun(){
		collidHuman = Human.GetComponent<BoxCollider>();

		collidHuman.size = new Vector3(0.07f,0.115f,0.07f);
		collidHuman.center = new Vector3(0f,0.05f,-0.03f);
	}
}
