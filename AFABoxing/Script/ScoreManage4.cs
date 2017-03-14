using UnityEngine;
using System.Collections;

public class ScoreManage4 : MonoBehaviour {

	public static int score4;
	public TextMesh Achiv;
	public TextMesh text;
	

	// Use this for initialization
	void Start () {
	
	}

	void Awake (){
		text = GetComponent<TextMesh>();
		score4 = 0;
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Score : " + score4.ToString();
		if (score4 >= 25000) {
			StartCoroutine(wait());
		}

	}

	public IEnumerator wait() {
		Achiv.text = "Congratulation, You Unlock New Item";
		yield return new WaitForSeconds(3f); // waits 3 seconds
		Destroy (Achiv);
	}

}
