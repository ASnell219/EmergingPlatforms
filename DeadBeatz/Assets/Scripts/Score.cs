using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI score = null;
    [SerializeField] Image Status = null;
    [SerializeField] Image Combo = null;

    [SerializeField] Sprite perfect = null;
    [SerializeField] Sprite great = null;
    [SerializeField] Sprite good = null;
    [SerializeField] Sprite ok = null;
    [SerializeField] Sprite miss = null;
    [SerializeField] Sprite two = null;
    [SerializeField] Sprite three = null;
    [SerializeField] Sprite blank = null;

    int scoreCount = 00000;
    int currentCount = 0;
    int perfectCount = 0;
    string tapStatus;

    void Update()
    {
        //if(Input.GetKeyDown(KeyCode.Q)) { tapStatus = "Perfect"; }
        //if(Input.GetKeyDown(KeyCode.W)) { tapStatus = "Great"; }
        //if(Input.GetKeyDown(KeyCode.E)) { tapStatus = "Good"; }
        //if(Input.GetKeyDown(KeyCode.R)) { tapStatus = "OK"; }
        //if(Input.GetKeyDown(KeyCode.T)) { tapStatus = "Miss"; }
 
        switch(tapStatus)
        {
            case "Perfect":
                currentCount = 200;
                perfectCount++;
                Status.sprite = perfect;
                break;
            case "Great":
                currentCount = 100;
                perfectCount = 0;
                Status.sprite = great;
                break;
            case "Good":
                currentCount = 50;
                perfectCount = 0;
                Status.sprite = good;
                break;
            case "OK":
                currentCount = 25;
                perfectCount = 0;
                Status.sprite = ok;
                break;
            case "Miss":
                currentCount = 0;
                perfectCount = 0;
                Status.sprite = miss;
                break;
        }

        if (perfectCount >= 30)
        {
            currentCount = currentCount * 3;
            Combo.sprite = three;
        }
        else if (perfectCount >= 15)
        {
            currentCount = currentCount * 2;
            Combo.sprite = two;
        }
        if (perfectCount == 0) { Combo.sprite = blank; }

        scoreCount += currentCount;
        score.text = scoreCount.ToString("D5");
        currentCount = 0;
        tapStatus = "";
    }
}
