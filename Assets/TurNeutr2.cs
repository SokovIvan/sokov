using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurNeutr2 : MonoBehaviour
{
    float maxValue;
    public Color color = Color.red;
    public int width;
    public GameObject goL1;
    public GameObject goL2;
    public GameObject Laser;
    public GameObject F;
    float life;
    float px;
    float py;
    float hod;
    float firet;
    float zam;
    float n;
    Vector3 poss;
    float timt;
    // Start is called before the first frame update
    void Start()
    {
        timt = Time.time;
        poss = transform.position;
        Rigidbody2D Robot = GetComponent<Rigidbody2D>();
        life = 200;
        hod = 0;
        firet = 0;
        zam = 0;
        n = 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = poss;
        if ((life <= 0))
        {
            Instantiate(F, transform.position, Quaternion.Slerp(transform.rotation, transform.rotation, 1));
            Destroy(gameObject);
        }
        float angle;
        hod = 0;
        GameObject[] goArray;
        Rigidbody2D Robot = GetComponent<Rigidbody2D>();
        Robot.angularVelocity = 0;
        /*goArray = GameObject.FindGameObjectsWithTag("Robots");
        for (int i = 0; i < goArray.Length; i++)
        {
            if (((goArray[i].transform.position - transform.position).sqrMagnitude <= 650) && (goArray[i].transform.position != transform.position))
            {
                GameObject cur;
                hod = hod + 1;
                if ((hod == 1) && (Time.time - firet > 0.3))
                {
                    firet = Time.time;
                    angle = Mathf.Atan2(transform.position.y - goArray[i].transform.position.y, transform.position.x - goArray[i].transform.position.x) * Mathf.Rad2Deg;
                    var targetRotationF = Quaternion.Euler(new Vector3(0f, 0f, angle));
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotationF, 1);
                    angle = Mathf.Atan2(goL1.transform.position.y - goArray[i].transform.position.y, goL1.transform.position.x - goArray[i].transform.position.x) * Mathf.Rad2Deg - 90;
                    var targetRotationL1 = Quaternion.Euler(new Vector3(0f, 0f, angle));
                    goL1.transform.rotation = Quaternion.Slerp(goL1.transform.rotation, targetRotationL1, 1);
                    cur = Instantiate(Laser, goL2.transform.position, Quaternion.Slerp(goL1.transform.rotation, targetRotationL1, 1));
                    cur.GetComponent<Rigidbody2D>().velocity = (new Vector3(goArray[i].transform.position.x, goArray[i].transform.position.y, 0) - cur.transform.position).normalized * 40;
                    Robot.velocity = new Vector3(0, 0, 0);
                }

            }
        }*/
        Robot.angularVelocity = 0;
        goArray = GameObject.FindGameObjectsWithTag("Allies");
        for (int i = 0; i < goArray.Length; i++)
        {
            if (((goArray[i].transform.position - transform.position).sqrMagnitude <= 650) && (goArray[i].transform.position != transform.position))
            {
                GameObject cur;
                hod = hod + 1;
                if ((hod == 1) && (Time.time - firet > 0.3))
                {
                    firet = Time.time;
                    angle = Mathf.Atan2(transform.position.y - goArray[i].transform.position.y, transform.position.x - goArray[i].transform.position.x) * Mathf.Rad2Deg;
                    var targetRotationF = Quaternion.Euler(new Vector3(0f, 0f, angle));
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotationF, 1);
                    angle = Mathf.Atan2(goL1.transform.position.y - goArray[i].transform.position.y, goL1.transform.position.x - goArray[i].transform.position.x) * Mathf.Rad2Deg - 90;
                    var targetRotationL1 = Quaternion.Euler(new Vector3(0f, 0f, angle));
                    goL1.transform.rotation = Quaternion.Slerp(goL1.transform.rotation, targetRotationL1, 1);
                    cur = Instantiate(Laser, goL2.transform.position, Quaternion.Slerp(goL1.transform.rotation, targetRotationL1, 1));
                    cur.GetComponent<Rigidbody2D>().velocity = (new Vector3(goArray[i].transform.position.x, goArray[i].transform.position.y, 0) - cur.transform.position).normalized * 40;
                    Robot.velocity = new Vector3(0, 0, 0);
                }

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
        if (other.tag == "Laser")
        {
            life -= 1;
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
        if (other.tag == "Snar")
        {
            life -= 50;
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
