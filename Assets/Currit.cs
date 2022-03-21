using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Currit : MonoBehaviour
{
    Vector3 mousep1;
    Vector3 mousep2;
    // Start is called before the first frame update
    void Start()
    {
        mousep1 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
    }

    // Update is called once per frame
    void Update()
    {
        mousep2 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        /*if ((mousep2.y> mousep1.y)&&(transform.rotation.y<15))
        {
            transform.Rotate(1,0,0);
        }
        if ((mousep2.y < mousep1.y)&& (transform.rotation.y * Mathf.Rad2Deg > -15))
        {
            transform.Rotate(-1, 0, 0);
        }
        if ((mousep2.x > mousep1.x)&& (transform.rotation.x * Mathf.Rad2Deg < 15))
        {
            transform.Rotate(0, 1, 0);
        }
        if ((mousep2.x < mousep1.x)&& (transform.rotation.x*Mathf.Rad2Deg >-15))
        {
            transform.Rotate(0, -1, 0);
        }*/
        mousep1 = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        transform.rotation =  Quaternion.Euler(mousep1.y*2, mousep1.x*2, 0);
    }
}
