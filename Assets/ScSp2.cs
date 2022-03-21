using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScSp2 : MonoBehaviour
{
    public GameObject goL1;
    public GameObject goL2;
    public GameObject goL3;
    public GameObject goL4;
    public GameObject Laser;
    public GameObject F;
    Vector3 Base;
    float life;
    float px;
    float py;
    float hod;    
    float zam;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D Robot = GetComponent<Rigidbody2D>();
        life = 500;
        px = Random.Range(-10, 10);
        py = Random.Range(-90, 0);
        hod = 0;
        zam = 0;
        Base = new Vector3(-8, 93, 0);
        GameCon.Ssplus();
    }
    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
        {
            GameCon.Ssminus();
            Instantiate(F, transform.position, Quaternion.Slerp(transform.rotation, transform.rotation, 1));            
            Destroy(gameObject);
        }
        float angle;
        hod = 0;
        GameObject[] goArray;
        Rigidbody2D Robot = GetComponent<Rigidbody2D>();
        goArray = GameObject.FindGameObjectsWithTag("Allies");
        for (int i = 0; i < goArray.Length; i++)
        {
            if ((goArray[i].transform.position - transform.position).sqrMagnitude <= 450)
            {
                GameObject cur;
                hod = hod + 1;
                if (hod == 1)
                {
                    angle = Mathf.Atan2(transform.position.y - goArray[i].transform.position.y, transform.position.x - goArray[i].transform.position.x) * Mathf.Rad2Deg;
                    var targetRotationF = Quaternion.Euler(new Vector3(0f, 0f, angle));
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotationF, 1);
                    angle = Mathf.Atan2(goL1.transform.position.y - goArray[i].transform.position.y, goL1.transform.position.x - goArray[i].transform.position.x) * Mathf.Rad2Deg;
                    var targetRotationL1 = Quaternion.Euler(new Vector3(0f, 0f, angle));
                    goL1.transform.rotation = Quaternion.Slerp(goL1.transform.rotation, targetRotationL1, 1);
                    angle = Mathf.Atan2(goL2.transform.position.y - goArray[i].transform.position.y, goL2.transform.position.x - goArray[i].transform.position.x) * Mathf.Rad2Deg;
                    var targetRotationL2 = Quaternion.Euler(new Vector3(0f, 0f, angle));
                    goL2.transform.rotation = Quaternion.Slerp(goL2.transform.rotation, targetRotationL2, 1);
                    angle = Mathf.Atan2(goL3.transform.position.y - goArray[i].transform.position.y, goL3.transform.position.x - goArray[i].transform.position.x) * Mathf.Rad2Deg;
                    var targetRotationL3 = Quaternion.Euler(new Vector3(0f, 0f, angle));
                    goL3.transform.rotation = Quaternion.Slerp(goL3.transform.rotation, targetRotationL3, 1);
                    angle = Mathf.Atan2(goL4.transform.position.y - goArray[i].transform.position.y, goL4.transform.position.x - goArray[i].transform.position.x) * Mathf.Rad2Deg;
                    var targetRotationL4 = Quaternion.Euler(new Vector3(0f, 0f, angle));
                    goL4.transform.rotation = Quaternion.Slerp(goL4.transform.rotation, targetRotationL4, 1);
                    cur = Instantiate(Laser, goL1.transform.position, Quaternion.Slerp(goL1.transform.rotation, targetRotationL1, 1));
                    cur.GetComponent<Rigidbody2D>().velocity = (new Vector3(goArray[i].transform.position.x, goArray[i].transform.position.y, 0) - cur.transform.position).normalized * 60;
                    cur = Instantiate(Laser, goL2.transform.position, Quaternion.Slerp(goL2.transform.rotation, targetRotationL2, 1));
                    cur.GetComponent<Rigidbody2D>().velocity = (new Vector3(goArray[i].transform.position.x, goArray[i].transform.position.y, 0) - cur.transform.position).normalized * 60;
                    cur = Instantiate(Laser, goL3.transform.position, Quaternion.Slerp(goL3.transform.rotation, targetRotationL3, 1));
                    cur.GetComponent<Rigidbody2D>().velocity = (new Vector3(goArray[i].transform.position.x, goArray[i].transform.position.y, 0) - cur.transform.position).normalized * 60;
                    cur = Instantiate(Laser, goL4.transform.position, Quaternion.Slerp(goL4.transform.rotation, targetRotationL4, 1));
                    cur.GetComponent<Rigidbody2D>().velocity = (new Vector3(goArray[i].transform.position.x, goArray[i].transform.position.y, 0) - cur.transform.position).normalized * 60;
                    Robot.velocity = new Vector3(0, 0, 0);
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
            angle = Mathf.Atan2(transform.position.y - py, transform.position.x - px) * Mathf.Rad2Deg;
            var targetRotationS = Quaternion.Euler(new Vector3(0f, 0f, angle));
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotationS, 1);
            if (zam < Time.time)
            {
                Robot.velocity = (new Vector3(px, py, 0) - transform.position).normalized * 3;
            }

        }
        if ((((transform.position.x - px <= 1) && (transform.position.x > px)) || ((transform.position.x - px >= -1) && (transform.position.x < px))) && (((transform.position.y - py <= 1) && (transform.position.y > py)) || ((transform.position.y - py >= -1) && (transform.position.y < py))))
        {
            px = Random.Range(-10, 10);
            py = Random.Range(-90, 0);
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
            life -= 50;
        }
        if (other.tag == "Bag")
        {
            zam = Time.time + 2;
            GetComponent<Rigidbody2D>().velocity = (new Vector3(px, py, 0) - transform.position).normalized * 2;
        }
    }

}

