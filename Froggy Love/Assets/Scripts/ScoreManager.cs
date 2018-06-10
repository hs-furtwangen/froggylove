using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {

	public Text scoreText;

	void Start () {
		scoreText.text = "";
		List<string> scoresList = new List<string>();
		using (System.IO.StreamReader sr = new System.IO.StreamReader(Application.persistentDataPath + "/highscores.txt")){
			string scoresline = "";
			do{
				scoresline = sr.ReadLine();
				if(scoresline != null){
					scoresList.Add(scoresline);
				}

			} while (scoresline != null);
		}
		for(int i = 0; (i < 5) && (i < scoresList.Count); i++){
			scoreText.text += (i + 1) + ". " + scoresList[scoresList.Count - i - 1] + "\n";
		}
	}
}
