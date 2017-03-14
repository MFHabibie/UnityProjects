using UnityEngine;
using System.Collections;

public class EventTrigger : MonoBehaviour {

	public void ChangeScene(int scene){
		Application.LoadLevel (scene);
	}

	public void ExitGame(){
		Application.Quit ();
	}
}
