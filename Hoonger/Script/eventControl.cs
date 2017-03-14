using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class eventControl : MonoBehaviour {

	int countLvl;

	public AudioSource click;
	public AudioSource BGM;
	public AudioSource buttonSFX;
	public AudioSource characterSFX;

	public Slider volSliderBGM;
	public Slider volSliderSFX;

	public GameObject muteBGM;
	public GameObject muteSFX;

	bool stateMuteBGM;
	bool stateMuteSFX;

	void Start(){
		countLvl = 1;
		if (muteBGM || muteSFX) {
			if (PlayerPrefs.GetInt ("activatedBGM") == 1) {
				stateMuteBGM = true;
			} else {
				stateMuteBGM = false;
			}

			if (PlayerPrefs.GetInt ("activatedSFX") == 1) {
				stateMuteSFX = true;
			} else {
				stateMuteSFX = false;
			}

			muteBGM.SetActive (stateMuteBGM);
			muteSFX.SetActive (stateMuteSFX);
		}

		volSliderBGM.value = PlayerPrefs.GetFloat ("curVolumeBGM");
		volSliderSFX.value = PlayerPrefs.GetFloat ("curVolumeSFX");

		BGM.volume = PlayerPrefs.GetFloat ("curVolumeBGM");
		buttonSFX.volume = PlayerPrefs.GetFloat ("curVolumeSFX");

		if (characterSFX) {
			characterSFX.volume = PlayerPrefs.GetFloat ("curVolumeSFX");
		}
	}

	public void soundVolumeBGM(){
		BGM.volume = volSliderBGM.value;
		PlayerPrefs.SetFloat ("curVolumeBGM", volSliderBGM.value);
	}

	public void muteBGMSound(){
		muteBGM.SetActive(true);
		PlayerPrefs.SetInt ("activatedBGM", 1);

		volSliderBGM.value = 0;
		PlayerPrefs.SetFloat ("curVolumeBGM", volSliderBGM.value);
	}

	public void activeBGMSound(){
		muteBGM.SetActive(false);
		PlayerPrefs.SetInt ("activatedBGM", 0);

		volSliderBGM.value = 1;
		PlayerPrefs.SetFloat ("curVolumeBGM", volSliderBGM.value);
	}

	public void soundVolumeSFX(){
		buttonSFX.volume = volSliderSFX.value;
		PlayerPrefs.SetFloat ("curVolumeSFX", volSliderSFX.value);
	}

	public void muteSFXSound(){
		muteSFX.SetActive(true);
		PlayerPrefs.SetInt ("activatedSFX", 1);

		buttonSFX.volume = 0;
		volSliderSFX.value = buttonSFX.volume;
		PlayerPrefs.SetFloat ("curVolumeSFX", volSliderSFX.value);
	}

	public void activeSFXSound(){
		muteSFX.SetActive(false);
		PlayerPrefs.SetInt ("activatedSFX", 0);

		buttonSFX.volume = 1;
		volSliderSFX.value = buttonSFX.volume;
		PlayerPrefs.SetFloat ("curVolumeSFX", volSliderSFX.value);
	}

	public void DisableBoolInAnimator(Animator anim){
		click.Play ();
		anim.SetBool ("isDisplayed", false);
	}

	public void EnableBoolInAnimator(Animator anim){
		click.Play ();
		anim.SetBool ("isDisplayed", true);
	}

	public void NavigateTo(int scene){
		click.Play ();
		Application.LoadLevel(scene);
	}

	public void CountLevelPlus(Animator previewLvl){
		click.Play ();
		countLvl++;
		if (countLvl > 5) {
			countLvl = 5;
		}

		previewLvl.SetInteger ("Level", countLvl);
	}

	public void CountLevelMinus(Animator previewLvl){
		click.Play ();
		countLvl--;
		if (countLvl < 1) {
			countLvl = 1;
		}

		previewLvl.SetInteger ("Level", countLvl);
	}

	public void exitGame (){
		click.Play ();
		Application.Quit ();
	}

}
