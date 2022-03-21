using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class МирныйСкрипт: MonoBehaviour
{
    public Vector2[] points;     
    float life;
    float px;
    float py;
    float hod;
    float zam;
    int xx = 0;
    public Animator anim;
    // Start is called before the first frame update

    void Start()
    {
        anim = GetComponent<Animator>();
        Rigidbody2D Robot = GetComponent<Rigidbody2D>();
        life = 50;
        //px = Random.Range(-15, 90);
        //py = Random.Range(-60, 60);
        hod = 0;
        zam = 0;
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Flag");
        GameObject a = gameObjects[Random.Range(0, gameObjects.Length)];
        //px = a.transform.position.x;
        //py = a.transform.position.y;
        px = points[xx].x;
        py = points[xx].y;

    }

    // Update is called once per frame
    void Update()
    {   
 
        if (life <= 0)
        {            
            Destroy(gameObject);
        }
        float angle;
        hod = 0;
        GameObject[] goArray;
        Rigidbody2D Robot = GetComponent<Rigidbody2D>();
        Robot.angularVelocity = 0;
        if (hod < 1)
        {
            if ((transform.position - new Vector3(px, py, 0)).sqrMagnitude >= 1)
            {
                angle = Mathf.Atan2(transform.position.y - py, transform.position.x - px) * Mathf.Rad2Deg+90;
                var targetRotationS = Quaternion.Euler(new Vector3(0f, 0f, angle));
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotationS, 1);
            }
            if (zam < Time.time)
            {
                if ((transform.position - new Vector3(px, py, 0)).sqrMagnitude >= 1)
                {
                    anim.SetBool("Go",true);
                    Robot.velocity = (new Vector3(px, py, 0) - transform.position).normalized * 10;
                }
                else
                {
                    if (xx < points.Length-1)
                    {
                        xx++;
                    }
                    else
                    {
                        xx = 0;
                    }
                    px = points[xx].x;        
                    py = points[xx].y;    
                    anim.SetBool("Go",false);
                    Robot.velocity = new Vector3(0, 0, 0);
                }
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {
            life -= 1;
        }
        if (other.tag == "Snar2")
        {
            life -= 25;
        }
        // if (other.tag == "Allies")
        // {
        //     float x = transform.position.x + Random.Range(-2, 2);
        //     float y = transform.position.y + +Random.Range(-2, 2);
        //    transform.position = new Vector3(x, y, 0);
        //}
        if (other.tag == "River")
        {
            float x = transform.position.x;
            float y = transform.position.y + 1;
            transform.position = new Vector3(x, y, 0);
        }
        if (other.tag == "Bag")
        {
            zam = Time.time + 2;
            GetComponent<Rigidbody2D>().velocity = (new Vector3(px, py, 0) - transform.position).normalized * 10;
        }
        if (other.tag == "Explosion")
        {
            life -= 10;
        }
        if (other.tag == "Robots")
        {
            life -= 50;
        }

    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {
            life -= 1;
        }
        if (other.tag == "Explosion")
        {
            life -= 10;
        }
    }
}


