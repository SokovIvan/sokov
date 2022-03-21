using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PulaSc2 : MonoBehaviour
{
    float tim;
    // Start is called before the first frame update
    void Start()
    {
        tim = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time - tim > 3)
        {
            Destroy(gameObject);
        }

    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Robots")
        {
            Destroy(gameObject);
        }

    }
}
