using UnityEngine;
using System.Collections;

public class InteractObject : MonoBehaviour {

	Transform tf;
	
	private GameObject InteractVol;
	
	public bool CanInteractWith = false;

	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform>();
		
		InteractVol = tf.FindChild("InteractZone").gameObject;
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	public void TriggerInteraction() {
		
	}
}
