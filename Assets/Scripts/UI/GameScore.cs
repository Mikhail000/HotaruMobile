﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameScore : MonoBehaviour {

    int score;

    Text scoreTextUI;

    public int Score
    {
        get
        {
            return this.score;
        }
        set
        {
            this.score = value;
            UpdateScoreTextUI();
        }
    }

    void Start ()
    {
        scoreTextUI = GetComponent<Text>();
	}
	
	void UpdateScoreTextUI ()
    {
        string scoreStr = string.Format ("{0:0000000}", score);
        scoreTextUI.text = scoreStr;		
	}
}
