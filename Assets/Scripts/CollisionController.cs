using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CollisionController : MonoBehaviour {
	void Start () {
		GameObject spawnManager = GameObject.Find("SpawnManager");
		TimeManager timeManager = spawnManager.GetComponent<TimeManager>();
	}

	void OnCollisionEnter2D (Collision2D coll) {
		if (coll.gameObject.tag == "Car") {
			Debug.Log("Car was hit!");
		}
	}

	void OnTriggerEnter2D (Collider2D coll) {
		if (coll.gameObject.tag == "Company") {
			Debug.Log("Win!");
			SceneManager.LoadScene("GameSuccess");
		}
	}
}
