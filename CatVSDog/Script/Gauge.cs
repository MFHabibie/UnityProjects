using UnityEngine;
using System.Collections;

public class Gauge : MonoBehaviour {

	float timer;
	public bool turnActive;

	// Use this for initialization
	void Start () {
		timer = 4.0f;
	}
	
	// Update is called once per frame
	void Update () {
		if (turnActive) {
			timer -= Time.deltaTime;
			if (timer > 0.0f) {
				transform.localScale = new Vector2 (transform.localScale.x, transform.localScale.y - 0.05f);
				if (transform.localScale.y < 0.1f) {
					timer = 0.0f;
				}
			}
			else {
				transform.localScale = new Vector2 (transform.localScale.x, transform.localScale.y + 0.05f);
				if (transform.localScale.y > 5.5f) {
					timer = 4.0f;
				}
			}
		} 
		else {
			FishBone.speed = (transform.localScale.y / 5.5f) * 10.0f;
			Bone.speed = (transform.localScale.y / 5.5f) * 10.0f;
		}
	}
}
