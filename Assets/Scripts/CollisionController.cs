using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		Debug.Log("Collision Controller Activated");
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnCollisionEnter2D (Collision2D coll) {
		if (coll.gameObject.tag == "Car") {
			Debug.Log("Car was hit!");
		}
	}

	void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.tag == "Company") {
			Debug.Log("Win!");
		}
	}
}
