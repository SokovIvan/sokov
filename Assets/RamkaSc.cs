using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RamkaSc : MonoBehaviour
{
    public LineRenderer lr;
    float n;
    Vector3 mousePos;
    Vector3 mousePosClick1;
    Vector3 mousePosClick2;
    // Start is called before the first frame update
    void Start()
    {
        n = 1;
        lr = GetComponent<LineRenderer>(); 
        lr.enabled = true;

    }

    // Update is called once per frame
    void Update()
    {
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if ((Input.GetMouseButtonDown(0)) && (n == 1))
        {
            mousePosClick1 = mousePos;
            n = 2;
            lr.enabled = true;
        }
        else if ((Input.GetMouseButtonUp(0)) && (n == 2))
        {
            
            mousePosClick2 = mousePos;
            n = 1;
            mousePosClick1 = mousePos;
            mousePosClick2 = mousePos;
        }
        if (n == 2)
        {
            lr.enabled = true;
            lr.SetPosition(0, mousePosClick1);
        lr.SetPosition(1, new Vector3(mousePosClick1.x, mousePos.y,0));
        lr.SetPosition(2, mousePos);
        lr.SetPosition(3, new Vector3(mousePos.x, mousePosClick1.y, 0));
        lr.SetPosition(4, mousePosClick1);
        }
        else
        {
            lr.enabled = false;
        }

    }
}
