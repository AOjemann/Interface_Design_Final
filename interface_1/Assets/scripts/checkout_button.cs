using UnityEngine;
using System.Collections;

public class checkout_button : MonoBehaviour {

	Buttons buttonScriptTMP;

	int correctCount;
	public int correctTillNextLevel;

	// Use this for initialization
	void Start () {

		buttonScriptTMP = GameObject.FindWithTag ("buttons").GetComponent <Buttons> ();
		correctCount = 0;
	
	}
	
	// Update is called once per frame
	void Update () {

		//FOR TESTING PURPOSES ONLY ****REMOVE ME*****
		if (Input.GetButtonDown ("Fire1")) {
			checkout_button_compair();
				}
	}

	//BUTTON CALLS: this function
	void checkout_button_compair (){
		GameObject tmpPlayer;
		tmpPlayer = GameObject.FindWithTag ("Player");
		salad_randomizer tmpSalRand = tmpPlayer.GetComponent<salad_randomizer> ();
		salad_compair sal_comp_tmp = tmpPlayer.GetComponent<salad_compair> ();
		bool winTmp = sal_comp_tmp.compair_sal ();
		if (winTmp) {
			print("Correct");
			buttonScriptTMP.locTimerO = 2;
			buttonScriptTMP.tempO = true;
			correctCount = correctCount + 1;
			buttonScriptTMP.reset();
			tmpSalRand.setRandomSaladFromBook();
			if (correctCount >= correctTillNextLevel){
				buttonScriptTMP.winLevel();
				buttonScriptTMP.checkOutCorrectGUI();
				tmpSalRand.setRandomSaladFromBook();
					}
				}
		if (!winTmp){
			print ("Not Correct, -10sec");
			buttonScriptTMP.timeReduce();
			buttonScriptTMP.checkOutIncorrectGUI();
			buttonScriptTMP.locTimerX = 2;
			buttonScriptTMP.tempX = true;
		}
	}


}
