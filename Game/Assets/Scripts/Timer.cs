using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

	float timeLeft = 30.0f;

	// Use this for initialization
	void Start () {

	}

	public GUIStyle timeStyle;
	void OnGUI() {
		GUI.Label (new Rect (Screen.width/2, Screen.height/4 - 150, 60, 60), timeLeft.ToString(), timeStyle);
	}

	// Update is called once per frame
	void Update () {
		timeLeft -= Time.deltaTime;


		if (timeLeft < 0) {
			// Game over
			Debug.Log("gg");
		}
	
	}
}
