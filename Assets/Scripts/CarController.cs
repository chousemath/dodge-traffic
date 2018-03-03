using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {
	public float moveSpeed = -5f;
	Rigidbody2D rb2d;

	// Use this for initialization
	void Awake () {
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate () {
		rb2d.MovePosition(new Vector2(rb2d.position.x + moveSpeed * Time.fixedDeltaTime, rb2d.position.y));
	}
}
