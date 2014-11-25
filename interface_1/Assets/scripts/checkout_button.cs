using UnityEngine;
using System.Collections;

public class checkout_button : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
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
		salad_compair sal_comp_tmp = tmpPlayer.GetComponent<salad_compair> ();
		bool winTmp = sal_comp_tmp.compair_sal ();
		if (winTmp) {
			print("win");
				}
		if (!winTmp){
			print ("NOT win");
		}
	}

}
