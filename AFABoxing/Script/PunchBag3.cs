using UnityEngine;
using System.Collections;

[RequireComponent(typeof(AudioSource))]
public class PunchBag3 : MonoBehaviour {

	RaycastHit hit;
	Vector3 maxVelocity;
	public int ScoreValue;
	private HandController handController;
	public AudioClip sound;
	float x;
	float y;
	float z;
	Vector3 pos;
	public float timer = 0.0f;
	
	void Update()
	{
		timer += Time.deltaTime;//
		if (timer % 5.0f == 0.0f){  //
			x = 0.0f;
			y = Random.Range(0.0f, 26.0f);
			z = -4.655249f;
			pos = new Vector3(x, y, z);
			transform.position = pos;  //
		} //

		if (Input.GetMouseButton(0))
		{
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (Physics.Raycast(ray, out hit))
			{
				if (hit.collider.gameObject == gameObject) {
					//GetComponent<Rigidbody>().AddForceAtPosition(maxVelocity * 200, gameObject.transform.position);
					GetComponent<AudioSource>().Play();
					ScoreManage3.score3 += ScoreValue;
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
		RigidHand leapObj = collision.gameObject.GetComponent<RigidHand>();
		
		/*if (leapObj)
		{
			Debug.Log(leapObj.maxVelocity.magnitude);
			rigidbody.AddForceAtPosition(leapObj.maxVelocity * 200, leapObj.transform.position);

		}
		GetComponent<AudioSource>().Play();
		ScoreManage3.score3 += ScoreValue;
		//sound.playOneShot ();
	}*/


}
