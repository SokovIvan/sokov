using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScBase2 : MonoBehaviour
{
    public GameObject vic;
    public GameObject robot;
    public GameObject spider;
    public GameObject BuilderR;
    public GameObject gm;
    public GameObject ZZZ;
    public GameObject ZZZ2;
    public GameObject ZZZ3;
    float timel;
    float timelB;
    float timelS;
    float life;
    float time2;
    float zak1;
    float zak2;
    float zak3;
    float zakch1;
    float zakch2;
    float zakch3;
    float timevv;
    bool timeOne;
    // Start is called before the first frame update
    void Start()
    {
        timeOne = true;
        timevv = 0;
        gameObject.GetComponentInChildren<SpriteRenderer>().sortingOrder = -1;
        ZZZ.GetComponent<SpriteRenderer>().sortingOrder = -1;
        ZZZ2.GetComponent<SpriteRenderer>().sortingOrder = -1;
        ZZZ3.GetComponent<SpriteRenderer>().sortingOrder = -1;
        life = 1000;
        timel = Time.time - time2 - 30;
        timelB = Time.time - time2 - 15;
        timelS = Time.time - time2 - 15;
        time2 = Time.time;
        zak1 = -1;
        zak2 = -1;
        zak3 = -1;
        zakch1 = 0;
        zakch2 = 0;
        zakch3 = 0;
    }

    // Update is called once per frame
    void Update()
    {
    
        if (life <= 0)
        {
           if(SceneManager.GetActiveScene().name=="Battle"|| SceneManager.GetActiveScene().name == "Battle2")
            {
             vic.SetActive(true);
                if (timeOne)
                {
                Statistics stat = GameObject.Find("Stat").GetComponent<Statistics>();
                stat.t = 0;
                timevv = Time.time;
                timeOne = false;
                }                
                if (Time.time-timevv > 2)
                {
                Application.LoadLevel(7);
                Destroy(gameObject);
                }
                
            }
            else
            {
            Destroy(gameObject);
            }
            

            
        }
        if ((zak1<=Time.time)&&(zakch1 ==1))
        {
            zakch1 = 0;
            Instantiate(robot, transform.position, Quaternion.identity);
            ZZZ.SetActive(false);
        }
        if ((zak2 <= Time.time) && (zakch2 == 1))
        {
            zakch2 = 0;
            Instantiate(BuilderR, transform.position, Quaternion.identity);
            ZZZ2.SetActive(false);
        }
        if ((zak3 <= Time.time) && (zakch3 == 1))
        {
            zakch3 = 0;
            Instantiate(spider, transform.position, Quaternion.identity);
            ZZZ3.SetActive(false);
        }
        if (((Time.time - time2) - timel >= 15)&&((((GameCon.ress()>=4)&& (GameCon.buils() >= 3))||((GameCon.ress() >= 15) && (GameCon.buils() >= 1)))||((GameCon.ress() >= 5) && (GameCon.robs() < 1))))
      {
          GameCon.ot();
          GameCon.ot();
          GameCon.ot();
          GameCon.ot(); 
          timel = Time.time;
          zakch1 = 1;
          zak1 = Time.time + 14;
          ZZZ.SetActive(true);
      }
        if (((Time.time - time2) - timelS >= 30) &&(((GameCon.ress() >= 100) && (GameCon.buils() >= 1)) ||((GameCon.ress() >= 15) && (GameCon.buils() >= 5) && (GameCon.strar() == 3) && (GameCon.robs() >= 6))))
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
            GameCon.ot();
            GameCon.ot();
            GameCon.ot();
            GameCon.ot();
            GameCon.ot();
            timelS = Time.time - time2;
            zakch3 = 1;
            zak3 = Time.time + 29;
            ZZZ3.SetActive(true);
        }
        if ((((Time.time - time2) - timelB >= 15) && (GameCon.ress() > 0)&&(GameCon.buils()<6))||(zakch2==0&& GameCon.buils() < 6))
        {
            GameCon.ot();
            timelB = Time.time - time2;
            zak2 = Time.time + 14;
            zakch2 = 1;
            ZZZ2.SetActive(true);
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
        }
    }
}
