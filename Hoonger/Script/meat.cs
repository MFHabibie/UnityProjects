using UnityEngine;
using System.Collections;

public class meat : MonoBehaviour {

	public ParticleSystem particle;

	public static bool eat;

	// Use this for initialization
	void Start () {
		eat = false;
	}
	
	// Update is called once per frame
	void Update () {
		transform.parent.Rotate (Vector3.up, 50*Time.deltaTime);
	}

	void OnCollisionEnter (Collision other){
		Destroy (this.gameObject);
		eat = true;
		particle.Play ();
	}
}
