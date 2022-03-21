using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScF : MonoBehaviour
{
    float tim;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Quaternion.identity;
        tim = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - tim > 5)
        {
            Destroy(gameObject);
        }
    }
}
