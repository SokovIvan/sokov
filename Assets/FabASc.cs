using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FabASc : MonoBehaviour
{
    public GameObject f;
    public GameObject mut;
    float life;
    float timep;
    // Start is called before the first frame update
    void Start()
    {
        life = 3;
    }
    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
        {
            Instantiate(f,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
        if (Time.time - timep > 30)
        {
            timep = Time.time;
            Instantiate(mut, transform.position, Quaternion.identity);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Snar")
        {
            life -= 1;
            
        }
    }
}
