using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomL : MonoBehaviour
{
    Animator a;
    // Start is called before the first frame update
    void Start()
    {
        a = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Allies")
        {
a.SetBool("New Bool", true);
        }
        
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Allies")
        {
            a.SetBool("New Bool", false);
        }
    }
}
