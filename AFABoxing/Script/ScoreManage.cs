using UnityEngine;
using System.Collections;

public class ScoreManage : MonoBehaviour {

	public static int score;
	public TextMesh Achiv;
	public TextMesh scortext;
	

	// Use this for initialization
	void Start () {
	
	}

	void Awake (){
		scortext = GetComponent<TextMesh>();
		score = 0;
	}
	
	// Update is called once per frame, membaca proses per frame
	void Update () {
		scortext.text = "Score : " + score.ToString();
		if (score >= 10000) {
			StartCoroutine(wait());
		}

	}

	public IEnumerator wait() {
		Achiv.text = "Congratulation, You Unlock New Item";
		yield return new WaitForSeconds(3.0f); // waits 3 seconds
		Destroy (Achiv); // will make the update method pick up 
	}

}
