using UnityEngine;
using System.Collections;

public class salad_compair : MonoBehaviour {

	//stored elements of the two salads being compaired
	//ex is for example, play is for player made
	int ex_topNum;
	string ex_base;
	string ex_prot;
	string ex_dress;
	string ex_top1;
	string ex_top2;
	string ex_top3;

	int play_topNum;
	string play_base;
	string play_prot;
	string play_dress;
	string play_top1;
	string play_top2;
	string play_top3;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	////get elements of bolth salads to be compaired
	//object always has 2 salad strucs, first is always the example and second is the player

	public void get_2salads(){
		salad_struc[] saladArray = this.GetComponents<salad_struc> ();
		salad_struc ex_sal_tmp = saladArray [0];
		salad_struc play_sal_tmp = saladArray [1];
		extract_sal (ex_sal_tmp, 0);
		extract_sal (play_sal_tmp, 1);
	}

	//placer 0 stands for exaple, placer 1 stands for player
	void extract_sal (salad_struc tmpSal, int placer){

		int tmp_topNum = tmpSal.get_topNum();
		string tmp_base = tmpSal.get_base();
		string tmp_prot = tmpSal.get_prot();
		string tmp_dress = tmpSal.get_dress();
		string tmp_top1 = tmpSal.get_top1();
		string tmp_top2 = tmpSal.get_top2();
		string tmp_top3 = tmpSal.get_top3();

		if (placer == 0) {
			ex_top1 = tmp_top1;
			ex_top2 = tmp_top2;
			ex_top3 = tmp_top3;
			ex_topNum = tmp_topNum;
			ex_base = tmp_base;
			ex_prot = tmp_prot;
			ex_dress = tmp_dress;

				}

		if (placer == 1) {
			play_top1 = tmp_top1;
			play_top2 = tmp_top2;
			play_top3 = tmp_top3;
			play_topNum = tmp_topNum;
			play_base = tmp_base;
			play_prot = tmp_prot;
			play_dress = tmp_dress;
			
		}
	
	}

	////compair elements of both salads and return a boolean, true if the same salad
	//
	public bool compair_sal(){
		//gets the current salads
		this.get_2salads();

		//if all elements of salad are the same return true, else false
		if (this.compair_base() && this.compair_prot() && this.compair_dress() && this.compair_top()) {
						return true;
				} else {
			return false;		
		}

	}

	bool compair_base(){
		if (ex_base.Equals (play_base)) {
			return true;
				}
		else{ return false; }
	}

	bool compair_prot(){
		if (ex_prot.Equals (play_prot)) {
			return true;
		}
		else{ return false; }
	}

	bool compair_dress(){
		if (ex_dress.Equals (play_dress)) {
			return true;
		}
		else{ return false; }
	}

	//compairs toppings
	//first makes sure all elements of the example are present in the player
	//then makes sure there are no extra elements by making sure the number of both is equal
	bool compair_top(){
		int tmpMistakes = 0;
		if (!ex_top1.Equals("none")){
			if (!player_has_top(ex_top1)){
				tmpMistakes = tmpMistakes + 1;
			}
		}
		if (!ex_top2.Equals("none")){
			if (!player_has_top(ex_top2)){
				tmpMistakes = tmpMistakes + 1;
			}
		}
		if (!ex_top3.Equals("none")){
			if (!player_has_top(ex_top3)){
				tmpMistakes = tmpMistakes + 1;
			}
		}
		if (ex_topNum != play_topNum) {
			tmpMistakes = tmpMistakes + 1;
				}
		//if there are any mistakes return false
		if (tmpMistakes > 0) {
						return false;
				} else {
						return true;
				}

		}

	//takes a topping and sees of its in the players toppings
	bool player_has_top (string tmpTop){
		if (tmpTop.Equals (play_top1)) {
						return true;
				} else if (tmpTop.Equals (play_top2)) {
						return true;
				} else if (tmpTop.Equals (play_top3)) {
						return true;
				} else {
						return false;
				}

		}
	

}
