using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchScript : MonoBehaviour
{
    public ListManager lm;
    //public Score sc;
    int layermask = 1 << 8;

    void Update()
    {

        if(lm.gameObjects.Count > 0)
        {
            if (Input.GetMouseButtonDown(0) || Input.touchCount > 0)
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 20, layermask) && hit.collider.gameObject == this.gameObject)
                {
                    GameObject go = lm.GetFirstIndex();
                    MonsterObject mo = go.GetComponentInChildren<MonsterObject>();
                    Debug.Log(mo.currentState);
                    //sc.changeScore(mo.currentState.ToString());
                    //call score on object

                    lm.RemoveFromList(go);
                    go.SetActive(false);

                }
            }
        }
    }
}
