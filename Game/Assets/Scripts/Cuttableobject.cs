using UnityEngine;
using System.Collections;

public class Cuttableobject : MonoBehaviour {

	Transform tf;
	
	private GameObject MCRef;
	
	public bool SafeToCut = true;
	public bool isCut = false;

	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform>();
	
	}
	
	// Update is called once per frame
	void Update () {
		CheckCut();
		CheckExplosion();
	}
	
	private void CheckCut() {
		if (isCut == true) {
			Destroy (gameObject);
		}
	}
	
	private void CheckExplosion() {
		if (isCut == true && SafeToCut == false) {
			
		}
	}
}
