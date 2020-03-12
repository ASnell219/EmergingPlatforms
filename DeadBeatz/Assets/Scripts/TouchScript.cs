using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchScript : MonoBehaviour
{
    public ListManager lm;

    void Update()
    {
        if(lm.gameObjects.Count > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 50))
                {
                    if (hit.collider.tag == "Cube")
                    {
                        MonsterObject mo = lm.gameObjects[0].GetComponentInChildren<MonsterObject>();
                        Debug.Log(mo.currentState);
                        //call score on object

                        GameObject go = lm.gameObjects[0];
                        lm.gameObjects.Remove(lm.gameObjects[0]);
                        go.SetActive(false);
                    }
                }
            }
        }
    }
}
