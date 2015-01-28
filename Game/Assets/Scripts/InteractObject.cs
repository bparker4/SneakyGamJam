using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class InteractObject : MonoBehaviour {

	Transform tf;
	
	private GameObject InteractVol;//INTERACT ZONE
	private List<GameObject> HoveringOver;
	
	public bool CanInteractWith = false;

	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform>();
		HoveringOver = new List<GameObject>();
		
		InteractVol = tf.FindChild("InteractZone").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void OnTriggerEnter2D(Collider2D other) {
		if (other.tag == "CanCut") {
			HoveringOver.Add(other.gameObject);
		}
	}
	void OnTriggerExit2D(Collider2D other) {
		if (HoveringOver.Contains(other.gameObject)) {
			HoveringOver.Remove(other.gameObject);
		}
	}
	
	public void TriggerInteraction() {
		foreach (GameObject thing in HoveringOver) {
			thing.GetComponent<Cuttableobject>().isCut = true;
		}
	}
}
