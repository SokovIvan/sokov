using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class OkSc : MonoBehaviour
{
    public Slider slider;
    float life;    
    // Start is called before the first frame update
    void Start()
    {        
        life = 500;
        slider.maxValue = 500;
        GameCon.okohAsN(1);
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = life;
        if (life <= 0)
        {
            GameCon.okohAsN(-1);            
            Destroy(gameObject);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Laser")
        {
            life -= 1;
        }
        if (collision.tag == "Robots")
        {
            life = 0;
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Laser")
        {
            life -= 1;
        }
        if (collision.tag == "Robots")
        {
            life -= 1;
        }
    }
}
