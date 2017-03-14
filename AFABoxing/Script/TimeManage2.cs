using UnityEngine;
using System.Collections;

public class TimeManage2 : MonoBehaviour {
	
	public TextMesh waktu;
	//public TextMesh lose;
	public TextMesh coba;
	public TextMesh keluar;
	public Light lampu;
	//public BoxCollider tried;
	//public BoxCollider exet;
	public BoxCollider bag;
	public BoxCollider tried;
	public BoxCollider exet;


	public float timer = 60.0f;

	// Use this for initialization
	void Start () {
		tried.GetComponent<Collider>().enabled = false;
		exet.GetComponent<Collider>().enabled = false;
	}

	void Awake (){
		waktu = GetComponent<TextMesh>();
	}
	
	// Update is called once per frame
	void Update () {
		waktu.text = "Time : " + timer.ToString ("F3");//
		timer -= Time.deltaTime;//
		if (timer <= 0){  //
			timer=0;  //
		} //
		if (ScoreManage3.score3<=20000 && timer == 0.0f) {
			bag.size = new Vector3(0,0,0);
			//tried.size = new Vector3(5.670001f,1.5375f,0.3f);
			//exet.size = new Vector3(5.670001f,1.5375f,0.3f);
			lampu.intensity = 0.0f;
			//StartCoroutine(info());
			coba.text = "Try Again";
			keluar.text = "Exit";
		}
		if (timer == 0.0f) {
			tried.GetComponent<Collider>().enabled = true;
			exet.GetComponent<Collider>().enabled = true;
		}
	}

	//public IEnumerator info() {
		//lose.text = "You Lose";
		//yield return new WaitForSeconds(3f); // waits 3 seconds
		//lose.text = ""; // will make the update method pick up 
	//}

}
