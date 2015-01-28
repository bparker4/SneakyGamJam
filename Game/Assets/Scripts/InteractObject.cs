using UnityEngine;
using System.Collections;

public class InteractObject : MonoBehaviour {

	Transform tf;
	
	public bool CanInteractWith = false;

	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform>();
		
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
