using UnityEngine;
using System.Collections;

public class Buttons : MonoBehaviour {
	private int count = 0;
	private float timer = 100;
	private int sizex = 53;
	private int sizey = 52;
	public Texture2D icon;
	private bool ic1 = false;
	public Texture2D icon2;
	private bool ic2 = false;
	public Texture2D icon3;
	public Texture2D bowl;
	public GUIStyle style;

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

	void reset () {
		timer = 100;
		ic1 = false;
		ic2 = false;
		}
	
	void OnGUI () {
		GUI.Label (new Rect (Screen.width/2,0,100,50), "Count " + (count + 1));
		GUI.Label (new Rect (Screen.width - 100,0,100,50), "Timer " + (int)timer);
		GUI.Label (new Rect (Screen.width/2, Screen.height - 50,50,50), bowl, style);
		saladGUI ();
		screenGUI0 ();
		screenGUI2 ();
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
	}

	void saladGUI () {
		if (ic1) {
			GUI.Label (new Rect (Screen.width/2, Screen.height - 80,50,50), icon, style);
		}
		if (ic2) {
			GUI.Label (new Rect (Screen.width/2 - 25, Screen.height - 80,50,50), icon2, style);
		}
	}

	void screenGUI0 () {
	if (count == 0) {
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

	void screenGUI2 () {
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
