using UnityEngine;
using System.Collections;

public class blockJump : MonoBehaviour {

	RaycastHit hit;
	public static Vector3 startPosition;
	public Transform charc;

	public static bool blockActive;

	public float moveStep;
	public float jumpHeight;
	public float speed;

	// Use this for initialization
	void Start () {
		startPosition = transform.position;

		blockActive = false;

		moveStep = 50.0f;
		jumpHeight = 5.0f;
		speed = 2.2f;
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

	public void charLoncat(){
		charc.transform.position = Vector3.MoveTowards (charc.transform.position, new Vector3 (charc.transform.position.x + moveStep, charc.transform.position.y, charc.transform.position.z), speed * Time.deltaTime);
		charc.transform.Translate (Vector3.up * jumpHeight * Time.deltaTime);
	}
}
