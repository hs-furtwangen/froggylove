using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
    public static GameController gameControllerInstance;
    public Text ScoreText;
    public Text TimeText;

    public GameObject femaleSpawner;
    public GameObject maleSpawner;

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

        timelimit = Config.TimeLimit;
	}
	
	void Update () {
		timelimit -= Time.deltaTime;
		// Debug.Log(floatToReadableTime(timelimit));

		if(timelimit < 0){
			//TODO: If time is up, end the game
            List<int> scoresList = new List<int>();
            using (System.IO.StreamReader sr = new System.IO.StreamReader(Application.persistentDataPath + "/highscores.txt")){
                string scoresline = "";
                do{
                    scoresline = sr.ReadLine();
                    if(scoresline != null){
                        scoresList.Add(int.Parse(scoresline));
                    }

                } while (scoresline != null);
            }
            scoresList.Add(points);
            scoresList.Sort();
            string[] scoresString = new string[scoresList.Count];
            for(int i = 0; i < scoresList.Count; i++){
                scoresString[i] = scoresList[i].ToString();
            }
            System.IO.File.WriteAllLines(Application.persistentDataPath + "/highscores.txt", scoresString);
            UnityEngine.SceneManagement.SceneManager.LoadScene("MainMenu");
		}

        ScoreText.text = points.ToString();
        TimeText.text = floatToReadableTime(timelimit);

        int countMale = GameObject.FindGameObjectsWithTag("MaleFrog").Length;
        int countFemale = GameObject.FindGameObjectsWithTag("FemaleFrog").Length;

        femaleSpawner.GetComponent<Spawner>().spawnNew(Config.femaleFrogLimit - countFemale);
        maleSpawner.GetComponent<Spawner>().spawnNew(Config.maleFrogLimit - countMale);

	}

	string floatToReadableTime(float time){
		string readable = "";
        if (Mathf.FloorToInt(time % 60) > 9){
            readable += Mathf.FloorToInt(time / 60) + ":" + Mathf.FloorToInt(time % 60);
        } else {
            readable += Mathf.FloorToInt(time / 60) + ":0" + Mathf.FloorToInt(time % 60);
        }


		return readable;
	}
}
