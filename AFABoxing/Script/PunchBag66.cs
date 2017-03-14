using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class PunchBag66 : MonoBehaviour {

	RaycastHit hit;
	Vector3 maxVelocity;
	public int ScoreValue;
	private HandController handController;
	public AudioClip sound;

	public float delta;
	public int current;
	public int maksimum;

	void Start(){
		GameObject gameControllerObject = GameObject.FindWithTag ("HandControl");
		if (gameControllerObject != null) {
			handController = gameControllerObject.GetComponent <HandController>();
		}
	}

	void Update()
	{
		delta = (int) Time.fixedTime;
		delta = Mathf.Round (delta);
		Debug.Log (transform.position.x);
		
		if (delta % 2 == 0 ){  //
			
			transform.position = new Vector3(Random.Range(4.0f, 14.0f), Random.Range(8.0f, 11.4f), 1.038615f);
			//Instantiate(prefab, position, Quaternion.identity) as GameObject;		
		} //

		if (Input.GetMouseButton(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.collider.gameObject == gameObject) {
					//GetComponent<Rigidbody>().AddForceAtPosition(maxVelocity * 200, gameObject.transform.position);
					GetComponent<AudioSource>().Play();
					ScoreManage6.score6 += ScoreValue;
				}
			}
			
		}
		
	}

	/*public void OnCollisionEnter(Collision collision)
	{
		RigidHand leapObj = collision.gameObject.GetComponent<RigidHand>();
		
		/*if (leapObj)
		{
			Debug.Log(leapObj.maxVelocity.magnitude);
			rigidbody.AddForceAtPosition(leapObj.maxVelocity * 200, leapObj.transform.position);

		}
		GetComponent<AudioSource>().Play();
		ScoreManage6.score6 += ScoreValue;
		//sound.playOneShot ();
	}*/


}
