using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class creditScript : MonoBehaviour {

	public Sprite[] creditsImage;

	Image[] source;

	int next;
	int delay;
	int indxPict;

	// Use this for initialization
	void Start () {
		next = 120;
		delay = 0;
		indxPict = 0;

		source = gameObject.GetComponentsInChildren<Image> ();

		foreach (Image image in source) {
			image.sprite = creditsImage[indxPict];
		}
	}
	
	// Update is called once per frame
	void Update () {
		delay++;

		source = gameObject.GetComponentsInChildren<Image> ();

		if (delay > next) {
			indxPict++;
			if (indxPict > 4) {
				Application.LoadLevel (0);
			}
			foreach (Image image in source) {
				image.sprite = creditsImage [indxPict];
			}
			delay = 0;
		}
	}
}
