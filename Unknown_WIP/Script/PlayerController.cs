using UnityEngine;
using System.Collections;

public class PlayerController : MonoBehaviour {

	public float movementSpeed;
	public float jumpStrength;
	float constantSpeed;
	bool countTimeLeft;
	bool countTimeRight;
	bool move;
	public static bool isGrounded;
	public static bool moveActive;

	// Use this for initialization
	void Start () {
		constantSpeed = movementSpeed;
		countTimeLeft = false;
		move = false;

		if (Application.loadedLevel == 2) {
			moveActive = false;
		} 
		else {
			moveActive = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (CameraControl.enemyAppear) {
			gameObject.GetComponent<Animator> ().SetBool ("Shock", true);
		}

		if (Hole.takeHole) {
			gameObject.GetComponent<Animator> ().SetBool ("Fall", true);
		} 

		if (moveActive) {
			if (move) {
				gameObject.GetComponent<Animator> ().SetBool ("Run", true);
				movement (movementSpeed, countTimeRight);
			}

			if (Input.GetKey (KeyCode.A)) {
				movement (-movementSpeed, countTimeLeft);
				move = false;
				//transform.eulerAngles = new Vector2 (0, -90);
			} else if (Input.GetKeyUp (KeyCode.A)) {
				countTimeLeft = true;
				//transform.eulerAngles = new Vector2 (0, 90);
			}

			if (Input.GetKey (KeyCode.W)) {
				if (isGrounded) {
					jump ();
				}
			}

			if (Input.GetKey (KeyCode.S)) {
			
			}

			if (Input.GetKey (KeyCode.D)) {
				move = true;
			}
		}

		if (countTimeLeft) {
			transform.position = Vector3.Lerp (transform.position, new Vector3 (transform.position.x - movementSpeed, transform.position.y, transform.position.z), Time.deltaTime);
			movementSpeed -= 0.1f;
			if (movementSpeed < 0.1f) {
				movementSpeed = 0.0f;
				countTimeLeft = false;
				move = true;
			}
		}
		else if (countTimeRight) {
			transform.position = Vector3.Lerp (transform.position, new Vector3 (transform.position.x + movementSpeed, transform.position.y, transform.position.z), Time.deltaTime);
			movementSpeed -= 0.1f;
			if (movementSpeed < 0.1f) {
				movementSpeed = 0.0f;
				countTimeRight = false;
			}
		}
	}

	void movement(float direct, bool countTime){
		countTime = false;
		movementSpeed = constantSpeed;
		transform.position = Vector3.Lerp (transform.position, new Vector3 (transform.position.x + direct, transform.position.y, transform.position.z), Time.deltaTime);
	}

	void jump (){
		gameObject.GetComponent<Animator> ().SetBool ("Jump", true);
		gameObject.GetComponent<Rigidbody> ().velocity = new Vector2 (0.0f, jumpStrength);
	}

	void OnCollisionEnter(Collision colid){
		if (colid.gameObject.tag == "Ground") {
			gameObject.GetComponent<Animator> ().SetBool ("Jump", false);
			isGrounded = true;
		}

		if (colid.gameObject.tag == "Chaser") {
			moveActive = false;
			gameObject.GetComponent<Animator> ().SetBool ("Hit", true);
		}
	}
		
	void OnCollisionExit(Collision colid){
		if (colid.gameObject.tag == "Ground") {
			isGrounded = false;
		}
	}
}
