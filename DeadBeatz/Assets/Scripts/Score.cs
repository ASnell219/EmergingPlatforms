using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score = null;
    [SerializeField] Image image = null;

    [SerializeField] Sprite perfect = null;
    [SerializeField] Sprite great = null;
    [SerializeField] Sprite good = null;
    [SerializeField] Sprite ok = null;
    [SerializeField] Sprite miss = null;

    int scoreCount = 00000;
    int currentCount = 0;
    int perfectCount = 0;
    string tapStatus;

    void Start()
    {
        
    }

    void Update()
    {
        if (perfectCount >= 30) { currentCount = currentCount * 3; }
        else if (perfectCount >= 15) { currentCount = currentCount * 2; }

        switch(tapStatus)
        {
            case "Perfect":
                scoreCount += 200;
                perfectCount++;
                image.sprite = perfect;
                break;
            case "Great":
                scoreCount += 100;
                perfectCount = 0;
                image.sprite = great;
                break;
            case "Good":
                scoreCount += 50;
                perfectCount = 0;
                image.sprite = good;
                break;
            case "OK":
                scoreCount += 25;
                perfectCount = 0;
                image.sprite = ok;
                break;
            case "Miss":
                perfectCount = 0;
                image.sprite = miss;
                break;
        }

        scoreCount += currentCount;
        score.text = scoreCount.ToString("D5");
        currentCount = 0;
        tapStatus = "";
    }
}
