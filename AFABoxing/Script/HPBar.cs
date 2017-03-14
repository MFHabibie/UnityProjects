using UnityEngine;
using System.Collections;

public class HPBar : MonoBehaviour {
	 
	public bool _isPlayerHealthBar; //this boolean value tells us if this is the player healthbar 

	public int _maxBarLength;

	public float _curBarLength;
	public static int curHealth = 100;
	public int maxHealth = 100;

	public GameObject AI;

	private GUITexture _display;
	// Use this for initialization
	void Start () {
		_isPlayerHealthBar = true;
		_display = gameObject.GetComponent<GUITexture> ();
		_maxBarLength = (int)_display.pixelInset.height;
		OnEnable ();
	}
	
	// Update is called once per frame
	void Update () {
		Debug.Log (_curBarLength);
		if(curHealth<=0){
			Destroy(AI);
		}
		ChangeHPBarSize ();
	}
	
	public void OnEnable(){
	
	}

	public void OnDisable(){

	}

	public void ChangeHPBarSize () {
		_curBarLength = ((float)curHealth / (float)maxHealth) * _maxBarLength;
		_display.pixelInset = new Rect(_display.pixelInset.x, _display.pixelInset.y, _display.pixelInset.width,_curBarLength);
	}

	public void SetPlayerHealth(bool b) {
		_isPlayerHealthBar = b;
	}
}

	