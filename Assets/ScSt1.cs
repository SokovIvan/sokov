using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScSt1 : MonoBehaviour
{
    float x;
    public GameObject g;
    // Start is called before the first frame update
    void Start()
    {
        x = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKeyDown && x==1)
        {            
            Application.LoadLevel(5);
        }
         else if (Input.anyKeyDown)
        {
            x = 1;
            g.SetActive(false);
        }

        
    }
}
