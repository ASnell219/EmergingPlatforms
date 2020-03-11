using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score = null;
    [SerializeField] TextMeshProUGUI status = null;
    [SerializeField] GameObject image = null;

    [SerializeField] GameObject perfect = null;
    int scoreCount = 00000;
    int currentCount = 0;
    int perfectCount = 0;
    string tapStatus;
    void Start()
    {
        //image
    }

    void Update()
    {
        //Uncomment this code to test the scoring
        //if (Input.GetKeyDown(KeyCode.Q)) { tapStatus = "Perfect"; }
        //if (Input.GetKeyDown(KeyCode.W)) { tapStatus = "Great"; }
        //if (Input.GetKeyDown(KeyCode.E)) { tapStatus = "Good"; }
        //if (Input.GetKeyDown(KeyCode.R)) { tapStatus = "OK"; }
        //if (Input.GetKeyDown(KeyCode.T)) { tapStatus = "Miss"; }

        if (perfectCount >= 30) { currentCount = currentCount * 3; }
        else if (perfectCount >= 15) { currentCount = currentCount * 2; }

        switch(tapStatus)
        {
            case "Perfect":
                scoreCount += 200;
                perfectCount++;
                status.text = "PERFECT!";
                break;
            case "Great":
                scoreCount += 100;
                perfectCount = 0;
                status.text = "Great!";
                break;
            case "Good":
                scoreCount += 50;
                perfectCount = 0;
                status.text = "Good";
                break;
            case "OK":
                scoreCount += 25;
                perfectCount = 0;
                status.text = "Ok";
                break;
            case "Miss":
                perfectCount = 0;
                status.text = "Miss!";
                break;
        }

        scoreCount += currentCount;
        score.text = scoreCount.ToString("D5");
        currentCount = 0;
        tapStatus = "";
    }
}
