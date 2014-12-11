using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour {
	//Screen Indicator
	private int count = 0;

	public salad_struc salad;
	public salad_struc eXsalad;

	//Game Timer
	private float timer = 100;

	//If Timer Runs You Lose
	private bool lose = false;

	//If you complete enough salads, you win
	public bool win = false;

	public bool tempX = false;
	public bool tempO = false;
	public float locTimerO = 2;
	public float locTimerX = 2;

	//Sizex and Sizey represent the size of the icons/images
	private int sizex = 106;
	private int sizey = 104;

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
	public Texture2D clams;
	private bool clm = false;
	public Texture2D tofu;
	private bool tfu = false;
	public Texture2D cucumber;
	private bool cuc = false;
	public Texture2D jelly;
	private bool jly = false;
	public Texture2D kelp;
	private bool klp = false;
	public Texture2D blubber;
	private bool bbb = false;
	public Texture2D salt;
	private bool slt = false;
	public Texture2D moss;
	private bool mss = false;
	public Texture2D greens;
	private bool grn = false;

	//Background
	public Texture2D background;

	//Start screen
	public Texture2D startscreen;

	//Lose screen
	public Texture2D losescreen;

	//Orders
	public Texture2D order;

	//Recipe book
	public Texture2D recipes;

	//Allows for custom icons
	public GUIStyle style;
	public GUIStyle style2;
	public GUIStyle style3;
	public GUIStyle style4;
	public GUIStyle style5;
	public GUIStyle correct;
	public GUIStyle wrong;

	void Start() {
		GameObject player;
		player = GameObject.FindWithTag ("Player");
		salad_struc[] tmp = player.GetComponents<salad_struc> ();
		salad = tmp [1];
		eXsalad = tmp [0];
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
		if (Input.GetKeyDown (KeyCode.X)) {
			locTimerX = 2;
			tempX = true;
		}
		if (Input.GetKeyDown (KeyCode.O)) {
			locTimerO = 2;
			tempO = true;
		}
		if (tempX) {
			locTimerX -= Time.deltaTime;
				}
		if (tempO) {
			locTimerO -= Time.deltaTime;
		}
		if (count > 0 && timer > 0 && !win) {
						timer -= Time.deltaTime;
				}
		if (timer <= 0) {
						lose = true;
				}
	}

	//Resets the game
	public void reset () {
		//timer = 100;
		tms = false;
		rmne = false;
		fta = false;
		crt = false;
		dryc = false;
		car = false;
		ppr = false;
		clm = false;
		tfu = false;
		cuc = false;
		jly = false;
		klp = false;
		bbb = false;
		slt = false;
		mss = false;
		grn = false;
		salad.clear_sal ();
		}

	public void timeReduce() {
		timer -= 10;
		}

	//Main GUI function, runs all the buttons
	void OnGUI () {

		//Timer
		if (count > 0) {
			GUI.Label (new Rect (Screen.width * 0.9f, Screen.height * 0.9f, 100, 50), "Timer " + (int)timer);
				}

		//Determines whether a player uses the buttons to switch screens
		if ((count == 0 || count == 2 || count == 3) && lose == false) {
			if (GUI.Button (new Rect (Screen.width * 0.927f, Screen.height * 0.45f, 100, 100), "Next")) {
					Camera.main.transform.Translate (new Vector3 (26, 0, 0));
					count += 1;
						}
				}
		if (count == 1 && lose == false) {
			if (GUI.Button (new Rect (Screen.width * 0.758f, Screen.height * 0.875f, 80, 65), new GUIContent("Here", "Open Recipe Book"))) {
				Camera.main.transform.Translate (new Vector3 (26, 0, 0));
				count += 1;
			}
		}
		if (count == 1 && lose == false) {
			if (GUI.Button (new Rect (Screen.width * 0.152f, Screen.height * 0.875f, 80, 65), new GUIContent("Trash", "Throw Away Current Salad"))) {
				reset ();
			}
		}
		if (count > 1 && lose == false) {
			if (GUI.Button (new Rect (0, Screen.height * 0.45f, 100, 100), "Back")) {
				Camera.main.transform.Translate (new Vector3 (-26, 0, 0));
				count -= 1;
			}
		}

		//saladGUI ();
		startScreenGUI ();
		screenGUI2 ();
		legendGUI ();
		GUI.Label(new Rect(Screen.width/3, Screen.height/3, 100, 40), GUI.tooltip, style4);
		recipeScreenGUI ();
		recipeScreenGUI2 ();
		recipeScreenGUI3 ();
		checkOutCorrectGUI();
		checkOutIncorrectGUI();
		loseScreenGUI ();
		winScreenGUI ();
		//screenGUI3 ();
	}
	//Screen.width * 0.456f, Screen.height * 0.875f,100,75
	//Determines what is in the salad/on top of the bowl
	void saladGUI () {
		if (rmne) {
			GUI.Label (new Rect (Screen.width * 0.46f, Screen.height * 0.833f,50,50), romaine, style);
		}
		if (tms) {
			GUI.Label (new Rect (Screen.width/2, Screen.height * 0.866f,50,50), tomatoes, style);
		}
		if (slt) {
			GUI.Label (new Rect (Screen.width/2+10, Screen.height * 0.876f,50,50), salt, style);
		}
		if (mss) {
			GUI.Label (new Rect (Screen.width/2+10, Screen.height * 0.846f,50,50), moss, style);
		}
		if (fta) {
			GUI.Label (new Rect (Screen.width * 0.423f, Screen.height * 0.883f,50,50), feta, style);
		}
		if (car) {
			GUI.Label (new Rect (Screen.width * 0.423f, Screen.height * 0.833f,50,50), carrots, style);
		}
		if (crt) {
			GUI.Label (new Rect (Screen.width/2, Screen.height * 0.891f,50,50), crutons, style);
		}
		if (dryc) {
			GUI.Label (new Rect (Screen.width * 0.471f, Screen.height * 0.891f,50,50), drycoral, style);
		}
		if (grn) {
			GUI.Label (new Rect (Screen.width * 0.461f, Screen.height * 0.891f,50,50), greens, style);
		}
		if (ppr) {
			GUI.Label (new Rect (Screen.width * 0.456f, Screen.height * 0.849f,50,50), peppers, style);
		}
		if (clm) {
			GUI.Label (new Rect (Screen.width * 0.486f, Screen.height * 0.844f,50,50), clams, style);
		}
		if (tfu) {
			GUI.Label (new Rect (Screen.width * 0.456f, Screen.height * 0.844f,50,50), tofu, style);
		}
		if (cuc) {
			GUI.Label (new Rect (Screen.width * 0.44f, Screen.height * 0.832f,50,50), cucumber, style);
		}
		if (jly) {
			GUI.Label (new Rect (Screen.width * 0.42f, Screen.height * 0.852f,50,50), jelly, style);
		}
		if (klp) {
			GUI.Label (new Rect (Screen.width * 0.42f, Screen.height * 0.84f,50,50), kelp, style);
		}
		if (bbb) {
			GUI.Label (new Rect (Screen.width * 0.42f, Screen.height * 0.88f,50,50), blubber, style);
		}
	}

	void legendGUI() {
		//Left side
		GUI.Label (new Rect (Screen.width * 0.01f, Screen.height * 0.01f,50,50), kelp, style);
		GUI.Label (new Rect (Screen.width * 0.05f, Screen.height * 0.01f, 100, 40), "Kelp");
		GUI.Label (new Rect (Screen.width * 0.01f, Screen.height * 0.11f,50,50), romaine, style);
		GUI.Label (new Rect (Screen.width * 0.05f, Screen.height * 0.11f, 100, 40), "Romaine");
		GUI.Label (new Rect (Screen.width * 0.01f, Screen.height * 0.21f,75,75), carrots, style);
		GUI.Label (new Rect (Screen.width * 0.075f, Screen.height * 0.21f, 100, 40), "Carrots");
		GUI.Label (new Rect (Screen.width * 0.01f, Screen.height * 0.28f,75,75), tofu, style);
		GUI.Label (new Rect (Screen.width * 0.075f, Screen.height * 0.28f, 100, 40), "Tofu");
		GUI.Label (new Rect (Screen.width * 0.01f, Screen.height * 0.35f,75,75), crutons, style);
		GUI.Label (new Rect (Screen.width * 0.075f, Screen.height * 0.35f, 100, 40), "Crutons");
		GUI.Label (new Rect (Screen.width * 0.01f, Screen.height * 0.41f,75,75), tomatoes, style);
		GUI.Label (new Rect (Screen.width * 0.075f, Screen.height * 0.41f, 100, 40), "Tomatoes");
		//Skip Button
		GUI.Label (new Rect (Screen.width * 0.01f, Screen.height * 0.5f + 75,75,75), cucumber, style);
		GUI.Label (new Rect (Screen.width * 0.075f, Screen.height * 0.5f + 75, 100, 40), "Sea Cucumbers");
		GUI.Label (new Rect (Screen.width * 0.01f, Screen.height * 0.57f + 75,75,75), clams, style);
		GUI.Label (new Rect (Screen.width * 0.075f, Screen.height * 0.57f + 75, 100, 40), "Ground Clam Shells");
		GUI.Label (new Rect (Screen.width * 0.01f, Screen.height * 0.65f + 75,75,75), jelly, style);
		GUI.Label (new Rect (Screen.width * 0.075f, Screen.height * 0.64f + 75, 100, 40), "Jellyfish Jelly");
		GUI.Label (new Rect (Screen.width * 0.01f, Screen.height * 0.70f + 75,75,75), blubber, style);
		GUI.Label (new Rect (Screen.width * 0.075f, Screen.height * 0.69f + 75, 100, 40), "Whale Blubber");
		GUI.Label (new Rect (Screen.width * 0.01f, Screen.height * 0.74f + 75,75,75), feta, style);
		GUI.Label (new Rect (Screen.width * 0.075f, Screen.height * 0.74f + 75, 100, 40), "Feta Cheese");
		//Right side
		GUI.Label (new Rect (Screen.width * 0.85f, Screen.height * 0.01f,75,75), peppers, style);
		GUI.Label (new Rect (Screen.width * 0.915f, Screen.height * 0.01f, 100, 40), "Mixed Peppers");
		GUI.Label (new Rect (Screen.width * 0.85f, Screen.height * 0.08f,75,75), salt, style);
		GUI.Label (new Rect (Screen.width * 0.915f, Screen.height * 0.08f, 100, 40), "Sea Salt");
		GUI.Label (new Rect (Screen.width * 0.85f, Screen.height * 0.15f,75,75), greens, style);
		GUI.Label (new Rect (Screen.width * 0.915f, Screen.height * 0.15f, 100, 40), "Shipwreck Greens");
		GUI.Label (new Rect (Screen.width * 0.85f, Screen.height * 0.22f,75,75), moss, style);
		GUI.Label (new Rect (Screen.width * 0.915f, Screen.height * 0.22f, 100, 40), "Rock Moss");
		GUI.Label (new Rect (Screen.width * 0.85f, Screen.height * 0.29f,75,75), drycoral, style);
		GUI.Label (new Rect (Screen.width * 0.915f, Screen.height * 0.29f, 100, 40), "Dried Coral Chunks");
	}

	void startScreenGUI() {
		if (count == 0) {
			GUI.Label (new Rect (Screen.width * 0.147f, 0,2000,600), startscreen, style); 
			GUI.Box (new Rect(Screen.width * 0.505f, Screen.height * 0.1f, 400, 300), "You are a new employee at the newest restaurant in the Atlantic. " +
				"The motto of your company is that you are there to let shark eat " +
			    "healthier. As such, you must feed all the hungry customers you " +
			    "get by click on the correct ingredients for their particular orders. " +
				"If you get stuck, you can refer to the recipe book in the bottom-right " +
			    "of the screen. Be aware, however, for sharks do not take kindly to " +
				"those who take too long to make their food or prepare it incorrectly.", style);
				}
		}

	public void winLevel() {
		win = true;
	}

	public string nextOrder (string salad) {
		return salad;
		}

	void loseScreenGUI() {
		if (count > 0 && lose == true) {
			GUI.Label (new Rect (Screen.width * 0.146f, 0,2000,600), losescreen, style);
				}
		}

	void winScreenGUI() {
				if (count > 0 && win) {
						GUI.Label (new Rect (Screen.width / 3, Screen.height / 3, 600, 600), "You Win!", style3);
				}
		}

	public void checkOutCorrectGUI() {
			if (locTimerO > 0 && count == 1 && tempO) {
				GUI.Label (new Rect (Screen.width/3 - 50, Screen.height/500, 600, 600), "O", correct);
		}
	}

	public void checkOutIncorrectGUI() {
		if (locTimerX > 0 && count == 1 && tempX) {
			GUI.Label (new Rect (Screen.width/3, Screen.height/500, 600, 600), "X", wrong);
		}
	}

	void recipeScreenGUI() {
		if (count == 2) {
			GUI.Label (new Rect (Screen.width * 0.256f, 0,3000,3000), recipes, style);
			GUI.Label (new Rect (Screen.width * 0.329f, Screen.height * 0.167f, 250, 100), 
			           "Salty Shipwreck: " +
			           "\n" +
			           "\nShipwreck greens" +
			           "\nCarrots" +
			           "\nDried coral chunks" +
			           "\nSea cucumbers" +
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
			           "\nSea salt", style5);
			GUI.Label (new Rect (Screen.width * 0.549f, Screen.height * 0.167f, 250, 100),
			           "\nHARDcore Vegetarian:" +
			           "\n" +
			           "\nKelp" +
			           "\nRock moss" +
			           "\nGround discarded clam shells" +
			           "\nDried coral chunks" +
			           "\nCroutons" +
			           "\n" +
			           "\nSmooth Sailing: " +
			           "\n" +
			           "\nWhale blubber" +
			           "\nJellyfish jelly" +
			           "\nTofu" +
			           "\nSea salt", style5);
				}
	}

	void recipeScreenGUI2() {
		if (count == 3) {
			GUI.Label (new Rect (Screen.width * 0.256f, 0,3000,3000), recipes, style);
			GUI.Label (new Rect (Screen.width * 0.329f, Screen.height * 0.167f, 250, 100), 
			           "\nRomaine Calm: " +
			           "\n" +
			           "\nRomaine" +
			           "\nTomatoes" +
			           "\nFeta cheese" +
			           "\nCrutons" +
			           "\n" +
			           "\nTastes Like Chicken: " +
			           "\n" +
			           "\nRomaine" +
			           "\nTofu" +
			           "\nMixed peppers" +
			           "\nCarrots", style5);
			GUI.Label (new Rect (Screen.width * 0.549f, Screen.height * 0.167f, 250, 100),
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
			           "\nShipwreck greens", style5);
		}
	}

	void recipeScreenGUI3() {
				if (count == 4) {
						GUI.Label (new Rect (Screen.width * 0.256f, 0, 3000, 3000), recipes, style);
						GUI.Label (new Rect (Screen.width * 0.329f, Screen.height * 0.167f, 250, 100), 
			           "\nJellyMoss: " +
			           "\n" +
			           "\nKelp" +
			           "\nJellyfish jelly" +
			           "\nRock moss" +
			           "\nGround discarded clam shells", style5);
				}
		}
	//Determines the icons on screen 1
	void screenGUI2 () {
	if (count == 1 && lose == false) {
			//GUI.Label (new Rect (Screen.width * 0.146f, 0,2000,600), background, style);
			//saladGUI();
			//GUI.Label (new Rect (Screen.width * 0.183f, Screen.height/4, 100, 100), order, style);
			//GUI.Label (new Rect (Screen.width * 0.19f, Screen.height * 0.326f, 80, 80), nextOrder(eXsalad.sal_name), style2);
		//Columns go in order of bottom to top
		if (GUI.Button (new Rect (Screen.width * 0.309f, Screen.height * 0.69f, sizex+10, sizey+10),clams, style)) {
				salad.add_top("Ground clam shells");
				print ("you added Ground clam shells");
				clm = true;
		}
		if (GUI.Button (new Rect (Screen.width * 0.337f, Screen.height * 0.605f, sizex-20, sizey-20),cucumber, style)) {
				salad.add_top("Sea cucumbers");
				print ("you added Sea cucumbers");
				cuc = true;
		}
		if (GUI.Button (new Rect (Screen.width * 0.355f, Screen.height * 0.537f, sizex-30, sizey-30),tomatoes, style)) {
				salad.add_top("Tomatoes");
				print ("you added Tomatoes");
				tms = true;
		}
		if (GUI.Button (new Rect (Screen.width * 0.236f, Screen.height * 0.69f, sizex+10, sizey+10),crutons, style)) {
				salad.add_top("Crutons");
				print ("you added Crutons");
				crt = true;
		}
		if (GUI.Button (new Rect (Screen.width * 0.277f, Screen.height * 0.605f, sizex-20, sizey-20),tofu, style)) {
				salad.add_top("Tofu");
				print ("you added Tofu");
				tfu = true;
		}
		if (GUI.Button (new Rect (Screen.width * 0.307f, Screen.height * 0.538f, sizex-40, sizey-40),carrots, style)) {
				salad.add_top("Carrots");
				print ("you added Carrots");
				car = true;
		}
		if (GUI.Button (new Rect (Screen.width * 0.581f, Screen.height * 0.69f, sizex, sizey),salt, style)) {
				salad.add_top("Sea salt");
				print ("you added Sea salt");
				slt = true;
		}
		if (GUI.Button (new Rect (Screen.width * 0.571f, Screen.height * 0.602f, sizex-20, sizey-20),peppers, style)) {
				salad.add_top("Mixed peppers");
				print ("you added Mixed peppers");
				ppr = true;
		}
		if (GUI.Button (new Rect (Screen.width * 0.565f, Screen.height * 0.535f, sizex-40, sizey-40),feta, style)) {
				salad.add_top("Feta cheese");
				print ("you added Feta cheese");
				fta = true;
		}
		if (GUI.Button (new Rect (Screen.width * 0.655f, Screen.height * 0.69f, sizex, sizey),drycoral, style)) {
				salad.add_top("Dried coral chunks");
				print ("you added Dried coral chunks");
				dryc = true;
		}
		if (GUI.Button (new Rect (Screen.width * 0.631f, Screen.height * 0.602f, sizex-20, sizey-20),moss, style)) {
				salad.add_top("Rock moss");
				print ("you added Rock moss");
				mss = true;
		}
		if (GUI.Button (new Rect (Screen.width * 0.615f, Screen.height * 0.535f, sizex-40, sizey-40),greens, style)) {
				salad.add_top("Shipwreck greens");
				print ("you added Shipwreck greens");
				grn = true;
		}
		if (GUI.Button (new Rect (Screen.width * 0.18f, Screen.height * 0.58f, sizex-50, sizey-20),kelp, style)) {
				salad.add_top("Kelp");
				print ("you added Kelp");
				klp = true;
		}
		if (GUI.Button (new Rect (Screen.width * 0.22f, Screen.height * 0.58f, sizex-50, sizey-20),romaine, style)) {
				salad.add_top("Romaine");
				print ("you added Romaine");
				rmne = true;
		}
		if (GUI.Button (new Rect (Screen.width * 0.36f, Screen.height * 0.69f, sizex*3 + 25, sizey-50),blubber, style)) {
				salad.add_top("Whale blubber");
				print ("you added Whale blubber");
				bbb = true;
		}
		if (GUI.Button (new Rect (Screen.width * 0.41f, Screen.height * 0.535f, sizex*2, sizey-50),jelly, style)) {
				salad.add_top("Jellyfish jelly");
				print ("you added Jellyfish jelly");
				jly = true;
		}
			GUI.Label (new Rect (Screen.width * 0.146f, 0,2000,600), background, style);
			saladGUI();
			GUI.Label (new Rect (Screen.width * 0.183f, Screen.height/4, 100, 100), order, style);
			GUI.Label (new Rect (Screen.width * 0.19f, Screen.height * 0.326f, 80, 80), nextOrder(eXsalad.sal_name), style2);
	}
	}
}
