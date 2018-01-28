using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class finalScoreScript : MonoBehaviour {
	public static int finalScore = 12;
	public Text scoreText; 
	// Use this for initialization
	void Start () {
		scoreText.text = finalScore.ToString ();
	}


	public static void updateScore (int score){
		finalScore = score;
	}


}
