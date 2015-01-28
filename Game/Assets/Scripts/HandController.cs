using UnityEngine;
using System.Collections;

public class HandController : MonoBehaviour {

	Transform tf;
	
	
	public float StressLevel = 0.0f;
	
	private float jitterCoefficient;
	
	private Vector3 prevPos;

	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform>();
		
		prevPos = tf.position;
	
	}
	
	// Update is called once per frame
	void Update () {
		
		ControlHand();
		
		prevPos = tf.position;
	}
	
	private void ControlHand() {
	
		
	
		//change Hand position and apply jitters from stress
		tf.position = new Vector3(Input.mousePosition.x + Random.Range(-StressLevel, StressLevel),
								  Input.mousePosition.y + Random.Range(-StressLevel/2.0f, StressLevel/2.0f),
								  tf.position.z);
	}
	
	private void ApplyJitters() {
		
	}
	
	private void ControlPickup() {
		
	}
	
	private void RaycastByLayer(string layerName) {
		Vector3 mousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
		                               Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
		RaycastHit2D mousePosHit;
		
		if(mousePosHit = Physics2D.Raycast(mousePos, Vector2.zero, Mathf.Infinity)) {
			//SelectedTile = mousePosHit.collider.gameObject;
		}
	}
}
