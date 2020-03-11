using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchScript : MonoBehaviour
{
    public List<GameObject> cubes = new List<GameObject>();

    void Update()
    {
        if(cubes.Count > 0)
        {
            if (Input.GetMouseButtonDown(0))
            {
                var ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, 50))
                {
                    if (hit.collider.tag == "Cube")
                    {
                        Debug.Log("Cube");

                        CollisionTest ct = cubes[0].GetComponentInChildren<CollisionTest>();
                        Debug.Log(ct.state.ToString());
                        testclick();
                    }
                }
            }
        }
    }

    public void testclick()
    {

    }
}
