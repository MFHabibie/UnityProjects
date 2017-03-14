using UnityEngine;
using System.Collections;

public class ScoreManage5 : MonoBehaviour {

	public static int score5;
	public TextMesh Achiv;
	public TextMesh text;
	

	// Use this for initialization
	void Start () {
	
	}

	void Awake (){
		text = GetComponent<TextMesh>();
		score5 = 0;
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Score : " + score5.ToString();
		if (score5 >= 25000) {
			StartCoroutine(wait());
		}

	}

	public IEnumerator wait() {
		Achiv.text = "Congratulation, You Unlock New Item";
		yield return new WaitForSeconds(3f); // waits 3 seconds
		Destroy (Achiv);
	}

}
