using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour {
    private int score;
    private Text scoreText;

    public int scoreIncrement = 10;
    public int scoreIncrementBig = 50;
	// Use this for initialization
	void Start () {
        score = 0;
        scoreText = gameObject.GetComponent<Text>();
        scoreText.text = score.ToString();
	}
	
    public void IncrementScore() {
        score += scoreIncrement;
        scoreText.text = score.ToString();
    }

    public void IncrementScoreBig() {
        score += scoreIncrementBig;
        scoreText.text = score.ToString();
    }
}
