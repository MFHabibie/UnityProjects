using UnityEngine;
using System.Collections;

public class AIpoints : MonoBehaviour {


	public Transform[] wayPoint = new Transform[99]; //create an array for storing  each waypoints

	int currentWaypoints = 0; //first way point which should go first

	//Comera
	float rotationSpeed = 6.0f;
	public static float accel = 6.0f;


	// Use this for initialization
	void Start () {
		//find each waypoint object when game loaded
		wayPoint [0] = GameObject.Find ("Waypoint").transform; //index start from "0"
		wayPoint [1] = GameObject.Find ("Waypoint1").transform;
		wayPoint [2] = GameObject.Find ("Waypoint2").transform;
		wayPoint [3] = GameObject.Find ("Waypoint3").transform;
		wayPoint [4] = GameObject.Find ("Waypoint4").transform;
		wayPoint [5] = GameObject.Find ("Waypoint5").transform;
		wayPoint [6] = GameObject.Find ("Waypoint6").transform;
		wayPoint [7] = GameObject.Find ("Waypoint7").transform;
		wayPoint [8] = GameObject.Find ("Waypoint8").transform;
		wayPoint [9] = GameObject.Find ("Waypoint9").transform;
		wayPoint [10] = GameObject.Find ("Waypoint10").transform;
		wayPoint [11] = GameObject.Find ("Waypoint11").transform;
		wayPoint [12] = GameObject.Find ("Waypoint12").transform;
		wayPoint [13] = GameObject.Find ("Waypoint13").transform;
		wayPoint [14] = GameObject.Find ("Waypoint14").transform;
		wayPoint [15] = GameObject.Find ("Waypoint15").transform;
		wayPoint [16] = GameObject.Find ("Waypoint16").transform;
		wayPoint [17] = GameObject.Find ("Waypoint17").transform;
		wayPoint [18] = GameObject.Find ("Waypoint18").transform;
		wayPoint [19] = GameObject.Find ("Waypoint19").transform;
		wayPoint [20] = GameObject.Find ("Waypoint20").transform;
		wayPoint [21] = GameObject.Find ("Waypoint21").transform;
		wayPoint [22] = GameObject.Find ("Waypoint22").transform;
		wayPoint [23] = GameObject.Find ("Waypoint23").transform;
		wayPoint [24] = GameObject.Find ("Waypoint24").transform;
		wayPoint [25] = GameObject.Find ("Waypoint25").transform;
		wayPoint [26] = GameObject.Find ("Waypoint26").transform;
		wayPoint [27] = GameObject.Find ("Waypoint27").transform;
		wayPoint [28] = GameObject.Find ("Waypoint28").transform;
		wayPoint [29] = GameObject.Find ("Waypoint29").transform;
		wayPoint [30] = GameObject.Find ("Waypoint30").transform;
		wayPoint [31] = GameObject.Find ("Waypoint31").transform;
		wayPoint [32] = GameObject.Find ("Waypoint32").transform;
		wayPoint [33] = GameObject.Find ("Waypoint33").transform;
		wayPoint [34] = GameObject.Find ("Waypoint34").transform;
		wayPoint [35] = GameObject.Find ("Waypoint35").transform;
		wayPoint [36] = GameObject.Find ("Waypoint36").transform;
		wayPoint [37] = GameObject.Find ("Waypoint37").transform;
		wayPoint [38] = GameObject.Find ("Waypoint38").transform;
		wayPoint [39] = GameObject.Find ("Waypoint39").transform;
		wayPoint [40] = GameObject.Find ("Waypoint40").transform;
		wayPoint [41] = GameObject.Find ("Waypoint41").transform;
		wayPoint [42] = GameObject.Find ("Waypoint42").transform;
		wayPoint [43] = GameObject.Find ("Waypoint43").transform;
		wayPoint [44] = GameObject.Find ("Waypoint44").transform;
		wayPoint [45] = GameObject.Find ("Waypoint45").transform;
		wayPoint [46] = GameObject.Find ("Waypoint46").transform;
		wayPoint [47] = GameObject.Find ("Waypoint47").transform;
		wayPoint [48] = GameObject.Find ("Waypoint48").transform;
		wayPoint [49] = GameObject.Find ("Waypoint49").transform;
		wayPoint [50] = GameObject.Find ("Waypoint50").transform;
		wayPoint [51] = GameObject.Find ("Waypoint51").transform;
		wayPoint [52] = GameObject.Find ("Waypoint52").transform;
		wayPoint [53] = GameObject.Find ("Waypoint53").transform;
		wayPoint [54] = GameObject.Find ("Waypoint54").transform;
		wayPoint [55] = GameObject.Find ("Waypoint55").transform;
		wayPoint [56] = GameObject.Find ("Waypoint56").transform;
		wayPoint [57] = GameObject.Find ("Waypoint57").transform;
		wayPoint [58] = GameObject.Find ("Waypoint58").transform;
		wayPoint [59] = GameObject.Find ("Waypoint59").transform;
		wayPoint [60] = GameObject.Find ("Waypoint60").transform;
		wayPoint [61] = GameObject.Find ("Waypoint61").transform;
		wayPoint [62] = GameObject.Find ("Waypoint62").transform;
		wayPoint [63] = GameObject.Find ("Waypoint63").transform;
		wayPoint [64] = GameObject.Find ("Waypoint64").transform;
		wayPoint [65] = GameObject.Find ("Waypoint65").transform;
		wayPoint [66] = GameObject.Find ("Waypoint66").transform;
		wayPoint [67] = GameObject.Find ("Waypoint67").transform;
		wayPoint [68] = GameObject.Find ("Waypoint68").transform;
		wayPoint [69] = GameObject.Find ("Waypoint69").transform;
		wayPoint [70] = GameObject.Find ("Waypoint70").transform;
		wayPoint [71] = GameObject.Find ("Waypoint71").transform;
		wayPoint [72] = GameObject.Find ("Waypoint72").transform;
		wayPoint [73] = GameObject.Find ("Waypoint73").transform;
		wayPoint [74] = GameObject.Find ("Waypoint74").transform;
		wayPoint [75] = GameObject.Find ("Waypoint75").transform;
		wayPoint [76] = GameObject.Find ("Waypoint76").transform;
		wayPoint [77] = GameObject.Find ("Waypoint77").transform;
		wayPoint [78] = GameObject.Find ("Waypoint78").transform;
		wayPoint [79] = GameObject.Find ("Waypoint79").transform;
		wayPoint [80] = GameObject.Find ("Waypoint80").transform;
		wayPoint [81] = GameObject.Find ("Waypoint81").transform;
		wayPoint [82] = GameObject.Find ("Waypoint82").transform;
		wayPoint [83] = GameObject.Find ("Waypoint83").transform;
		wayPoint [84] = GameObject.Find ("Waypoint84").transform;
		wayPoint [85] = GameObject.Find ("Waypoint85").transform;
		wayPoint [86] = GameObject.Find ("Waypoint86").transform;
		wayPoint [87] = GameObject.Find ("Waypoint87").transform;
		wayPoint [88] = GameObject.Find ("Waypoint88").transform;
		wayPoint [89] = GameObject.Find ("Waypoint89").transform;
		wayPoint [90] = GameObject.Find ("Waypoint90").transform;
		wayPoint [91] = GameObject.Find ("Waypoint91").transform;
		wayPoint [92] = GameObject.Find ("Waypoint92").transform;
		wayPoint [93] = GameObject.Find ("Waypoint93").transform;
		wayPoint [94] = GameObject.Find ("Waypoint94").transform;
		wayPoint [95] = GameObject.Find ("Waypoint95").transform;
		wayPoint [96] = GameObject.Find ("Waypoint96").transform;
		wayPoint [97] = GameObject.Find ("Waypoint97").transform;
		wayPoint [98] = GameObject.Find ("Waypoint98").transform;

	}
	
	// Update is called once per frame
	void Update () {
		//when reached the last waypoint
		if (currentWaypoints == 99) {
			Application.Quit();		
		} 
		else {
			walk ();
		}
	}

	//make camera move
	void walk(){
		//facing direction
		//make camera look at the next waypoint
		Quaternion rotation = Quaternion.LookRotation(wayPoint[currentWaypoints].position - transform.position);
		//control fast rotate
		transform.rotation = Quaternion.Slerp (transform.rotation, rotation, Time.deltaTime * rotationSpeed);

		//movement
		Vector3 wayPointDirection = wayPoint[currentWaypoints].position - transform.position;
		float speedElement = Vector3.Dot (wayPointDirection.normalized, transform.forward);
		float speed = accel * speedElement * 2;
		transform.Translate (0, 0, Time.deltaTime * speed);
	}

	//Use collider to trigger cam to the next waypoint
	void OnTriggerEnter(Collider collider){

		if (collider.tag == "Waypoints")
			currentWaypoints++;
	}
}
