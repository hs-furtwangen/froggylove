using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {
    public static GameController gameControllerInstance;
	int points = 0;
	float timelimit = 300;
    public int getPoints()
    {
        return points;
    }
    public void addPoints(int points, float multiplier)
    {
        this.points += (int)(points * multiplier);
    }

	void Start () {
        if(gameControllerInstance == null)
        {
            gameControllerInstance = this;
        }
	}
	
	void Update () {
		timelimit -= Time.deltaTime;
		// Debug.Log(floatToReadableTime(timelimit));

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
