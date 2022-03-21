using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class ЦарьСк : MonoBehaviour
{
    public GameObject ion;
    public GameObject message;
    public GameObject B;
    //public GameObject Laser;
    public GameObject F;
    public GameObject Bj;
    Vector3 Base;
    float life;
    float px;
    float py;
    float hod;
    float zam;
    public GameObject point;
    public GameObject but1;
    public GameObject but2;
    public GameObject mess;
    public Text text;
    public GameObject b1;
    public GameObject b2;
    public GameObject b3;
    public GameObject b4;
    float time;
    float t;
    float tineion;
    // Start is called before the first frame update
    void Start()
    {
        point = GameObject.Find("Point");
        Rigidbody2D Robot = GetComponent<Rigidbody2D>();
        life = 1200;
        px = point.transform.position.x + Random.Range(-50, 50);
        py = point.transform.position.y + Random.Range(-50, 50);
        hod = 0;
        zam = 0;
        Base = new Vector3(-8, 93, 0);
        
    }
    // Update is called once per frame
    void Update()
    {        
        //Rigidbody2D RobotB = B.GetComponent<Rigidbody2D>();
        if (life <= 0)
        {
            Destroy(b1);
            Destroy(b2);
            Destroy(b3);
            Destroy(b4);
            Instantiate(F, transform.position, Quaternion.Slerp(transform.rotation, transform.rotation, 1));
            message.SetActive(true);
            mess.SetActive(true);
            text.text = "Командующий!Нажимайте на кнопку!Уничтожьте роботов,пока не поздно!";
            but1.SetActive(true);
            but2.SetActive(true);
            t = 1;


        }
        if (t==1) 
        {             
            return;            
        }
        if (Time.timeSinceLevelLoad - tineion > 5)
        {
            tineion = Time.timeSinceLevelLoad;
            Instantiate(ion,new Vector3(Random.Range(-316, 316),Random.Range(-350, 350),0),Quaternion.identity);
        }
        float angle;
        hod = 0;
        GameObject[] goArray;
        Rigidbody2D Robot = GetComponent<Rigidbody2D>();
        goArray = GameObject.FindGameObjectsWithTag("Allies");
        for (int i = 0; i < goArray.Length; i++)
        {
            if ((goArray[i].transform.position - transform.position).sqrMagnitude <= 800)
            {                
                hod = hod + 1;
                if (hod == 1)
                {
                    angle = Mathf.Atan2(transform.position.y - goArray[i].transform.position.y, transform.position.x - goArray[i].transform.position.x) * Mathf.Rad2Deg-90;
                    var targetRotationF = Quaternion.Euler(new Vector3(0f, 0f, angle));
                    //transform.rotation = Quaternion.Slerp(transform.rotation, targetRotationF, 1);
                    angle = Mathf.Atan2(b1.transform.position.y - goArray[i].transform.position.y, b1.transform.position.x - goArray[i].transform.position.x) * Mathf.Rad2Deg - 90;
                    targetRotationF = Quaternion.Euler(new Vector3(0f, 0f, angle));
                    b1.transform.rotation = Quaternion.Slerp(b1.transform.rotation, targetRotationF, 1);
                    angle = Mathf.Atan2(b2.transform.position.y - goArray[i].transform.position.y, b2.transform.position.x - goArray[i].transform.position.x) * Mathf.Rad2Deg - 90;
                    targetRotationF = Quaternion.Euler(new Vector3(0f, 0f, angle));
                    b2.transform.rotation = Quaternion.Slerp(b2.transform.rotation, targetRotationF, 1);
                    angle = Mathf.Atan2(b3.transform.position.y - goArray[i].transform.position.y, b3.transform.position.x - goArray[i].transform.position.x) * Mathf.Rad2Deg-90;
                    targetRotationF = Quaternion.Euler(new Vector3(0f, 0f, angle));
                    b3.transform.rotation = Quaternion.Slerp(b3.transform.rotation, targetRotationF, 1);
                    angle = Mathf.Atan2(b4.transform.position.y - goArray[i].transform.position.y, b4.transform.position.x - goArray[i].transform.position.x) * Mathf.Rad2Deg-90;
                    targetRotationF = Quaternion.Euler(new Vector3(0f, 0f, angle));
                    b4.transform.rotation = Quaternion.Slerp(b4.transform.rotation, targetRotationF, 1);
                    Robot.velocity = new Vector3(0, 0, 0);
                    Robot.angularVelocity = 0;
                }

            }
        }
        if (hod < 1)
        {
            //
            angle = Mathf.Atan2(transform.position.y - py, transform.position.x - px) * Mathf.Rad2Deg-90;
            var targetRotationS = Quaternion.Euler(new Vector3(0f, 0f, angle));
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotationS, 1);
            if (zam < Time.time)
            {
                Robot.velocity = (new Vector3(px, py, 0) - transform.position).normalized * 5;                
            }

        }
        if ((((transform.position.x - px <= 1) && (transform.position.x > px)) || ((transform.position.x - px >= -1) && (transform.position.x < px))) && (((transform.position.y - py <= 1) && (transform.position.y > py)) || ((transform.position.y - py >= -1) && (transform.position.y < py))))
        {
            px = point.transform.position.x + Random.Range(-40, 40);
            py = point.transform.position.y + Random.Range(-40, 40);
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == "Provod"&& Time.time-time>0.5)
        {
            time = Time.time;
            Instantiate(B,Bj.transform.position, Bj.transform.rotation);
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