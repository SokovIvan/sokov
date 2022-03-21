using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SmogSc : MonoBehaviour
{
    GameObject tt;
    private void Start()
    {
        GameObject[] gg = GameObject.FindGameObjectsWithTag("Allies");
        foreach (GameObject t in gg)
        {   
            if ((transform.position-t.transform.position).sqrMagnitude<=1)
            {
                tt = t; 
            }
        }

    }
    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0)|| Input.GetMouseButtonDown(1))
        {
            Destroy(gameObject);
        }
        transform.position = tt.transform.position;
    }
}
