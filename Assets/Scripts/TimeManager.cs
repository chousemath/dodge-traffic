using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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
		timeText.text = timeNum.ToString("F2");
	}
}
