using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sound1 : MonoBehaviour
{
    float time2;
    public GameObject sn;
    // Start is called before the first frame update
    void Start()
    {
        time2 = Time.time;    
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - time2 > 600)
        {
            sn.SetActive(true);
            Destroy(gameObject);
        }
    }
}
