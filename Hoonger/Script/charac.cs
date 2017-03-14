using UnityEngine;
using System.Collections;

public class charac : MonoBehaviour {

	Vector3 startPst;
	public AudioSource soundAll;
	public AudioClip moveSound;
	public AudioClip jumpSound;
	public AudioClip crawlSound;

	// Use this for initialization
	void Start () {
		startPst = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void charIdle(){
		GetComponent<Animation> ().Play ("Idle");
	}

	public void charMove(){
		GetComponent<Animation> ().Play ("Walk");
		soundAll.clip = moveSound;
		soundAll.loop = true;
		soundAll.Play ();
	}

	public void charJump(){
		GetComponent<Animation> ().Play ("Jump");
		soundAll.clip = jumpSound;
		soundAll.loop = false;
		soundAll.Play ();
	}

	public void charCrawl(){
		GetComponent<Animation> ().Play ("Crough");
		soundAll.clip = crawlSound;
		soundAll.loop = false;
		soundAll.Play ();
	}

	public void charGetup(){
		GetComponent<Animation> ().Play ("Stand");
	}

	public void charGetdown(){
		GetComponent<Animation> ().Play ("Bow");
	}
		
}
