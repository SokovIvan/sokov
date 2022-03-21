using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocAS2 : MonoBehaviour
{
    public GameObject exp;
    GameObject target;
    float time2;
    float angle;
    // Start is called before the first frame update
    void Start()
    {
        time2 = Time.time + 10;
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z );
    }

    // Update is called once per frame
    void Update()
    {
        if (time2 == Time.time)
        {
            Instantiate(exp, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Robots")
        {
            Instantiate(exp, transform.position, transform.rotation);
            Destroy(gameObject);
        }

    }
}