using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChangeState : MonoBehaviour
{
    public ListManager lm;
    public string state = "";

    public void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Monster")
        {
            if (state.Equals("Miss"))
            {
                lm.gameObjects.Remove(other.gameObject);
                other.gameObject.SetActive(false);
            }
            else
            {
                MonsterObject mo = other.gameObject.GetComponentInChildren<MonsterObject>();
                mo.currentState = state;
            }
        }
    }
}
