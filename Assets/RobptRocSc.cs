using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RobptRocSc : MonoBehaviour
{
    public GameObject G1;
    public GameObject G2;
    public GameObject Laser;
    public GameObject F;
    float life;
    float px;
    float py;
    float hod;
    float zam;
    float firet;
    GameObject Ggoto;
    // Start is called before the first frame update
    void Start()
    {      
        life = 75;
        hod = 0;
        GameObject[] goArray;
        goArray = GameObject.FindGameObjectsWithTag("Pl1");
        Ggoto = goArray[Random.Range(0, goArray.Length)];
        px = Ggoto.transform.position.x;
        py = Ggoto.transform.position.y;
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
            if ((goArray[i].transform.position - transform.position).sqrMagnitude <= 4000)
            {       
                hod ++;
                if (hod == 1)
                {
                    angle = Mathf.Atan2(transform.position.y - goArray[i].transform.position.y, transform.position.x - goArray[i].transform.position.x) * Mathf.Rad2Deg;
                    var targetRotationF = Quaternion.Euler(new Vector3(0f, 0f, angle));
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotationF, 1);
                    if (Time.time > firet) 
                    {
                    Instantiate(Laser, G1.transform.position, Quaternion.identity);
                    Instantiate(Laser, G2.transform.position, Quaternion.identity);
                    firet = Time.time + 2;
                    }

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
        if ((transform.position - new Vector3(px, py, 0)).sqrMagnitude <= 1)
        {
            Robot.velocity = (new Vector3(px, py, 0) - transform.position).normalized * 0;
            Robot.angularVelocity =  0;
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
        if (other.tag == "Bag")
        {
            zam = Time.time + 2;
            GetComponent<Rigidbody2D>().velocity = (new Vector3(px, py, 0) - transform.position).normalized * 5;
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
    }

}