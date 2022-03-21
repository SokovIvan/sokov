using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class PoeSc6 : MonoBehaviour
{
    public GameObject Exp;
    public GameObject Strange;
    public Text l;
    float time;
    // Start is called before the first frame update
    // Update is called once per frame
    private void Start()
    {
        transform.position = new Vector3(-293,331,0);
        time = 180;
    }
    void Update()
    {
        if(time - Time.timeSinceLevelLoad<=0)
        {
            GetComponent<Rigidbody2D>().velocity = new Vector2(20, 0);
        }
        if(time - Time.timeSinceLevelLoad >= 0)
        {
        l.text = "Времени до прибытия поезда:"+((int)(time-Time.timeSinceLevelLoad));
        }
            
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "BombPlace")
        {
            if(GameConSc6.turAsY() >= 3)
            {
            Instantiate(Exp,transform.position,transform.rotation);
            Instantiate(Strange, transform.position, transform.rotation);
            GetComponent<Rigidbody2D>().velocity = new Vector2(0, 0);
            GameConSc6.turAsN(20);
            Destroy(gameObject);
            Destroy(collision);
            }
            else
            {
                GameConSc6.turAsN(-20);
            }
        }
    }
}
