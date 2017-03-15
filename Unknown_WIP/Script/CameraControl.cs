using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {

	public GameObject player;
	public static bool enemyAppear;
	public static bool targeting;
	Vector3 targetPosition;

	// Use this for initialization
	void Start () {
		enemyAppear = false;

		if (Application.loadedLevel == 2) {
			targeting = false;
		} 
		else {
			targeting = true;
		}
	}
	
	// Update is called once per frame
	void Update () {
		if (targeting) {
			targetPosition = new Vector3 (player.transform.position.x + 2.0f, player.transform.position.y + 0.5f, -5.0f);
			transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 0.95f);
		}

		if (enemyAppear) {
			gameObject.GetComponent<Animator> ().SetBool ("EnemyCome", true);
			enemyAppear = false;
		}
			
	}

	public void changeAnimation(int state){
		if (state == 1) {
			gameObject.GetComponent<Animator> ().SetBool ("Targeting", true);
		} 
		else if (state == 2) {
			PlayerController.moveActive = true;
			targeting = true;
			gameObject.GetComponent<Animator> ().Stop ();
		}
	}
}
