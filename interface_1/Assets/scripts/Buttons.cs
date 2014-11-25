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
	public Texture2D icon;
	private bool ic1 = false;
	public Texture2D icon2;
	private bool ic2 = false;
	public Texture2D icon3;

	//Texture for the bowl
	public Texture2D bowl;

	//Allows for custom icons
	public GUIStyle style;

	void Start() {
		GameObject player;
		player = GameObject.FindWithTag ("Player");
		salad_struc[] tmp = player.GetComponents<salad_struc> ();
		salad = tmp [1];
	}

	//Updates the game in terms of player using the arrow keys to move screens or reset the game
	void Update() {
		if (count < 4) {
			if (Input.GetKeyDown (KeyCode.RightArrow) || Input.GetKeyDown (KeyCode.D)) {
				Camera.main.transform.Translate (new Vector3 (26, 0, 0));
				count += 1;
				}
			}
		if (count > 0) {
			if (Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.A)) {
				Camera.main.transform.Translate (new Vector3 (-26, 0, 0));
				count -= 1;
			}
		}
		if (Input.GetKeyDown (KeyCode.R)) {
						reset ();
				}
		timer -= Time.deltaTime;
	}

	//Resets the game
	void reset () {
		timer = 100;
		ic1 = false;
		ic2 = false;
		}

	//Main GUI function, runs all the buttons
	void OnGUI () {
		//Screen indicator
		GUI.Label (new Rect (Screen.width/2,0,100,50), "Screen " + (count + 1));

		//Timer
		GUI.Label (new Rect (Screen.width - 100,0,100,50), "Timer " + (int)timer);

		//Bowl
		GUI.Label (new Rect (Screen.width/2, Screen.height - 50,50,50), bowl, style);

		//Determines whether a player uses the buttons to switch screens
		if (count < 4) {
			if (GUI.Button (new Rect (Screen.width - 100, Screen.height / 2 - 30, 100, 100), "Next Screen")) {
					Camera.main.transform.Translate (new Vector3 (26, 0, 0));
					count += 1;
						}
				}
		if (count > 0) {
			if (GUI.Button (new Rect (0, Screen.height / 2 - 30, 100, 100), "Previous Screen")) {
				Camera.main.transform.Translate (new Vector3 (-26, 0, 0));
				count -= 1;
			}
		}

		saladGUI ();
		screenGUI1 ();
		screenGUI3 ();
	}

	//Determines what is in the salad/on top of the bowl
	void saladGUI () {
		if (ic1) {
			GUI.Label (new Rect (Screen.width/2, Screen.height - 80,50,50), icon, style);
		}
		if (ic2) {
			GUI.Label (new Rect (Screen.width/2 - 25, Screen.height - 80,50,50), icon2, style);
		}
	}

	//Determines the icons on screen 1
	void screenGUI1 () {
	if (count == 0) {
		if (GUI.Button (new Rect (50, 20, sizex, sizey),icon, style)) {
			salad.add_top("red");
			print ("you clicked the icon 1");
			ic1 = true;
		}
		if (GUI.Button (new Rect (50 + (sizex * 2), 20, sizex, sizey),icon2, style)) {
			print ("you clicked the icon 2");
			ic2 = true;
		}
		if (GUI.Button (new Rect (50, 20 + (sizey * 2), sizex, sizey),icon3, style)) {
				salad.add_base("yellow");
				print ("you clicked the icon 3");
		}
		if (GUI.Button (new Rect (50 + (sizex * 4), 20, sizex, sizey),icon, style)) {
			print ("you clicked the icon 4");
		}
		if (GUI.Button (new Rect (50, 20 + (sizey * 4), sizex, sizey),icon2, style)) {
				salad.add_dress("green");
				print ("you clicked the icon 5");
		}
		if (GUI.Button (new Rect (50 + (sizex * 6), 20, sizex, sizey),icon3, style)) {
			print ("you clicked the icon 6");
		}
		if (GUI.Button (new Rect (50, 20 + (sizey * 6), sizex, sizey),icon, style)) {
				salad.add_prot("red");
				print ("you clicked the icon 7");
		}
	}
	}

	//Determines what happens on Screen 3
	void screenGUI3 () {
		if (count == 2) {
			if (GUI.Button (new Rect (50, 20, sizex, sizey),icon, style)) {
				print ("you clicked the icon 1");
				ic1 = true;
			}
			if (GUI.Button (new Rect (50 + (sizex * 2), 20, sizex, sizey),icon2, style)) {
				print ("you clicked the icon 2");
				ic2 = true;
			}
			if (GUI.Button (new Rect (50, 20 + (sizey * 2), sizex, sizey),icon3, style)) {
				print ("you clicked the icon 3");
			}
			if (GUI.Button (new Rect (50 + (sizex * 4), 20, sizex, sizey),icon, style)) {
				print ("you clicked the icon 4");
			}
			if (GUI.Button (new Rect (50, 20 + (sizey * 4), sizex, sizey),icon2, style)) {
				print ("you clicked the icon 5");
			}
			if (GUI.Button (new Rect (50 + (sizex * 6), 20, sizex, sizey),icon3, style)) {
				print ("you clicked the icon 6");
			}
			if (GUI.Button (new Rect (50, 20 + (sizey * 6), sizex, sizey),icon, style)) {
				print ("you clicked the icon 7");
			}
		}
	}
}
