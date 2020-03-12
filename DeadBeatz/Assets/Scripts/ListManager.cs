using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ListManager : MonoBehaviour
{
    public List<GameObject> gameObjects = new List<GameObject>();

    public void AddToList(GameObject go)
    {
        this.gameObjects.Add(go);
    }

    public void RemoveFromList(GameObject go)
    {
        this.gameObjects.Remove(go);
    }

    public GameObject GetFirstIndex()
    {
        return this.gameObjects[0];
    }
}
