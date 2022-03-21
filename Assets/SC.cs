using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SC : MonoBehaviour
{
    float tim;
    // Start is called before the first frame update
    void Start()
    {
        tim = 0;
    }

    // Update is called once per frame
    void Update()
    {
        tim += 1;
        if (tim == 2)
        {
            Destroy(gameObject);
        }
    }
}
