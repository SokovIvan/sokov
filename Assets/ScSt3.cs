using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScSt3 : MonoBehaviour
{
    public GameObject c0;
    public GameObject c1;
    public GameObject c2;
    public GameObject c3;
    public GameObject c4;
    float tim;
    // Start is called before the first frame update
    void Start()
    {
        tim = Time.time;
        c1.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - tim > 5)
        {
            
            c1.SetActive(false);
            c2.SetActive(true);
        }
        if (Time.time - tim > 10)
        {
            c0.SetActive(false);
            c2.SetActive(false);
            c3.SetActive(true);
        }
        if (Time.time - tim > 15)
        {
            c3.SetActive(false);
            c4.SetActive(true);
        }
        if (Time.time - tim > 20)
        {
            Application.LoadLevel(6);
        }
    }
}
