using UnityEngine;
using System.Collections;

public class Cuttableobject : MonoBehaviour {

	Transform tf;
	
	public bool SafeToCut = true;

	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform>();
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
