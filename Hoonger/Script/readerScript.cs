using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class readerScript : MonoBehaviour {

	public GameObject Human;
	public GameObject moveBlock;
	public GameObject jumpBlock;
	public GameObject crawlBlock;
	public Animator completePanel;

	int indexScene;

	bool read;
	int sumBlockMove;
	int sumBlockJump;
	int sumBlockCrawl;
	public static bool statusRead;
	public static float wait;
	public static float stopWait;
	float delayTime;

	// Use this for initialization
	void Start () {
		statusRead = false;
		read = false;

		sumBlockMove = 0;
		sumBlockJump = 0;
		sumBlockCrawl = 0;

		wait = 0.0f;
		stopWait = 75.0f;
		delayTime = stopWait + 10.0f;

		indexScene = SceneManager.GetActiveScene().buildIndex;
	}
	
	// Update is called once per frame
	void Update () {
		delayTime = stopWait + 1.0f;

		if (indexScene == 2 || indexScene == 9) {
			if (meat.eat && Time.time > delayTime) {
				completePanel.SetBool ("isDisplayed", true);
				if (sumBlockMove == 1) {
					completePanel.SetInteger ("Stars", 3);
				} 
				else if (sumBlockMove == 2) {
					completePanel.SetInteger ("Stars", 2);
				} 
				else {
					completePanel.SetInteger ("Stars", 1);
				}
			} 
			else if (Time.time > delayTime) {
				completePanel.SetBool ("isDisplayed", true);
				completePanel.SetInteger ("Stars", 0);
			}
		}
		else if (indexScene == 3) {
			if (meat.eat && Time.time > delayTime) {
				completePanel.SetBool ("isDisplayed", true);
				if (sumBlockMove == 1) {
					if (sumBlockJump == 1) {
						completePanel.SetInteger ("Stars", 3);
					} 
					else {
						completePanel.SetInteger ("Stars", 2);	
					}
				}
				else {
					completePanel.SetInteger ("Stars", 1);
				}
			} 
			else if (Time.time > delayTime) {
				completePanel.SetBool ("isDisplayed", true);
				completePanel.SetInteger ("Stars", 0);
			}
		}
		else if (indexScene == 4) {
			if (meat.eat && Time.time > delayTime) {
				completePanel.SetBool ("isDisplayed", true);
				if (sumBlockMove == 1 && pallete.indBlock == 1 || sumBlockMove == 2 && pallete.indBlock == 1) {
					if (sumBlockJump == 3) {
						completePanel.SetInteger ("Stars", 3);
					} 
					else {
						completePanel.SetInteger ("Stars", 2);	
					}
				} 
				else {
					completePanel.SetInteger ("Stars", 1);
				}
			} 
			else if (Time.time > delayTime) {
				completePanel.SetBool ("isDisplayed", true);
				completePanel.SetInteger ("Stars", 0);
			}
		}
		else if (indexScene == 5) {
			if (meat.eat && Time.time > delayTime) {
				completePanel.SetBool ("isDisplayed", true);

				if (sumBlockMove == 1 && pallete.indBlock == 1  || sumBlockMove == 2 && pallete.indBlock == 1) {
					if (sumBlockCrawl == 2) {
						completePanel.SetInteger ("Stars", 3);
					} 
					else {
						completePanel.SetInteger ("Stars", 2);	
					}
				} 
				else {
					completePanel.SetInteger ("Stars", 1);
				}
			} 
			else if (Time.time > delayTime) {
				completePanel.SetBool ("isDisplayed", true);
				completePanel.SetInteger ("Stars", 0);
			}
		}
		else {
			if (meat.eat && Time.time > delayTime) {
				completePanel.SetBool ("isDisplayed", true);
				if (sumBlockJump == 3 && pallete.indBlock == 2) {
					if (sumBlockCrawl == 1) {
						completePanel.SetInteger ("Stars", 3);
					} 
					else {
						completePanel.SetInteger ("Stars", 2);
					}
				} 
				else {
					completePanel.SetInteger ("Stars", 1);
				}
			} 
			else if (Time.time > delayTime) {
				completePanel.SetBool ("isDisplayed", true);
				completePanel.SetInteger ("Stars", 0);
			}
		}
	}

	void OnTriggerStay(Collider col){
		if (col.gameObject.tag == "BlockMove") {
			if (!statusRead) {
				if (!read) {
					Human.GetComponent<charac> ().charMove ();
					read = true;
					sumBlockMove++;

					stopWait = Time.time + 2.0f;
				}
					
				Jalan ();

				if (Time.time > stopWait) {
					read = false;

					Human.GetComponent<charac> ().charIdle ();

					statusRead = true;
				}
			}
		}

		if (col.gameObject.tag == "BlockJump") {
			if (!statusRead) {
				if (!read) {
					Human.GetComponent<charac> ().charJump ();
					read = true;
					sumBlockJump++;

					stopWait = Time.time + 0.7f;
				}

				Loncat ();

				if (Time.time > stopWait) {
					read = false;

					Human.GetComponent<charac> ().charIdle ();

					statusRead = true;
				}
			}
		}

		if (col.gameObject.tag == "BlockCrawl") {
			if (!statusRead) {
				if (!read) {
					Human.GetComponent<charac> ().charGetdown ();
					Human.GetComponent<charac> ().charCrawl ();
					read = true;
					sumBlockCrawl++;

					stopWait = Time.time + 2.0f;
				}

				Tiarap ();

				if (Time.time > stopWait) {
					read = false;

					crawlBlock.GetComponent<blockCrawl> ().charBangun ();
					Human.GetComponent<charac> ().charGetup ();
					Human.GetComponent<charac> ().charIdle ();

					statusRead = true;
				}
			}
		}
			
	}

	void Jalan(){
		moveBlock.GetComponent<blockMove> ().charJalan ();
	}

	void Loncat(){
		jumpBlock.GetComponent<blockJump> ().charLoncat ();
	}

	void Tiarap(){
		crawlBlock.GetComponent<blockCrawl> ().charTiarap ();
	}

}
