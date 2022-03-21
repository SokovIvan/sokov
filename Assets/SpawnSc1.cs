using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSc1 : MonoBehaviour
{
    public GameObject s;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Allies")
        {
            Instantiate(s,transform.position,transform.rotation);
            Instantiate(s, transform.position, transform.rotation);
            Instantiate(s, transform.position, transform.rotation);
            Destroy(gameObject);
        }
    }
}
