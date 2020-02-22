using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TouchInput : MonoBehaviour
{
    public Text phaseDisplayText;
    private Touch theTouch;
    private float timeTouchEnded;
    private float displayTime;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0 || Input.GetMouseButtonDown(0))
        {
            Debug.Log("Tap");
            theTouch = Input.GetTouch(0);
            phaseDisplayText.text = theTouch.phase.ToString();

            if (theTouch.phase == TouchPhase.Ended)
            {
                timeTouchEnded = Time.time;
            }

        }
        else if (Time.time - timeTouchEnded > displayTime)
        {
            phaseDisplayText.text = "";
        }
    }
}
