using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TimeManager : MonoBehaviour {
	public Text timeText;
	private float timeNum = 30f;
	// Use this for initialization
	void Start () {
		timeText.text = "30.00";
	}
	
	// Update is called once per frame
	void Update () {
		timeNum -= Time.fixedDeltaTime;
		if (timeNum <= 0) {
			SceneManager.LoadScene("GameFailure");
		} else {
			timeText.text = timeNum.ToString("F2");
		}
	}
}
