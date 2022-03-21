using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobotScriptforSc : MonoBehaviour
{
    public GameObject goL1;
    public GameObject goL2;
    public GameObject Laser;
    public GameObject F;
    float life;
    float px;
    float py;
    float hod;
    float zam;
    float tactik;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D Robot = GetComponent<Rigidbody2D>();
        life = 50;
        tactik = Random.Range(0, 2);
        if (tactik!=0)
        {
        px = Random.Range(-90, 0);
        py = Random.Range(-35, 45);
        }
        else
        {
            py = Random.Range(-35, 45);
            py = Random.Range(60, 85);
        }

        hod = 0;
        zam = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
        {
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
                    cur = Instantiate(Laser, goL1.transform.position, Quaternion.Slerp(goL1.transform.rotation, targetRotationL1, 1));
                    cur.GetComponent<Rigidbody2D>().velocity = (new Vector3(goArray[i].transform.position.x, goArray[i].transform.position.y, 0) - cur.transform.position).normalized * 60;
                    cur = Instantiate(Laser, goL2.transform.position, Quaternion.Slerp(goL2.transform.rotation, targetRotationL2, 1));
                    cur.GetComponent<Rigidbody2D>().velocity = (new Vector3(goArray[i].transform.position.x, goArray[i].transform.position.y, 0) - cur.transform.position).normalized * 60;
                    Robot.velocity = new Vector3(0, 0, 0);
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
                Robot.velocity = (new Vector3(px, py, 0) - transform.position).normalized * 15;
            }

        }
        if ((((transform.position.x - px <= 1) && (transform.position.x > px)) || ((transform.position.x - px >= -1) && (transform.position.x < px))) && (((transform.position.y - py <= 1) && (transform.position.y > py)) || ((transform.position.y - py >= -1) && (transform.position.y < py))))
        {
            if (tactik != 0)
            {
                px = Random.Range(-90, 0);
                py = Random.Range(-35, 45);
            }
            else
            {
                py = Random.Range(-35, 45);
                py = Random.Range(60, 85);
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
        if (other.tag == "Robots")
        {
            if (tactik != 0)
            {
                px = Random.Range(-90, 0);
                py = Random.Range(-35, 45);
            }
            else
            {
                py = Random.Range(-35, 45);
                py = Random.Range(60, 85);
            }
        }
        if (other.tag == "Snar")
        {
            life -= 25;
        }
        if (other.tag == "Bag")
        {
            zam = Time.time + 2;
            GetComponent<Rigidbody2D>().velocity = (new Vector3(px, py, 0) - transform.position).normalized * 5;
        }
    }

}