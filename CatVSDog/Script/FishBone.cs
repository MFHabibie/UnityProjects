using UnityEngine;
using System.Collections;

public class FishBone : MonoBehaviour {

//	public bool throwActive;
	public static float speed;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = Vector2.Lerp (transform.position, new Vector2 (transform.position.x + 1.5f, transform.position.y + 1.5f), speed * Time.deltaTime);
	}

	void OnCollisionEnter2D (Collision2D other){
		if (other.gameObject.tag == "Ground") {
			Destroy (this.gameObject);
		}

		if (other.gameObject.tag == "Dog") {
			Destroy (this.gameObject);
		}
	}
}
