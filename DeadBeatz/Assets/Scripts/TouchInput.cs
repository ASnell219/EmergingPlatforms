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
            //Ray raycast = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
            Ray raycast = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit raycastHit;

            if (Physics.Raycast(raycast, out raycastHit))
            {

                if (raycastHit.collider.name == "Button")
                {
                    
                        Debug.Log("Tap 1");
                                      
                }

                if (raycastHit.collider.name == "Button2")
                {
                    Debug.Log("Tap 2");

                }

                if (raycastHit.collider.name == "Button3")
                {
                    Debug.Log("Tap 3");

                }

                if (raycastHit.collider.name == "Button4")
                {
                    Debug.Log("Tap 4");

                }
            }
            /*
            theTouch = Input.GetTouch(0);//error here
            phaseDisplayText.text = theTouch.phase.ToString();
            Debug.Log(theTouch);

            if (theTouch.phase == TouchPhase.Ended)
            {
                timeTouchEnded = Time.time;
            }
            */
            
        }
        /*
        else if (Time.time - timeTouchEnded > displayTime)
        {
            phaseDisplayText.text = "";
        }
        */
    }
}
