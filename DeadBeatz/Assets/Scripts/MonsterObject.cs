using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterObject : MonoBehaviour
{
    public string currentState = "";

    public string State { get { return currentState; } set { currentState = value; } }
}
