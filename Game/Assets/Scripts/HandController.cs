using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class HandController : MonoBehaviour {

	Transform tf;
	SpriteRenderer sprRen;
	
	public GameObject Holding;
	
	public float ZLevel;
	
	public float StressLevel = 0.0f;
	
	private float jitterCoefficient;
	
	private Vector3 prevPos;
	
	private List<GameObject> CollidingWithMe;
	
	public Sprite HandOpen;
	public Sprite HandClosed;

	
	void OnTriggerEnter2D(Collider2D other){		
		if (other.tag == "CanGrab") {
			CollidingWithMe.Add(other.gameObject);
		}	
	}
	
	void OnTriggerExit2D(Collider2D other) {
		if (CollidingWithMe.Contains (other.gameObject)) {
			CollidingWithMe.Remove(other.gameObject);
		}
		
	}

	// Use this for initialization
	void Start () {
		tf = GetComponent<Transform>();
		sprRen = GetComponent<SpriteRenderer>();
		CollidingWithMe = new List<GameObject>();
		
		prevPos = tf.position;
	
	}
	
	// Update is called once per frame
	void Update () {
		
		ControlHand();
		
		prevPos = tf.position;
	}

	
	private void ControlHand() {
	
		if (Input.GetMouseButtonDown(0)) {//LEFT CLICK
			if (Holding != null) {
				Holding.GetComponent<InteractObject>().TriggerInteraction();
			}
			
		}
		
		if (Input.GetKeyDown(KeyCode.Space)) {//Keep object held if hitting spacebar
			PickupObject();
			sprRen.sprite = HandClosed;
		}
		
		if (Input.GetKeyUp(KeyCode.Space)) {//Release object if release spacebar
			DropObject();
			sprRen.sprite = HandOpen;
		}
	
		//change Hand position and apply jitters from stress
		tf.position = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x + Random.Range(-StressLevel, StressLevel),
								  Camera.main.ScreenToWorldPoint(Input.mousePosition).y + Random.Range(-StressLevel/2.0f, StressLevel/2.0f),
								  tf.position.z);
	}
	
	private void ApplyJitters() {
		
	}
	
	private void ControlPickup() {
		
	}
	
	private void SpecialMouseRaycast() {
		Vector3 mousePos = new Vector3(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
		                               Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
		RaycastHit2D mousePosHit;
		
		if(mousePosHit = Physics2D.Raycast(mousePos, Vector2.zero, Mathf.Infinity)) {
			//SelectedTile = mousePosHit.collider.gameObject;
		}
	}
	
//PARENT PICKUP-ABLE TO THE HAND
	private void PickupObject() {
		if (CollidingWithMe.Count > 0) {
			foreach (GameObject gO in CollidingWithMe) {
				if (gO.tag == "CanGrab") {
					gO.GetComponent<Transform>().parent = tf;
					Holding = gO;
					
					break;
				}
			}
		}
	
		//Debug.Log("holding");
		
		//SpecialMouseRaycast();
		
	}
	private void DropObject() {
		if (Holding != null) {
			tf.DetachChildren();
			Holding = null;
		}
	
		//Debug.Log("dropping");
	}
}
