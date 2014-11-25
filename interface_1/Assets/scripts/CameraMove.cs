using UnityEngine;
using System.Collections;

public class CameraMove : MonoBehaviour {
	public float speed;
	private Vector3 defaultcameraposition;

	// Use this for initialization
	void Start () {
		defaultcameraposition = transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown (KeyCode.LeftArrow) || Input.GetKeyDown (KeyCode.RightArrow)) {
						speed = speed * -1;
				}
		//transform.Translate (new Vector3 (speed, 0, 0) * Time.deltaTime);
		if (Input.GetKeyDown (KeyCode.DownArrow)) {
			transform.localPosition.Set(0, 0, -10);
		}
		//Debug.Log(transform.localPosition);
	}
}
