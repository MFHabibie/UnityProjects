using UnityEngine;
using System.Collections;

public class Train : MonoBehaviour {


	public Transform[] wayPoint = new Transform[2]; //create an array for storing  each waypoints

	int currentTrainpoints = 0; //first way point which should go first

	//Comera
	float rotationSpeed = 6.0f;
	public static float accel = 6.0f;


	// Use this for initialization
	void Start () {
		//find each waypoint object when game loaded
		wayPoint [0] = GameObject.Find ("Trainpoint").transform; //index start from "0"
		wayPoint [1] = GameObject.Find ("Trainpoint1").transform;

	}

	// Update is called once per frame
	void Update () {

		//when reached the last waypoint
		if (currentTrainpoints == 2) {
			Destroy (this.gameObject);		
		} 
		else {
			walk ();
		}
	}

	//make camera move
	public void walk(){
		//facing direction
		//make camera look at the next waypoint
		Quaternion rotation = Quaternion.LookRotation(wayPoint[currentTrainpoints].position - transform.position);
		//control fast rotate
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * rotationSpeed);

		//movement
		Vector3 wayPointDirection = wayPoint[currentTrainpoints].position - transform.position;
		float speedElement = Vector3.Dot (wayPointDirection.normalized, transform.forward);
		float speed = accel * speedElement * 2;
		transform.Translate (0, 0, Time.deltaTime * speed);
	}

	//Use collider to trigger cam to the next waypoint
	void OnTriggerEnter(Collider collider){

		if (collider.tag == "Trainpoints")
			currentTrainpoints++;
	}
}
