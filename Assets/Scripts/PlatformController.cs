using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour {

	[HideInInspector] public bool facingRight = true;
	[HideInInspector] public bool jump = true;

	public float moveForce = 365f;
	public float maxSpeed = 5f;
	public float jumpForce = 1000f;
	// You line cast towards the ground to check if the player is on the ground
	public Transform groundCheck;

	private bool grounded = false;
	private Animator anim;
	private Rigidbody2D rb2d;

	// Use this for initialization
	void Awake () {
		anim = GetComponent<Animator>();
		rb2d = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
		grounded = Physics2D.Linecast(
			transform.position, // cast to 2D, z-axis is discarded
			groundCheck.position, // transform at character's feet
			1 << LayerMask.NameToLayer("Ground") // only layer we will cast against is Ground
		);
		if (Input.GetButtonDown("Jump") && grounded) {
			jump = true;
		}
	}

	// Always do your physics code within FixedUpdate
	void FixedUpdate () {
		float h = Input.GetAxis("Horizontal");
		anim.SetFloat("Speed", Mathf.Abs(h));
		// check if currently under the speed limit
		if (h * rb2d.velocity.x < maxSpeed) {
			// handles speed up, slow down, reversal of movement
			rb2d.AddForce(Vector2.right * h * moveForce);
		}

		if (Mathf.Abs(rb2d.velocity.x) > maxSpeed) {
			rb2d.velocity = new Vector2(
				Mathf.Sign(rb2d.velocity.x) * maxSpeed,
				rb2d.velocity.y
			);
		}

		// we do not want to be facing one way and moving in another
		if (h > 0 && !facingRight || h < 0 && facingRight) {
			Flip();
		}

		if (jump) {
			anim.SetTrigger("Jump");
			rb2d.AddForce(new Vector2(0f, jumpForce));
			jump = false;
		}
	}

	// flip the sprite in the direction of movement
	void Flip () {
		facingRight = !facingRight;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1; // invert the scale
		transform.localScale = theScale; // by scaling by -1, we are flipping our sprite around
	}
}
