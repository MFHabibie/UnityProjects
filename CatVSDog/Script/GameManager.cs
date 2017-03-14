using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour {

	public GameObject dog;
	public GameObject cat;

	public static int turn;

	// Use this for initialization
	void Start () {
		cat.GetComponent<CatPlayer> ().catTurn = true;
		dog.GetComponent<DogPlayer> ().dogTurn = false;
		turn = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (turn % 2 == 0) {
			dog.GetComponent<DogPlayer> ().dogTurn = false;
			cat.GetComponent<CatPlayer> ().catTurn = true;
		} 
		else {
			dog.GetComponent<DogPlayer> ().dogTurn = true;
			cat.GetComponent<CatPlayer> ().catTurn = false;
		}
	}
}
