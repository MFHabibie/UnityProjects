using UnityEngine;
using System.Collections;

public class helpScript : MonoBehaviour {

	public Animator helpAnim;

	float wait;
	float stopWait;

	// Use this for initialization
	void Start () {
		helpAnim.SetInteger ("Step", 0);

		wait = 0.0f;
		stopWait = 75.0f;
	}

	// Update is called once per frame
	void Update () {
		wait++;

		if (wait > stopWait) {
			helpAnim.SetInteger ("Step", 1);
			if (blockMove.blockDrag) {
				helpAnim.SetInteger ("Step", 2);
			}
			if (pallete.stsBlockIn) {
				helpAnim.SetInteger ("Step", 3);
				if(compilerScript.codeReaderActive){
					helpAnim.SetInteger ("Step", 4);
				}
			}
		}
	}


}
