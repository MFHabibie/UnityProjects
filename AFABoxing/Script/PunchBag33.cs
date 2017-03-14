using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class PunchBag33 : MonoBehaviour {

	RaycastHit hit;
	Vector3 maxVelocity;
	public int ScoreValue;
	private HandController handController;
	public AudioClip sound;


	public float delta;
	public int current;
	public int maksimum;

	void Update()
	{
		delta = (int) Time.fixedTime;
		//delta = Mathf.Round (delta);
		Debug.Log (delta);

		if (delta % 2 == 0 ){  //
		
			transform.position = new Vector3(Random.Range(-4.0f, 4.0f), Random.Range(-2.5f, 2.5f), -0.06329733f);
			//Instantiate(prefab, position, Quaternion.identity) as GameObject;		
		} //

		if (Input.GetMouseButton(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.collider.gameObject == gameObject) {
					//GetComponent<Rigidbody>().AddForceAtPosition(maxVelocity * 200, gameObject.transform.position);
					if(delta % 2 != 0){
						GetComponent<AudioSource>().Play();
						ScoreManage3.score3 += ScoreValue;
					}
				}
			}
			
		}

	}

	void Start(){

		GameObject gameControllerObject = GameObject.FindWithTag ("HandControl");
		if (gameControllerObject != null) {
			handController = gameControllerObject.GetComponent <HandController>();
		}

	}

	/*public void OnCollisionEnter(Collision collision)
	{
				if (delta % 2 != 0) {
						RigidHand leapObj = collision.gameObject.GetComponent<RigidHand> ();
		
						/*if (leapObj)
		{
			Debug.Log(leapObj.maxVelocity.magnitude);
			rigidbody.AddForceAtPosition(leapObj.maxVelocity * 200, leapObj.transform.position);

		}
						GetComponent<AudioSource>().Play ();
						ScoreManage3.score3 += ScoreValue;
						//sound.playOneShot ();
				}

	}*/
	


}
