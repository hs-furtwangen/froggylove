using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

	int points = 0;
	float timelimit = 300;

	void Start () {
		
	}
	
	void Update () {
		timelimit -= Time.deltaTime;
		Debug.Log(floatToReadableTime(timelimit));

		if(timelimit < 0){
			//TODO: If time is up, end the game
		}
	}

	string floatToReadableTime(float time){
		string readable = "";
		readable += Mathf.FloorToInt(time / 60) + ":" + Mathf.FloorToInt(time % 60);

		return readable;
	}
}
