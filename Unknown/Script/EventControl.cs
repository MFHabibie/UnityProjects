using UnityEngine;
using System.Collections;

public class EventControl : MonoBehaviour {

	public enum ActionScene {changeScene, exitScene}
	public ActionScene actScene;

	RaycastHit hit;
	Ray rayPosition;

	public int scene;

	void Update(){
		if (actScene == ActionScene.changeScene) {
			rayPosition = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (rayPosition, out hit)) {
				if (hit.collider.gameObject == gameObject) {
					if (Input.GetMouseButton (0)) {
						gotoScene (scene);
					}
				}
			}
		} 
		if (actScene == ActionScene.changeScene) {
			rayPosition = Camera.main.ScreenPointToRay (Input.mousePosition);
			if (Physics.Raycast (rayPosition, out hit)) {
				if (hit.collider.gameObject == gameObject) {
					if (Input.GetMouseButton (0)) {
						exitGame();
					}
				}
			}
		} 
	}

	void gotoScene(int indScene){
		Application.LoadLevel (indScene);
	}

	void exitGame(){
		Application.Quit ();
	}
}
