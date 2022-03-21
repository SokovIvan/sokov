using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildScr : MonoBehaviour
{
    public GameObject ZZZ;
    public GameObject Laser;
    public GameObject F;
    public GameObject ColR;
    public GameObject turret;
    public GameObject Factory;
    public GameObject FactoryT3;
    Vector3 Base;
    Vector3 tur;
    Vector3 Fac;
    Vector3 Fac2;
    Vector3 FacT3;
    float life;
    float px;
    float py;
    float hod;
    float zam;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D Robot = GetComponent<Rigidbody2D>();
        life = 50;
        GameObject[] goArray;
        goArray = GameObject.FindGameObjectsWithTag("ResR");
        int rand = Random.Range(0, goArray.Length);
        px = goArray[rand].transform.position.x;
        py = goArray[rand].transform.position.y;
        hod = 0;
        zam = 0;
        Base = new Vector3(-8, 93, 0);
        tur = new Vector3(-10, 30, 0);
        Fac = new Vector3(15, 61, 0);
        Fac2 = new Vector3(-37, 61, 0);
        GameCon.BsRplus();        
        Base =GameObject.FindGameObjectWithTag("PlBR").transform.position;
        Fac= GameObject.FindGameObjectWithTag("PlF").transform.position;
        Fac2 = GameObject.FindGameObjectWithTag("PlF2").transform.position;
        tur = GameObject.FindGameObjectWithTag("PlT").transform.position;
        FacT3 = GameObject.FindGameObjectWithTag("PlF3").transform.position;
    }

    // Update is called once per frame
    void Update()
    { 
        Rigidbody2D Robot = GetComponent<Rigidbody2D>();
        if (life <= 0)
        {
            GameCon.BsRminus();
            Instantiate(F, transform.position, Quaternion.Slerp(transform.rotation, transform.rotation, 1));
            Destroy(gameObject);
        }
        float hod1;
        hod1 = 0;
        float angle;
        GameObject[] goArray1;        
        goArray1 = GameObject.FindGameObjectsWithTag("Allies");
        for (int i = 0; i < goArray1.Length; i++)
        {
            if ((goArray1[i].transform.position - transform.position).sqrMagnitude <= 10)
            {
                GameObject cur;
                hod1 = hod1 + 1;
                if (hod1 == 1)
                {
                    angle = Mathf.Atan2(transform.position.y - goArray1[i].transform.position.y, transform.position.x - goArray1[i].transform.position.x) * Mathf.Rad2Deg;
                    var targetRotationF = Quaternion.Euler(new Vector3(0f, 0f, angle));
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotationF, 1);
                    cur = Instantiate(Laser, transform.position, Quaternion.Slerp(transform.rotation, targetRotationF, 1));
                    cur.GetComponent<Rigidbody2D>().velocity = (new Vector3(goArray1[i].transform.position.x, goArray1[i].transform.position.y, 0) - cur.transform.position).normalized * 100;
                    ZZZ.SetActive(true);
                    Robot.velocity = new Vector3(0, 0, 0);
                }

            }
        }
        if ((transform.position-GameObject.FindGameObjectWithTag("PlF").transform.position).sqrMagnitude<=60&& GameCon.Factt() == 1)
        {
            hod = 0;
        }
        if ((transform.position - GameObject.FindGameObjectWithTag("PlF2").transform.position).sqrMagnitude <= 60&&GameCon.Factt() == 2)
        {
            hod = 0;
        }
        if (hod1 == 0)
        {

            if (zam < Time.time)
            {
                angle = Mathf.Atan2(transform.position.y - py, transform.position.x - px) * Mathf.Rad2Deg;
                var targetRotationS = Quaternion.Euler(new Vector3(0f, 0f, (angle - 90)));
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotationS, 1);
                Robot.velocity = (new Vector3(px, py, 0) - transform.position).normalized * 15;
                if (GameCon.tur() <= 0)
                {
                        px = tur.x;
                        py = tur.y;
                        hod = 3;                        
                }
                if ((GameCon.Factt() == 0)&&(GameCon.strar()<=2)&&(GameCon.ress()>=10) & GameCon.buils() > 3)
                {                    
                    px = Fac.x;
                    py = Fac.y;
                    hod = 4;
                }
                if ((GameCon.Factt() == 1) && (GameCon.strar() <= 2) && (GameCon.ress() >= 10)&&GameCon.buils()>3)
                {
                    px = Fac2.x;
                    py = Fac2.y;
                    hod = 4;
                }
                if((GameCon.Factt() == 2) && (hod == 4))
                {
                    hod = 0;
                }
                if ((GameCon.Factt() == 3) && (hod == 5))
                {
                    hod = 0;
                }
                if ((GameCon.tur() >0) && (hod == 3))
                {
                    hod = 0;
                }
                if ((GameCon.ress() >= 50))
                {
                    px = FacT3.x;
                    py = FacT3.y;
                    hod = 5;
                }
                if ((transform.position - new Vector3(px,py,0)).sqrMagnitude <= 25)
                {
                    if (hod == 0)
                    {
                        GameObject[] goArray;
                        goArray = GameObject.FindGameObjectsWithTag("ResR");
                        int rand = Random.Range(0, goArray.Length);
                        px = goArray[rand].transform.position.x;
                        py = goArray[rand].transform.position.y;
                        GameCon.pr();
                    }
                    if (hod == 1)
                    {
                        
                        px = Base.x;
                        py = Base.y;

                    }
                    if (hod == 3) 
                    {
                        GameCon.turA();
                        Instantiate(turret, transform.position, Quaternion.identity);
                        hod = 0;
                    }
                    if (hod == 4)
                    {
                        GameCon.FactP();
                        Instantiate(Factory, transform.position, Quaternion.identity);
                        hod = 0;
                    }
                    if (hod == 5)
                    {
                        GameCon.FactP();
                        Instantiate(FactoryT3, transform.position, Quaternion.identity);
                        hod = 0;
                    }
                    if ((GameCon.Factt() == 2) && (hod == 4))
                    {
                        hod = 0;
                    }
                    if ((GameCon.tur() > 0) && (hod == 3))
                    {
                        hod = 0;
                    }
                }
            }
            if ((transform.position - Base).sqrMagnitude <= 25)
            {

                        hod = 0;                        

            }
            if (zam > Time.time)
            {
                ZZZ.SetActive(true);
                Robot.velocity = (new Vector3(px, py, 0) - transform.position).normalized * 0;
                Robot.angularVelocity = 0;
            }
            else
            {
                if (hod == 1)
                {
                    ColR.SetActive(true);
                }
                else
                {
                    ColR.SetActive(false);
                }
                ZZZ.SetActive(false);
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Robots")
        {
            //float x = transform.position.x + Random.Range(-1, 1);
            //float y = transform.position.y + Random.Range(-1, 1);
            //transform.position = new Vector3(x, y, 0);
            if (hod >= 3)
        {
            hod = 0;
            float x = transform.position.x + Random.Range(-1, 1);
            float y = transform.position.y + Random.Range(-1, 1);
            transform.position = new Vector3(x, y, 0);

            }

        }
    
        if (other.tag == "River")
        {
            float x = transform.position.x;
            float y = transform.position.y + 1;
            transform.position = new Vector3(x, y, 0);
        }
        if (other.tag == "ResR")
        {
            if (hod==0)
            {
            hod = 1;
            zam = Time.time + 2;
            px = Base.x;
            py = Base.y;
            }
            if (hod == 1)
            {
              //  float xn =transform.position.x + 1;
              //  transform.position = new Vector3(xn, transform.position.y, 0);
            }

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
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == "Robots")
        {
            if (hod >= 3)
            {
                hod = 0;
                float x = transform.position.x+Random.Range(-1,1);
                float y = transform.position.y + Random.Range(-1, 1);
                transform.position = new Vector3(x, y, 0);
            }

        }
    }
}
