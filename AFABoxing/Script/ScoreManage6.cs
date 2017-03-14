using UnityEngine;
using System.Collections;

public class ScoreManage6 : MonoBehaviour {

	public static int score6;
	public TextMesh text;
	public TextMesh text2;

	// Use this for initialization
	void Start () {
	
	}

	void Awake (){
		text = GetComponent<TextMesh>();
		score6 = 0;
	}
	
	// Update is called once per frame
	void Update () {
		text.text = "Score : " + score6.ToString();
		if (score6 >= 25000) {
			StartCoroutine(wait());
		}

	}

	public IEnumerator wait() {
		text2.text = "Congratulation, You have Mastered Skill";
		yield return new WaitForSeconds(3f); // waits 3 seconds
		Destroy(text2); // will make the update method pick up 
	}
}
