using UnityEngine;
using System.Collections;

public class pallete : MonoBehaviour {

	public GameObject blokMove;
	public GameObject blokJump;
	public GameObject blokCrawl;

	GameObject blockFirst;
	GameObject blockSecond;
	GameObject blockThird;
	GameObject blockFourth;
	GameObject blockFifth;

	GameObject replic0;
	GameObject replic1;
	GameObject replic2;
	GameObject replic3;
	GameObject replic4;

	bool created;
	public static int indBlock;
	public static bool stsBlockIn;

	public Transform[] position;

	bool positActive0;
	bool positActive1;
	bool positActive2;
	bool positActive3;
	bool positActive4;

	// Use this for initialization
	void Start () {
		stsBlockIn = false;

		positActive0 = false;
		positActive1 = false;
		positActive2 = false;
		positActive3 = false;
		positActive4 = false;

		//stsBlockMove = false;
		created = false;
		indBlock = 0;
	}
	
	// Update is called once per frame
	void Update () {
		
		if (positActive0) {
			blockFirst.transform.position = position [0].transform.position;
		} 
		if (positActive1) {
			blockSecond.transform.position = position [1].transform.position;
		}
		if (positActive2){
			blockThird.transform.position = position[2].transform.position;
		} 
		if (positActive3) {
			blockFourth.transform.position = position[3].transform.position;
		}
		if (positActive4) {
			blockFifth.transform.position = position[4].transform.position;
		}

	}

