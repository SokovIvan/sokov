using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CyborgSc : MonoBehaviour
{
    public GameObject B;
    public GameObject Laser;
    public GameObject F;
    public GameObject Bj;
    public GameObject goL2;
    public Animator animator;
    public Animator animatorB;
    Vector3 Base;    
    public float life;
    float px;
    float py;
    float hod;
    float zam;
    float firet;
    float deatht;
    Rigidbody2D RobotB;    
    public float dx;
    public bool polo;
    public GameObject stp;
    // Start is called before the first frame update
    void Start()
    {
        //stp = gameObject;
        Rigidbody2D Robot = GetComponent<Rigidbody2D>();
        life = 50;
        px = stp.transform.position.x + Random.Range(-10, 10);
        py = stp.transform.position.y + Random.Range(-10, 10);
        hod = 0;
        zam = 0;
        Base = new Vector3(-8, 93, 0);
        RobotB = B.GetComponent<Rigidbody2D>();        
    }
    // Update is called once per frame
    void Update()
    {
        if (polo == false)
        {
        transform.position = stp.transform.position;
        B.transform.position = Bj.transform.position;
        }
        if (dx == 2)
        {
            Destroy(B);
             Destroy(gameObject);

        }
        if ((life <= 0)&&(dx==0))
        {            
            Instantiate(F, transform.position, Quaternion.Slerp(transform.rotation, transform.rotation, 1));
            //Destroy(B);
            deatht=Time.time+2;
            animator.SetBool("Смерть",true);
            dx = 1;
           // Destroy(gameObject);
        }
        if(polo==true)
        { 
         B.transform.position = Bj.transform.position;
        float angle;
        hod = 0;
        GameObject[] goArray;
        Rigidbody2D Robot = GetComponent<Rigidbody2D>();
        goArray = GameObject.FindGameObjectsWithTag("Allies");
        for (int i = 0; i < goArray.Length; i++)
        {
            if ((goArray[i].transform.position - transform.position).sqrMagnitude <= 550)
            {
                animator.SetBool("Ход", false);
                GameObject cur;
                hod = hod + 1;
                if ((hod == 1)&&(firet<=Time.time))
                {
                    firet = Time.time + 1;
                    animatorB.SetBool("Выстрел", true);
                    angle = Mathf.Atan2(B.transform.position.y - goArray[i].transform.position.y, B.transform.position.x - goArray[i].transform.position.x) * Mathf.Rad2Deg;
                    var targetRotationF = Quaternion.Euler(new Vector3(0f, 0f, angle));
                    B.transform.rotation = Quaternion.Slerp(B.transform.rotation, targetRotationF, 1);                    
                    Robot.velocity = new Vector3(0, 0, 0);
                    Robot.angularVelocity = 0;
                    RobotB.velocity = new Vector3(0, 0, 0);
                    RobotB.angularVelocity = 0;
                    angle = Mathf.Atan2(goL2.transform.position.y - goArray[i].transform.position.y, goL2.transform.position.x - goArray[i].transform.position.x) * Mathf.Rad2Deg;
                    var targetRotationL2 = Quaternion.Euler(new Vector3(0f, 0f, angle));
                    goL2.transform.rotation = Quaternion.Slerp(goL2.transform.rotation, targetRotationL2, 1);
                    cur = Instantiate(Laser, goL2.transform.position, Quaternion.Slerp(goL2.transform.rotation, targetRotationL2, 1));
                    cur.GetComponent<Rigidbody2D>().velocity = (new Vector3(goArray[i].transform.position.x, goArray[i].transform.position.y, 0) - cur.transform.position).normalized * 30;
                }

            }
        }
        if (firet - Time.time < 0.36)
        {
            animatorB.SetBool("Выстрел", false);
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
            animator.SetBool("Ход",true);
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
            px = stp.transform.position.x+Random.Range(-20, 20);
            py = stp.transform.position.y + Random.Range(-20, 20);
        }         
        }
        if ((deatht - Time.time < 0.35)&& (life <= 0))
        {
            Destroy(B);
            Destroy(gameObject);
        }        
    }
    //public void pol(bool n)
    //{
    //    polo = n;
    //}
    public void stpZ(GameObject n)
    {
        stp = n;
    }
    public void pn()
    {
   
            px = stp.transform.position.x + Random.Range(-20, 20);
            py = stp.transform.position.y + Random.Range(-20, 20);
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
            B.GetComponent<Rigidbody2D>().velocity = (new Vector3(px, py, 0) - transform.position).normalized * 2;
        }
    }

}