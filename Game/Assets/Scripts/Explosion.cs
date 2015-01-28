using UnityEngine;
using System.Collections;

public class NewBehaviourScript : MonoBehaviour {

	//Stuff for explosion
	SpriteRenderer explosionMaker;

	// Use this for initialization
	void Start () {
		explosionMaker = GetComponent < SpriteRenderer> ();
		explosionMaker.enabled = false;
	}

	//Make the bomb explode when the function is called
	void explosion() {
		explosionMaker.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
