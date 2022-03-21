using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallSc : MonoBehaviour
{
    public GameObject s1;
    public GameObject s2;
    public GameObject s3;
    float time2;
    float n;
    // Start is called before the first frame update
    void Start()
    {
        n = 1;
        time2 = Time.time+300;
    }

    // Update is called once per frame
    void Update()
    {
        if (time2 <= Time.time)
        {
            time2 = Time.time + 300;
            n++;
            if (n == 2)
            {
                s1.SetActive(false);
                s2.SetActive(true);
            }
            if (n == 3)
            {
                s2.SetActive(false);
                s3.SetActive(true);
                n = 0;
            }
            if (n == 1)
            {
                s3.SetActive(false);
                s1.SetActive(true);
            }
        }
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Snar") 
        { 
        Destroy(collision);
        }
    }
}
