using UnityEngine;
using System.Collections;

public class ScoreManage3 : MonoBehaviour {

	public static int score3;
	public TextMesh text;
	public TextMesh Achiv;

	// Use this for initialization
	void Start () {
	
	}

	void Awake (){
		text = GetComponent<TextMesh>();
		score3 = 0;
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Score : " + score3.ToString();
		if (score3 >= 20000) {
			StartCoroutine(wait());
		}

	}

	public IEnumerator wait() {
		Achiv.text = "Congratulation, You Achieve New Place";
		yield return new WaitForSeconds(3f); // waits 3 seconds
		Destroy(Achiv); // will make the update method pick up 
	}
}
