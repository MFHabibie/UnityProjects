using UnityEngine;
using System.Collections;

public class CatPlayer : MonoBehaviour {

	public GameObject catGauge;
	public GameObject fishBone;
	public GameObject healthbar;

	public bool catTurn;
	public float health;

	float xScale;
	float yScale;

	// Use this for initialization
	void Start () {
		health = 150.0f;
		xScale = 9.353574f;
		yScale = 1.558928f;
		gameObject.GetComponent<Animator> ().SetFloat ("Health", health);
	}
	
	// Update is called once per frame
	void Update () {
		if (catTurn) {
			catGauge.GetComponent<Gauge> ().turnActive = true;
			if (Input.GetKeyDown (KeyCode.Space)) {
				catGauge.GetComponent<Gauge> ().turnActive = false;
				Instantiate (fishBone, transform.position, transform.rotation);
				GameManager.turn++;
			}
		}
	}

	void OnCollisionEnter2D(Collision2D coll){
		if (coll.gameObject.tag == "Bone") {
			gameObject.GetComponent<Animator> ().SetTrigger ("GetHit");
			health = health - 25;
			xScale = (health / 150.0f) * xScale;
			healthbar.transform.localScale = new Vector2 (xScale, yScale);
			gameObject.GetComponent<Animator> ().SetFloat ("Health", health);
		}
	}
}
