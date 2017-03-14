using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class PunchBag : MonoBehaviour {

	RaycastHit hit;
	public int ScoreValue;
	private HandController handController;
	public AudioClip sound;
	Vector3 maxVelocity;

	void Start(){
		GameObject gameControllerObject = GameObject.FindWithTag ("HandControl");
		if (gameControllerObject != null) {
			handController = gameControllerObject.GetComponent <HandController>();
		}
	}

	/*public void OnCollisionEnter(Collision collision)
	{
		RigidHand leapObj = collision.gameObject.GetComponent<RigidHand>();
		
		if (leapObj)
		{
			Debug.Log(leapObj.maxVelocity.magnitude);
			GetComponent<Rigidbody>().AddForceAtPosition(leapObj.maxVelocity * 200, leapObj.transform.position);

		}
		GetComponent<AudioSource>().Play();
		ScoreManage.score += ScoreValue;
		//sound.playOneShot ();
	}*/

	void Update()
	{
		if (Input.GetMouseButton(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.collider.gameObject == gameObject) {
					GetComponent<Rigidbody>().AddForceAtPosition(maxVelocity * 200, gameObject.transform.position);
					GetComponent<AudioSource>().Play();
					ScoreManage.score += ScoreValue;
				}
			}
			
		}

		//sound.playOneShot ();
	}
	

}
