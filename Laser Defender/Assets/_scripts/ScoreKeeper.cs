﻿using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class ScoreKeeper : MonoBehaviour {

    public static int score = 0;
    private Text myText;

    private void Start() {
        myText = GetComponent<Text>();
        Reset();
    }

    public void Score(int points) {
        Debug.Log("Score");
        score += points;
        myText.text = score.ToString();
    }

    public static void Reset() {
        score = 0;
    }

}