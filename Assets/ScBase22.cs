using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ScBase22 : MonoBehaviour
{
    public GameObject robot;
    public GameObject gm;
    float timel;
    float life;
    float time2;
    float timevv;
    float n;

    // Start is called before the first frame update
    void Start()
    {
        n = 0;
        timevv = 0;
        life = 1000;
        timel = Time.time+15;
        time2 = Time.time;
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
        {            
            if (SceneManager.GetActiveScene().name == "Sc")
            {
                         if (n==0)
            {
                timevv = Time.timeSinceLevelLoad; 
                Statistics stat = GameObject.Find("Stat").GetComponent<Statistics>();
                stat.t = 0;
                n = 1;

            }
            if (Time.timeSinceLevelLoad-timevv>5)
            {
            Application.LoadLevel(3);
            Destroy(gameObject);
            }
            }
            else
            {
                Destroy(gameObject);
            }

        }
        if (timel <= Time.time)
      {
          timel = Time.time+15;
            if((Time.time - time2)>= 15)
            {
            Instantiate(robot, transform.position, Quaternion.identity);
            }
            if((Time.time - time2)>= 100)
            {
            Instantiate(robot, transform.position, Quaternion.identity);
            }
           if((Time.time - time2)>= 200)
            {
            Instantiate(robot, gm.transform.position, Quaternion.identity);

            }
            if ((Time.time - time2) >= 300)
            {
                Instantiate(robot, gm.transform.position, Quaternion.identity);
            }
            if ((Time.time - time2) >= 450)
            {
                Instantiate(robot, gm.transform.position, Quaternion.identity);
            }
            if ((Time.time - time2) >= 700)
            {
                Instantiate(robot, gm.transform.position, Quaternion.identity);
            }
            if ((Time.time - time2) >= 800)
           {
            Instantiate(robot, gm.transform.position, Quaternion.identity);
            Instantiate(robot, gm.transform.position, Quaternion.identity);
           }
            if ((Time.time - time2) >= 870)
            {
                timel = Time.time + 5;
                Instantiate(robot, gm.transform.position, Quaternion.identity);
                Instantiate(robot, gm.transform.position, Quaternion.identity);
                Instantiate(robot, gm.transform.position, Quaternion.identity);
                Instantiate(robot, gm.transform.position, Quaternion.identity);
                Instantiate(robot, gm.transform.position, Quaternion.identity);
                Instantiate(robot, gm.transform.position, Quaternion.identity);
                Instantiate(robot, gm.transform.position, Quaternion.identity);
                Instantiate(robot, gm.transform.position, Quaternion.identity);
                Instantiate(robot, gm.transform.position, Quaternion.identity);
                Instantiate(robot, gm.transform.position, Quaternion.identity);
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Snar")
        {
            life -= 25;
        }
    }
}

