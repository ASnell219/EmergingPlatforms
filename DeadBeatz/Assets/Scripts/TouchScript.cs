using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchScript : MonoBehaviour
{
    public ListManager lm;
    int layermask = 1 << 8;

    void Update()
    {

        if(lm.gameObjects.Count > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 20, layermask) && hit.collider.gameObject == this.gameObject)
                {
                    if(hit.collider.tag == "CubeLeft")
                    {
                        GameObject go = lm.GetFirstIndex();
                        MonsterObject mo = go.GetComponentInChildren<MonsterObject>();
                        Debug.Log(mo.currentState);
                        //call score on object

                        lm.RemoveFromList(go);
                        go.SetActive(false);
                    }
                    else if(hit.collider.tag == "CubeMid")
                    {
                        GameObject go = lm.GetFirstIndex();
                        MonsterObject mo = go.GetComponentInChildren<MonsterObject>();
                        Debug.Log(mo.currentState);
                        //call score on object

                        lm.RemoveFromList(go);
                        go.SetActive(false);
                    }
                }
            }
        }
    }
}
