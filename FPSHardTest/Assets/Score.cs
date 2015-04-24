using UnityEngine;
using System.Collections;

public class Score : MonoBehaviour {

	static int score=0;
	static int highscore=0;
	int endScore=46;


	static public void AddPoint(){

		score++;
		if (score > highscore) {
			highscore=score;		
		}
	
	}

	// Update is called once per frame
	void Update () {

		GetComponent<GUIText>().text = "Score: " + score;
		if (score >= endScore) {

			GetComponent<GUIText>().text = "YOU WIN!";
			}
		


	}
}
