using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaBRSc : MonoBehaviour
{
    public GameObject robotR;
    public GameObject robot;
    public GameObject robotTSm;
    public GameObject F;
    public GameObject ZZZ;
    float timel;
    float life;
    float time2;
    float zak1;
    float zakch1;
    // Start is called before the first frame update
    void Start()
    {
        gameObject.GetComponentInChildren<SpriteRenderer>().sortingOrder = -1;
        ZZZ.GetComponent<SpriteRenderer>().sortingOrder = -1;
        life = 500;
        timel = 0;
        time2 = Time.time;
        zak1 = -1;
        zakch1 = 0;
        
    }

    // Update is called once per frame
    void Update()
    {

            if (life <= 0)
        {
            GameCon.FactM();
            Instantiate(F, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
        if ((zak1 <= Time.time) && (zakch1 == 1))
        {
            zakch1 = 0;
                    if (GameCon.strar() == 2)
            {
             Instantiate(robot, transform.position, Quaternion.identity);
                Instantiate(robotTSm, transform.position, Quaternion.identity);
                Instantiate(robotTSm, transform.position, Quaternion.identity);
            }
            if (GameCon.strar() == 1)
            {
                Instantiate(robotR, transform.position, Quaternion.identity);
            }
            ZZZ.SetActive(false);
        }
        if (((Time.time - time2) - timel >= 30) && (GameCon.ress() >= 10)&&GameCon.buils()>4)
        {
            GameCon.ot();
            GameCon.ot();
            GameCon.ot();
            GameCon.ot();
            GameCon.ot();
            GameCon.ot();
            GameCon.ot();
            GameCon.ot();
            GameCon.ot();
            GameCon.ot();
            timel = Time.time;
            zakch1 = 1;
            zak1 = Time.time + 29;
            ZZZ.SetActive(true);
        }  
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Snar")
        {
            life -= 25;
        }
        if (other.tag == "Explosion")
        {
            life -= 50;
            Destroy(other);
        }
    }

}