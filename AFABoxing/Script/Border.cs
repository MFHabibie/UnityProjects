using UnityEngine;
using System.Collections;

public class Border : MonoBehaviour {

	private HandController handController;
	public GameObject sholLeft;
	public GameObject armLeft;
	public BoxCollider bord;
	/*public GameObject sholRight;
	public GameObject armRight;
	*/

	public float Speed;

	// Use this for initialization
	void Start(){
		GameObject gameControllerObject = GameObject.FindWithTag ("HandControl");
		if (gameControllerObject != null) {
			handController = gameControllerObject.GetComponent <HandController>();
		}
	}
	
	public void OnCollisionEnter(Collision collision)
	{
		RigidHand leapObj = collision.gameObject.GetComponent<RigidHand>();
		
		/*if (leapObj)
		{
			Debug.Log(leapObj.maxVelocity.magnitude);
			rigidbody.AddForceAtPosition(leapObj.maxVelocity * 200, leapObj.transform.position);

		}*/
		
		//sound.playOneShot ();
		/*sholLeft.transform.Rotate (2.871f, 251.918f, 28.719f);
		armLeft.transform.Rotate (341.354f, -47.751f, 13.842f);
		sholRight.transform.Rotate (372.110f, 250.003f, 332.455f);
		armRight.transform.Rotate (349.682f, -41.338f, 278.945f);
		*/
		armLeft.transform.Rotate (18.0f, 8.0f, 50.0f);

		//StartCoroutine (Stop ());
		Destroy (bord);
	}


	// Update is called once per frame
	void Update () {
		/*StartCoroutine (Stop ());
		sholRight.transform.Rotate (Vector3.up);
		armRight.transform.Rotate (Vector3.forward);*/
	}

	IEnumerator Stop(){

		yield return new WaitForSeconds(2);
		armLeft.transform.Rotate (-18.0f, -8.0f, -50.0f);
	}

}
