using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreSystem : MonoBehaviour {

    public static int TotalScore = 0;  // Use this for initialization
    public Text TotalScoreText;
    // Update is called once per frame
    void Update ()
    {
        TotalScoreText.text = TotalScore.ToString();
    }

    public static void AddScore(int Score)
    {
        TotalScore += Score;
    }
}
