using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour {
	//Screen Indicator
	private int count = 0;

	public salad_struc salad;

	//Game Timer
	private float timer = 100;

	//Sizex and Sizey represent the size of the icons/images
	private int sizex = 53;
	private int sizey = 52;

	//Icons with booleans that add them to the bowl when selected (maybe group these)
	public Texture2D tomatoes;
	private bool tms = false;
	public Texture2D romaine;
	private bool rmne = false;
	public Texture2D feta;
	private bool fta = false;
	public Texture2D crutons;
	private bool crt = false;
	public Texture2D drycoral;
	private bool dryc = false;
	public Texture2D carrots;
	private bool car = false;
	public Texture2D peppers;
	private bool ppr = false;

	//Texture for the bowl
	//public Texture2D bowl;

	//Background
	public Texture2D background;

	//Start screen
	public Texture2D startscreen;

	//Orders
	public Texture2D order;

	//Recipe book
	public Texture2D recipes;

	//Allows for custom icons
	public GUIStyle style;
	public GUIStyle style2;

	void Start() {
		GameObject player;
		player = GameObject.FindWithTag ("Player");
		salad_struc[] tmp = player.GetComponents<salad_struc> ();
		salad = tmp [1];
	}

	//Updates the game in terms of player using the arrow keys to move screens or reset the game
	void Update() {
		if (count < 2) {
			if (Input.GetKeyDown (KeyCode.RightArrow) || Input.GetKeyDown (KeyCode.D)) {
				Camera.main.transform.Translate (new Vector3 (26, 0, 0));
				count += 1;
				}
			}
		if (count > 1) {
			if (Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.A)) {
				Camera.main.transform.Translate (new Vector3 (-26, 0, 0));
				count -= 1;
			}
		}
		if (Input.GetKeyDown (KeyCode.R)) {
						reset ();
				}
		if (count > 0) {
						timer -= Time.deltaTime;
				}
	}

	//Resets the game
	void reset () {
		//timer = 100;
		tms = false;
		rmne = false;
		fta = false;
		crt = false;
		dryc = false;
		car = false;
		ppr = false;
		salad.clear_sal ();
		}

	//Main GUI function, runs all the buttons
	void OnGUI () {
		//Screen indicator
		//GUI.Label (new Rect (Screen.width/2,0,100,50), "Screen " + (count + 1));

		//Timer
		if (count > 0) {
						GUI.Label (new Rect (Screen.width - 100, 0, 100, 50), "Timer " + (int)timer);
				}

		//Bowl
		//GUI.Label (new Rect (Screen.width/2, Screen.height - 50,50,50), bowl, style);

		//Determines whether a player uses the buttons to switch screens
		if (count == 0 || count == 2 || count == 3) {
			if (GUI.Button (new Rect (Screen.width - 100, Screen.height / 2 - 30, 100, 100), "Next")) {
					Camera.main.transform.Translate (new Vector3 (26, 0, 0));
					count += 1;
						}
				}
		if (count == 1) {
			if (GUI.Button (new Rect (Screen.width - 330, Screen.height - 75, 80, 65), "Here")) {
				Camera.main.transform.Translate (new Vector3 (26, 0, 0));
				count += 1;
			}
		}
		if (count > 1) {
			if (GUI.Button (new Rect (0, Screen.height / 2 - 30, 100, 100), "Back")) {
				Camera.main.transform.Translate (new Vector3 (-26, 0, 0));
				count -= 1;
			}
		}

		//saladGUI ();
		startScreenGUI ();
		screenGUI2 ();
		recipeScreenGUI ();
		recipeScreenGUI2 ();
		recipeScreenGUI3 ();
		//screenGUI3 ();
	}

	//Determines what is in the salad/on top of the bowl
	void saladGUI () {
		if (rmne) {
			GUI.Label (new Rect (Screen.width/2 - 55, Screen.height - 100,50,50), romaine, style);
		}
		if (tms) {
			GUI.Label (new Rect (Screen.width/2, Screen.height - 80,50,50), tomatoes, style);
		}
		if (fta) {
			GUI.Label (new Rect (Screen.width/2 - 105, Screen.height - 70,50,50), feta, style);
		}
		if (car) {
			GUI.Label (new Rect (Screen.width/2 - 105, Screen.height - 100,50,50), carrots, style);
		}
		if (crt) {
			GUI.Label (new Rect (Screen.width/2 - 40, Screen.height - 65,50,50), crutons, style);
		}
		if (dryc) {
			GUI.Label (new Rect (Screen.width/2 - 60, Screen.height - 75,100,75), drycoral, style);
		}
		if (ppr) {
			GUI.Label (new Rect (Screen.width/2 - 60, Screen.height - 90,50,50), peppers, style);
		}
	}

	void startScreenGUI() {
	if (count == 0) {
			GUI.Label (new Rect (200, 0,2000,600), startscreen, style); 
			GUI.Box (new Rect(690, 60, 400, 300), "You are a new employee at the newest restaurant in the Atlantic. " +
				"The motto of your company is that you are there to let shark eat" +
			    "healthier. As such, you must feed all the hungry customers you" +
			    "get by click on the correct ingredients for their particular orders. " +
				"If you get stuck, you can refer to the recipe book in the bottom-right " +
			    "of the screen. Be aware, however, for sharks do not take kindly to " +
				"those who take too long to make their food or prepare it incorrectly.", style);
				}
		}

	void recipeScreenGUI() {
		if (count == 2) {
			GUI.Label (new Rect (350, 0,3000,3000), recipes, style);
			GUI.Label (new Rect (450, 100, 250, 100), 
			           "Salty Shipwreck: " +
			           "\n" +
			           "\nShipwreck greens" +
			           "\nCarrots" +
			           "\nDried coral chunks" +
			           "\nSea cucumber cucumbers" +
			           "\nGround discarded clam shells" +
			           "\nSea salt" +
			           "\n" +
			           "\nMoss Forest: " +
			           "\n" +
			           "\nRomaine" +
			           "\nTomatoes" +
			           "\nKelp" +
			           "\nCarrots" +
			           "\nFeta cheese" +
			           "\nRock moss" +
			           "\nSeasalt", style2);
			GUI.Label (new Rect (750, 100, 250, 100),
			           "\nHARDcore Vegetarian:" +
			           "\n" +
			           "\nKelp" +
			           "\nRock moss" +
			           "\nGround clam shells" +
			           "\nDried coral chunks" +
			           "\nCroutons" +
			           "\n" +
			           "\nSmooth Sailing: " +
			           "\n" +
			           "\nWhale blubber" +
			           "\nJellyfish jelly" +
			           "\nTofu" +
			           "\nSea salt", style2);
				}
	}

	void recipeScreenGUI2() {
		if (count == 3) {
			GUI.Label (new Rect (350, 0,3000,3000), recipes, style);
			GUI.Label (new Rect (450, 100, 250, 100), 
			           "\nRomaine Calm: " +
			           "\n" +
			           "\nRomaine" +
			           "\nTomatoes" +
			           "\nFeta" +
			           "\nCrutons" +
			           "\n" +
			           "\nTastes Like Chicken: " +
			           "\n" +
			           "\nRomaine" +
			           "\nTofu" +
			           "\nMixed peppers" +
			           "\nCarrots", style2);
			GUI.Label (new Rect (750, 100, 250, 100),
			           "\nCrunchy Delight: " +
			           "\n" +
			           "\nRomaine" +
			           "\nTomatoes" +
			           "\nCarrots" +
			           "\nFeta" +
			           "\nSea cucumbers" +
			           "\nApples" +
			           "\n" +
			           "\nGreen Glob: " +
			           "\n" +
			           "\nRock moss" +
			           "\nWhale blubber" +
			           "\nDried coral chunks" +
			           "\nSea salt" +
			           "\nShipwreck greens", style2);
		}
	}

	void recipeScreenGUI3() {
				if (count == 4) {
						GUI.Label (new Rect (350, 0, 3000, 3000), recipes, style);
						GUI.Label (new Rect (450, 100, 250, 100), 
			           "\nJellyMoss: " +
			           "\n" +
			           "\nKelp" +
			           "\nJellyfish jelly" +
			           "\nRock moss" +
			           "\nGround discarded clam shells", style2);
				}
		}

	//Determines the icons on screen 1
	void screenGUI2 () {
	if (count == 1) {
			GUI.Label (new Rect (200, 0,2000,600), background, style);
			saladGUI();
			GUI.Label (new Rect (250, 150, 100, 100), order, style);
			GUI.Label (new Rect (260, 195, 80, 80), "Romain" +
				"\ne " +
				"Calm", style2);
		if (GUI.Button (new Rect (430, 325, sizex, sizey),tomatoes, style)) {
				salad.add_top("red");
				print ("you added tomatoes");
				tms = true;
		}
		if (GUI.Button (new Rect (500, 325, sizex, sizey),carrots, style)) {
				salad.add_top("wrong");
				print ("you added carrots");
				car = true;
		}
		if (GUI.Button (new Rect (395, 262 + (sizey * 2), sizex, sizey),feta, style)) {
				salad.add_base("yellow");
				print ("you added feta");
				fta = true;
		}
		if (GUI.Button (new Rect (620, 325, sizex * 2, sizey + 25),drycoral, style)) {
				salad.add_top("wrong");
				print ("you added dry coral");
				dryc = true;
		}
		if (GUI.Button (new Rect (915, 217 + (sizey * 4), sizex, sizey),crutons, style)) {
				salad.add_dress("green");
				print ("you added crutons");
				crt = true;
		}
		if (GUI.Button (new Rect (775, 325, sizex, sizey),peppers, style)) {
				salad.add_top("wrong");
				print ("you added peppers");
				ppr = true;
		}
		if (GUI.Button (new Rect (315, 257 + (sizey * 2), sizex, sizey),romaine, style)) {
				salad.add_prot("red");
				print ("you added romaine");
				rmne = true;
		}
	}
	}
	/*
	//Determines what happens on Screen 3
	void screenGUI3 () {
		if (count == 5) {
			if (GUI.Button (new Rect (50, 20, sizex, sizey),tomatoes, style)) {
				print ("you clicked the icon 1");
				tms = true;
			}
			if (GUI.Button (new Rect (50 + (sizex * 2), 20, sizex, sizey),romaine, style)) {
				print ("you clicked the icon 2");
				rmne = true;
			}
			if (GUI.Button (new Rect (50, 20 + (sizey * 2), sizex, sizey),feta, style)) {
				print ("you clicked the icon 3");
			}
			if (GUI.Button (new Rect (50 + (sizex * 4), 20, sizex, sizey),tomatoes, style)) {
				print ("you clicked the icon 4");
			}
			if (GUI.Button (new Rect (50, 20 + (sizey * 4), sizex, sizey),romaine, style)) {
				print ("you clicked the icon 5");
			}
			if (GUI.Button (new Rect (50 + (sizex * 6), 20, sizex, sizey),feta, style)) {
				print ("you clicked the icon 6");
			}
			if (GUI.Button (new Rect (50, 20 + (sizey * 6), sizex, sizey),tomatoes, style)) {
				print ("you clicked the icon 7");
			}
		}
	}
	*/
}
