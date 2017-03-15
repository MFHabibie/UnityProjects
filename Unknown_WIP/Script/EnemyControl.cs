using UnityEngine;
using System.Collections;

public class EnemyControl : MonoBehaviour {

	public GameObject target;

	public float moveSpeed;
	float distance;
	Quaternion rotation;
	Vector3 moveDirection;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		distance = Vector3.Distance (target.transform.position, transform.position);

		viewTarget ();
		chasingTarget ();
	}

	void viewTarget(){
		rotation = Quaternion.LookRotation (target.transform.position - transform.position);
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime);
	}

	void chasingTarget(){
		moveDirection = transform.forward;
		moveDirection *= moveSpeed;

		moveDirection.y -= Time.deltaTime;
		gameObject.GetComponent<CharacterController>().SimpleMove (moveDirection * Time.deltaTime);
	}
}