	void OnTriggerEnter(Collider other) {
		if (other.gameObject.tag == "BlockMove") {
			stsBlockIn = true;

			if (!positActive0) {
				blockFirst = blokMove;

				indBlock = 1;

				blockMove.blockActive = true;

				positActive0 = true;
				if (!created) {
					replic0 = GameObject.Instantiate (blokMove, blockMove.startPosition, blokMove.transform.rotation) as GameObject;
					created = true;
				}
			}
			else if (!positActive1) {

				if (replic0.tag == "BlockJump" || replic0.tag == "BlockCrawl") {
					blockSecond = blokMove;
				}
				else {
					blockSecond = replic0;
				}

				created = false;
				blockMove.blockActive = true;

				positActive1 = true;
				if (!created) {
					replic1 = GameObject.Instantiate (blokMove, blockMove.startPosition, blokMove.transform.rotation) as GameObject;
					created = true;
				}
			}
			else if (!positActive2) {

				if (replic0.tag == "BlockJump" || replic0.tag == "BlockCrawl" || replic1.tag == "BlockJump" || replic1.tag == "BlockCrawl") {
					if (replic0.tag == "BlockMove") {
						blockThird = replic0;
					} 
					else if (replic1.tag == "BlockMove") {
						blockThird = replic1;
					}
					else {
						blockThird = blokMove;
					}
				}
				else {
					blockThird = replic1;
				}

				created = false;
				blockMove.blockActive = true;

				positActive2 = true;
				if (!created) {
					replic2 = GameObject.Instantiate (blokMove, blockMove.startPosition, blokMove.transform.rotation) as GameObject;
					created = true;
				}
			}
			else if (!positActive3) {

				if (replic0.tag == "BlockJump" || replic0.tag == "BlockCrawl" || replic1.tag == "BlockJump" || replic1.tag == "BlockCrawl" || replic2.tag == "BlockJump" || replic2.tag == "BlockCrawl") {
					if (replic0.tag == "BlockMove") {
						blockFourth = replic0;
					}  
					else if (replic1.tag == "BlockMove") {
						blockFourth = replic1;
						if (replic2.tag == "BlockMove") {
							blockFourth = replic2;
						}
					}
					else {
						blockFourth = blokMove;
					}
				} 
				else {
					blockFourth = replic2;
				}

				created = false;
				blockMove.blockActive = true;

				positActive3 = true;
				if (!created) {
					replic3 = GameObject.Instantiate (blokMove, blockMove.startPosition, blokMove.transform.rotation) as GameObject;
					created = true;
				}
			}
			else if (!positActive4) {

				if (replic0.tag == "BlockJump" || replic0.tag == "BlockCrawl" || replic1.tag == "BlockJump" || replic1.tag == "BlockCrawl" || replic2.tag == "BlockJump" || replic2.tag == "BlockCrawl" || replic3.tag == "BlockJump" || replic3.tag == "BlockCrawl") {
					if (replic0.tag == "BlockMove") {
						blockFifth = replic0;
					} 
					else if (replic1.tag == "BlockMove") {
						blockFifth = replic1;
					}
					else if (replic2.tag == "BlockMove") {
						blockFifth = replic2;
					}
					else if (replic3.tag == "BlockMove") {
						blockFifth = replic3;
					}
					else {
						blockFifth = blokMove;
					}
				} 
				else {
					blockFifth = replic3;
				}

				created = false;
				blockMove.blockActive = true;

				positActive4 = true;
				if (!created) {
					replic4 = GameObject.Instantiate (blokMove, blockMove.startPosition, blokMove.transform.rotation) as GameObject;
					created = true;
				}
			}
			 
		}

		else if (other.gameObject.tag == "BlockJump") {

			if (!positActive0) {
				blockFirst = blokJump;

				indBlock = 2;

				blockJump.blockActive = true;

				positActive0 = true;
				if (!created) {
					replic0 = GameObject.Instantiate (blokJump, blockJump.startPosition, blokJump.transform.rotation) as GameObject;
					created = true;
				}
			}
			else if (!positActive1) {

				if (replic0.tag == "BlockMove" || replic0.tag == "BlockCrawl") {
					blockSecond = blokJump;
				}
				else {
					blockSecond = replic0;
				}

				created = false;
				blockJump.blockActive = true;

				positActive1 = true;
				if (!created) {
					replic1 = GameObject.Instantiate (blokJump, blockJump.startPosition, blokJump.transform.rotation) as GameObject;
					created = true;
				}
			}
			else if (!positActive2) {

				if (replic0.tag == "BlockMove" || replic0.tag == "BlockCrawl" || replic1.tag == "BlockMove" || replic1.tag == "BlockCrawl") {
					if (replic0.tag == "BlockJump") {
						blockThird = replic0; 
					}
					else if (replic1.tag == "BlockJump") {
						blockThird = replic1;
					}
					else {
						blockThird = blokJump;
					}
				}
				else {
					blockThird = replic1;
				}

				created = false;
				blockJump.blockActive = true;

				positActive2 = true;
				if (!created) {
					replic2 = GameObject.Instantiate (blokJump, blockJump.startPosition, blokJump.transform.rotation) as GameObject;
					created = true;
				}
			}
			else if (!positActive3) {

				if (replic0.tag == "BlockMove" || replic0.tag == "BlockCrawl" || replic1.tag == "BlockMove" || replic1.tag == "BlockCrawl" || replic2.tag == "BlockMove" || replic2.tag == "BlockCrawl") {
//					if (replic0.tag == "BlockJump") {
//						blockFourth = replic0;
//					}
					if (replic1.tag == "BlockJump") {
						blockFourth = replic1;
						if (replic2.tag == "BlockJump") {
							blockFourth = replic2;
						}
					}
					else {
						blockFourth = blokJump;
					}
				} 
				else {
					blockFourth = replic2;
				}

				created = false;
				blockJump.blockActive = true;

				positActive3 = true;
				if (!created) {
					replic3 = GameObject.Instantiate (blokJump, blockJump.startPosition, blokJump.transform.rotation) as GameObject;
					created = true;
				}
			}
			else if (!positActive4) {

				if (replic0.tag == "BlockMove" || replic0.tag == "BlockCrawl" || replic1.tag == "BlockMove" || replic1.tag == "BlockCrawl" || replic2.tag == "BlockMove" || replic2.tag == "BlockCrawl" || replic3.tag == "BlockMove" || replic3.tag == "BlockCrawl") {
					if (replic0.tag == "BlockJump") {
						blockFifth = replic0;
					} 
					else if (replic1.tag == "BlockJump") {
						blockFifth = replic1;
					}
					else if (replic2.tag == "BlockJump") {
						blockFifth = replic2;
					} 
					else if (replic3.tag == "BlockJump") {
						blockFifth = replic3;
					}
					else {
						blockFifth = blokJump;
					}
				} 
				else {
					blockFifth = replic3;
				}

				created = false;
				blockJump.blockActive = true;

				positActive4 = true;
				if (!created) {
					replic4 = GameObject.Instantiate (blokJump, blockJump.startPosition, blokJump.transform.rotation) as GameObject;
					created = true;
				}
			}

		}

		else if (other.gameObject.tag == "BlockCrawl") {

			if (!positActive0) {
				blockFirst = blokCrawl;

				blockCrawl.blockActive = true;

				indBlock = 3;

				positActive0 = true;
				if (!created) {
					replic0 = GameObject.Instantiate (blokCrawl, blockCrawl.startPosition, blokCrawl.transform.rotation) as GameObject;
					created = true;
				}
			}
			else if (!positActive1) {

				if (replic0.tag == "BlockMove" || replic0.tag == "BlockJump") {
					blockSecond = blokCrawl;
				}
				else {
					blockSecond = replic0;
				}

				created = false;
				blockCrawl.blockActive = true;

				positActive1 = true;
				if (!created) {
					replic1 = GameObject.Instantiate (blokCrawl, blockCrawl.startPosition, blokCrawl.transform.rotation) as GameObject;
					created = true;
				}
			}
			else if (!positActive2) {

				if (replic0.tag == "BlockJump" || replic0.tag == "BlockMove" || replic1.tag == "BlockJump" || replic1.tag == "BlockMove") {
					if (replic0.tag == "BlockCrawl") {
						blockThird = replic0;
					} 
					else if (replic1.tag == "BlockCrawl") {
						blockThird = replic1;
					}
					else {
						blockThird = blokCrawl;
					}
				}
				else {
					blockThird = replic1;
				}

				created = false;
				blockCrawl.blockActive = true;

				positActive2 = true;
				if (!created) {
					replic2 = GameObject.Instantiate (blokCrawl, blockCrawl.startPosition, blokCrawl.transform.rotation) as GameObject;
					created = true;
				}
			}
			else if (!positActive3) {

				if (replic0.tag == "BlockMove" || replic0.tag == "BlockJump" || replic1.tag == "BlockMove" || replic1.tag == "BlockJump" || replic2.tag == "BlockMove" || replic2.tag == "BlockJump") {
					if (replic0.tag == "BlockCrawl") {
						blockFourth = replic0;
					}
					else if (replic1.tag == "BlockCrawl") {
						blockFourth = replic1;
						if (replic2.tag == "BlockCrawl") {
							blockFourth = replic2;
						}
					}
					else {
						blockFourth = blokCrawl;
					}
				} 
				else {
					blockFourth = replic2;
				}

				created = false;
				blockCrawl.blockActive = true;

				positActive3 = true;
				if (!created) {
					replic3 = GameObject.Instantiate (blokCrawl, blockCrawl.startPosition, blokCrawl.transform.rotation) as GameObject;
					created = true;
				}
			}
			else if (!positActive4) {

				if (replic0.tag == "BlockMove" || replic0.tag == "BlockJump" || replic1.tag == "BlockMove" || replic1.tag == "BlockJump" || replic2.tag == "BlockMove" || replic2.tag == "BlockJump" || replic3.tag == "BlockMove" || replic3.tag == "BlockJump") {
					if (replic0.tag == "BlockCrawl") {
						blockFifth = replic0;
					} 
					else if (replic1.tag == "BlockCrawl") {
						blockFifth = replic1;
					}
					else if (replic2.tag == "BlockCrawl") {
						blockFifth = replic2;
					}
					else if (replic3.tag == "BlockCrawl") {
						blockFifth = replic3;
					}
					else {
						blockFifth = blokCrawl;
					}
				} 
				else {
					blockFifth = replic3;
				}

				created = false;
				blockCrawl.blockActive = true;

				positActive4 = true;
				if (!created) {
					replic4 = GameObject.Instantiate (blokCrawl, blockCrawl.startPosition, blokCrawl.transform.rotation) as GameObject;
					created = true;
				}
			}

		}
	}

}
