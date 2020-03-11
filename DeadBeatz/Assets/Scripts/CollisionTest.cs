using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionTest : MonoBehaviour
{
    public Collider ok_trigger;
    public Collider good_trigger;
    public Collider perfect_trigger;
    public Collider miss_trigger;
    public string state = "";

    public void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ok") state = "o";
        else if (other.tag == "Good") state = "g";
        else if (other.tag == "Perfect") state = "p";
        else if (other.tag == "Miss") state = "m";

    }

    public void OnTriggerExit(Collider other)
    {
        //Debug.Log("Exited");
    }

    public void Detect()
    {
        Debug.Log(state);
    }
}
