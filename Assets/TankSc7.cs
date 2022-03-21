using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TankSc7 : MonoBehaviour
{
    public GameObject B;
    public GameObject Laser;
    public GameObject F;
    public GameObject Bj;
    Vector3 Base;
    float life;
    float px;
    float py;
    float hod;
    float zam;
    public GameObject point;
    // Start is called before the first frame update
    void Start()
    {
        point = GameObject.Find("Point");
        Rigidbody2D Robot = GetComponent<Rigidbody2D>();
        life = 250;
        px = point.transform.position.x + Random.Range(-20, 20);
        py = point.transform.position.y + Random.Range(-20, 20);
        hod = 0;
        zam = 0;
        Base = new Vector3(-8, 93, 0);
    }
    // Update is called once per frame
    void Update()
    {        
        B.transform.position = Bj.transform.position;
        Rigidbody2D RobotB = B.GetComponent<Rigidbody2D>();
        if (life <= 0)
        {
            Instantiate(F, transform.position, Quaternion.Slerp(transform.rotation, transform.rotation, 1));
            Destroy(B);
            Destroy(gameObject);
        }
        float angle;
        hod = 0;
        GameObject[] goArray;
        Rigidbody2D Robot = GetComponent<Rigidbody2D>();
        goArray = GameObject.FindGameObjectsWithTag("Allies");
        for (int i = 0; i < goArray.Length; i++)
        {
            if ((goArray[i].transform.position - transform.position).sqrMagnitude <= 650)
            {
                GameObject cur;
                hod = hod + 1;
                if (hod == 1)
                {
                    angle = Mathf.Atan2(B.transform.position.y - goArray[i].transform.position.y, B.transform.position.x - goArray[i].transform.position.x) * Mathf.Rad2Deg;
                    var targetRotationF = Quaternion.Euler(new Vector3(0f, 0f, angle));
                    B.transform.rotation = Quaternion.Slerp(B.transform.rotation, targetRotationF, 1);
                    Laser.SetActive(true);
                    Robot.velocity = new Vector3(0, 0, 0);
                    Robot.angularVelocity = 0;
                    RobotB.velocity = new Vector3(0, 0, 0);
                    RobotB.angularVelocity = 0;
                }

            }
        }
        float hod2 = 0;
        goArray = GameObject.FindGameObjectsWithTag("Primanka");
        for (int i = 0; i < goArray.Length; i++)
        {
            if ((goArray[i].transform.position - transform.position).sqrMagnitude <= 800)
            {
                hod2 = hod2 + 1;
                if (hod2 == 1)
                {
                    px = goArray[i].transform.position.x;
                    py = goArray[i].transform.position.y;
                }
            }
        }
        if (hod < 1)
        {
            Laser.SetActive(false);
            B.transform.rotation = transform.rotation;
            angle = Mathf.Atan2(transform.position.y - py, transform.position.x - px) * Mathf.Rad2Deg;
            var targetRotationS = Quaternion.Euler(new Vector3(0f, 0f, angle));
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotationS, 1);
            if (zam < Time.time)
            {
                Robot.velocity = (new Vector3(px, py, 0) - transform.position).normalized * 5;
                RobotB.velocity = (new Vector3(px, py, 0) - transform.position).normalized * 5;
            }

        }
        if ((((transform.position.x - px <= 1) && (transform.position.x > px)) || ((transform.position.x - px >= -1) && (transform.position.x < px))) && (((transform.position.y - py <= 1) && (transform.position.y > py)) || ((transform.position.y - py >= -1) && (transform.position.y < py))))
        {
            px = point.transform.position.x + Random.Range(-40, 40);
            py = point.transform.position.y + Random.Range(-40, 40);
            if (GameCon.robs() > 5)
            {
                px = GameObject.FindGameObjectWithTag("PlBA").transform.position.x + Random.Range(-30, 30);
                py = GameObject.FindGameObjectWithTag("PlBA").transform.position.y + Random.Range(-30, 30);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "River")
        {
            float x = transform.position.x;
            float y = transform.position.y + 1;
            transform.position = new Vector3(x, y, 0);
        }
        if (other.tag == "Snar")
        {
            life -= 25;
        }
        if (other.tag == "Explosion")
        {
            life -= 50;
            Destroy(other);
        }
        if (other.tag == "Allies")
        {
            life -= 10;
        }
        if (other.tag == "Bag")
        {
            zam = Time.time + 2;
            GetComponent<Rigidbody2D>().velocity = (new Vector3(px, py, 0) - transform.position).normalized * 2;
            B.GetComponent<Rigidbody2D>().velocity = (new Vector3(px, py, 0) - transform.position).normalized * 2;
        }
    }

}
