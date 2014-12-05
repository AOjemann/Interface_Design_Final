using UnityEngine;
using System.Collections;

public class salad_randomizer : MonoBehaviour {

	//all salad recipies are atached to the player as instances of salad strucs that have been compleeted
	//in the inspector, They are always attached after the example salad and the player salad

	salad_struc[] posibleSal;
	int randomSalIndex;
	Buttons buttonSTMP;

	public int number_of_recipies;

	salad_struc exSal;
	salad_struc randomSal;
	salad_struc playerSal;

	// Use this for initialization
	void Start () {
	
		posibleSal =  this.GetComponents<salad_struc> ();
		buttonSTMP = GameObject.FindWithTag ("buttons").GetComponent<Buttons> ();
		exSal = posibleSal [0];
		playerSal = posibleSal [1];
		setRandomSaladFromBook ();


	}
	
	// Update is called once per frame
	void Update () {
	
	}


	//sets ex salad equal to a random salad from the recipie book
	public void setRandomSaladFromBook(){

		randomSalIndex = Random.Range (2, number_of_recipies + 1);
		randomSal = posibleSal[randomSalIndex];

		exSal.clear_sal ();
		exSal.add_base (randomSal.get_base());
		exSal.add_dress (randomSal.get_dress());
		exSal.add_prot (randomSal.get_prot());
		exSal.add_top (randomSal.get_top1());
		exSal.add_top (randomSal.get_top2());
		exSal.add_top (randomSal.get_top3());

		print (randomSal.sal_name);
		buttonSTMP.nextOrder (randomSal.sal_name);

		playerSal.clear_sal ();


		}

}
