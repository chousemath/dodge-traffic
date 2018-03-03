using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour {
	public float moveSpeed = -8f;
	private float yOrigin;
	private float timer = 0;
	Rigidbody2D rb2d;

	// Use this for initialization
	void Awake () {
		rb2d = GetComponent<Rigidbody2D>();
		yOrigin = rb2d.position.y;
		gameObject.GetComponent<Renderer>().material.color = Color.red;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void FixedUpdate () {
		timer += 10 * Time.fixedDeltaTime;
		rb2d.MovePosition(new Vector2(
			rb2d.position.x + moveSpeed * Time.fixedDeltaTime,
			yOrigin + 0.1f * Mathf.Sin(timer) // bounce the car
		));
	}
}
