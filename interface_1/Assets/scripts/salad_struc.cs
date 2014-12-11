using UnityEngine;
using System.Collections;

public class salad_struc : MonoBehaviour {

	//name of this salad
	public string sal_name;

	//base, toppings 3, protien, dressing

	//IF USING NULL: make private use constructor in loading script
	public string sal_base;
	public string sal_top1;
	public string sal_top2;
	public string sal_top3;
	public string sal_top4;
	public string sal_top5;
	public string sal_top6;
	public string sal_top7;
	public string sal_prot;
	public string sal_dress;

	//stores number of topping currently on salad
	public int sal_top_num = 0;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
	
	}

	////add elements to salad

	//add base
	public void add_base(string sBase){
		//if already have base tell player and do nothing
		if (!this.sal_base.Equals("") /*!= null*/) {
				print("salad already has base");
			} 
		//otherwise add the base
		else {
				this.sal_base = sBase;
				print ("base  added");
			}
		}

	//add protien
	public void add_prot(string sProt){
		//if already have protien tell player and do nothing
		if (!this.sal_prot.Equals("") /*!= null*/) {
			print("salad already has protien");
		} 
		//otherwise add the protien
		else {
			this.sal_prot = sProt;
			print ("protien  added");
		}
	}

	//add dressing
	public void add_dress(string sDress){
		//if already have dressing tell player and do nothing
		if (!this.sal_dress.Equals("") /*!= null*/) {
			print("salad already has dressing");
		} 
		//otherwise add the protien
		else {
			this.sal_dress = sDress;
			print ("dressing  added");
		}
	}

	//add topping
	public void add_top(string sTop){
		//if topping 1 is alredy filled move to 2
		if (!sal_top1.Equals("") /*!= null*/) {
			add_top2(sTop);
				} 
		//otherwies add topping to 1
		else {
			sal_top1 = sTop;
			sal_top_num = 1;
			print("1st topping added");
				}
	}

	protected void add_top2(string sTop){
		//if topping 2 is alredy filled move to 3
		if (!sal_top2.Equals("") /*!= null*/) {
			add_top3(sTop);
		} 
		//otherwies add topping to 2
		else {
			sal_top2 = sTop;
			sal_top_num = 2;
			print("2nd topping added");
		}
	}

	protected void add_top3(string sTop){
		//if topping 2 is alredy filled move to 3
		if (!sal_top3.Equals("") /*!= null*/) {
			add_top4(sTop);
		} 
		//otherwies add topping to 2
		else {
			sal_top3 = sTop;
			sal_top_num = 3;
			print("3rd topping added");
		}
	}

	protected void add_top4(string sTop){
		//if topping 2 is alredy filled move to 3
		if (!sal_top4.Equals("") /*!= null*/) {
			add_top5(sTop);
		} 
		//otherwies add topping to 2
		else {
			sal_top4 = sTop;
			sal_top_num = 4;
			print("4th topping added");
		}
	}

	protected void add_top5(string sTop){
		//if topping 2 is alredy filled move to 3
		if (!sal_top5.Equals("") /*!= null*/) {
			add_top6(sTop);
		} 
		//otherwies add topping to 2
		else {
			sal_top5 = sTop;
			sal_top_num = 5;
			print("5th topping added");
		}
	}

	protected void add_top6(string sTop){
		//if topping 2 is alredy filled move to 3
		if (!sal_top6.Equals("") /*!= null*/) {
			add_top7(sTop);
		} 
		//otherwies add topping to 2
		else {
			sal_top6 = sTop;
			sal_top_num = 6;
			print("2nd topping added");
		}
	}

	protected void add_top7(string sTop){
		//if topping 3 is alredy filled inform player and do nothing
		if (!sal_top7.Equals("") /*!= null*/) {
			print ("all toppings filled");
		} 
		//otherwies add topping to 3
		else {
			sal_top7 = sTop;
			sal_top_num = 7;
			print("7th topping added");
		}
	}


	//clear ALL elements from salad
	public void clear_sal(){
		/*this.sal_base = null;
		this.sal_dress = null;
		this.sal_prot = null;
		this.sal_top1 = null;
		this.sal_top2 = null;
		this.sal_top3 = null;*/
		this.sal_base = "";
		this.sal_dress = "";
		this.sal_prot = "";
		this.sal_top1 = "";
		this.sal_top2 = "";
		this.sal_top3 = "";
		this.sal_top4 = "";
		this.sal_top5 = "";
		this.sal_top6 = "";
		this.sal_top7 = "";
		sal_top_num = 0;
		print ("salad cleared");
		}

	//getters
	//comparator makes sure all elements are there that need to be then compairs sizes to make sure no extra exist
	// comparator dose not check none
	public string get_base(){
		//if bese exists return it
		if (sal_base != null) {
						return sal_base;
			//otherwise return none
				} else {
			return "none";
				}
	}

	public string get_dress(){
		//if dressing exists return it
		if (sal_dress != null) {
			return sal_dress;
			//otherwise return none
		} else {
			return "none";
		}
	}

	public string get_prot(){
		//if protien exists return it
		if (sal_prot != null) {
			return sal_prot;
			//otherwise return none
		} else {
			return "none";
		}
	}

	public string get_top1(){
		//if top1 exists return it
		if (sal_top1 != null) {
			return sal_top1;
			//otherwise return none
		} else {
			return "none";
		}
	}

	public string get_top2(){
		//if top2 exists return it
		if (sal_top2 != null) {
			return sal_top2;
			//otherwise return none
		} else {
			return "none";
		}
	}

	public string get_top3(){
		//if top3 exists return it
		if (sal_top3 != null) {
			return sal_top3;
			//otherwise return none
		} else {
			return "none";
		}
	}

	public string get_top4(){
		return sal_top4;
	}
	public string get_top5(){
		return sal_top5;
	}
	public string get_top6(){
		return sal_top6;
	}
	public string get_top7(){
		return sal_top7;
	}

	public int get_topNum(){
		return sal_top_num;
		}

	public string get_salName(){
		return sal_name;
	}

}
