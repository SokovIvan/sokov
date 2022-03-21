using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarrierSc : MonoBehaviour
{
    public GameObject robot;
    public GameObject F;
    public Animator animator;
    Vector3 Base;
    float life;
    float px;
    float py;
    float hod;
    float zam;
    float firet;
    float dx;
    public CyborgSc cyb1;
    public CyborgSc cyb2;
    public CyborgSc cyb3;
    public CyborgSc cyb4;
    public CyborgSc cyb5;
    public CyborgSc cyb6;
    public CyborgSc cyb7;
    public CyborgSc cyb8;
    public GameObject csp1;
    public GameObject csp2;
    public GameObject csp3;
    public GameObject csp4;
    public GameObject csp5;
    public GameObject csp6;
    public GameObject csp7;
    public GameObject csp8;
    int zt;
    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D Robot = GetComponent<Rigidbody2D>();
        life = 400;
        px = Random.Range(-10, 10);
        py = Random.Range(-90, 0);
        hod = 0;
        zam = 0;
        Base = new Vector3(-8, 93, 0);
        cyb1=Instantiate(robot, csp1.transform.position, Quaternion.identity).GetComponent<CyborgSc>();
        cyb1.stpZ(csp1);
        cyb2 = Instantiate(robot, csp2.transform.position, Quaternion.identity).GetComponent<CyborgSc>();
        cyb2.stpZ(csp2);
        cyb3 = Instantiate(robot, csp3.transform.position, Quaternion.identity).GetComponent<CyborgSc>();
        cyb3.stpZ(csp3);
        cyb4 = Instantiate(robot, csp4.transform.position, Quaternion.identity).GetComponent<CyborgSc>();
        cyb4.stpZ(csp4);
        cyb5 = Instantiate(robot, csp5.transform.position, Quaternion.identity).GetComponent<CyborgSc>();
        cyb5.stpZ(csp5);
        cyb6 = Instantiate(robot, csp6.transform.position, Quaternion.identity).GetComponent<CyborgSc>();
        cyb6.stpZ(csp6);
        cyb7 = Instantiate(robot, csp7.transform.position, Quaternion.identity).GetComponent<CyborgSc>();
        cyb7.stpZ(csp7);
        cyb8 = Instantiate(robot, csp8.transform.position, Quaternion.identity).GetComponent<CyborgSc>();
        cyb8.stpZ(csp8);
        zt = 0;
    }
    // Update is called once per frame
    void Update()
    {
        if (life <= 0)
        {
            Instantiate(F, transform.position, Quaternion.Slerp(transform.rotation, transform.rotation, 1));
            //animator.SetBool("Смерть", true);
            cyb1.life = 0;
            cyb1.dx = 2;
            cyb2.life = 0;
            cyb2.dx = 2;
            cyb3.life = 0;
            cyb3.dx = 2;
            cyb4.life = 0;
            cyb4.dx = 2;
            cyb5.life = 0;
            cyb5.dx = 2;
            cyb6.life = 0;
            cyb6.dx = 2;
            cyb7.life = 0;
            cyb7.dx = 2;
            cyb8.life = 0;
            cyb8.dx = 2;
            Destroy(gameObject);
        }
        if (cyb2.dx == 1)
        {
            cyb2 = Instantiate(robot, csp2.transform.position, Quaternion.identity).GetComponent<CyborgSc>();
            cyb2.stpZ(csp2);
        }
        if (cyb3.dx == 1)
        {
            cyb3 = Instantiate(robot, csp3.transform.position, Quaternion.identity).GetComponent<CyborgSc>();
            cyb3.stpZ(csp3);
        }
        if (cyb4.dx == 1)
        {
            cyb4 = Instantiate(robot, csp4.transform.position, Quaternion.identity).GetComponent<CyborgSc>();
            cyb4.stpZ(csp4);
        }
        if (cyb5.dx == 1)
        {
            cyb5 = Instantiate(robot, csp5.transform.position, Quaternion.identity).GetComponent<CyborgSc>();
            cyb5.stpZ(csp5);
        }
        if (cyb6.dx == 1)
        {
            cyb6 = Instantiate(robot, csp6.transform.position, Quaternion.identity).GetComponent<CyborgSc>();
            cyb6.stpZ(csp6);
        }
        if (cyb8.dx == 1)
        {
            cyb8 = Instantiate(robot, csp8.transform.position, Quaternion.identity).GetComponent<CyborgSc>();
            cyb8.stpZ(csp8);
        }
        if (cyb7.dx == 1)
        {
            cyb7 = Instantiate(robot, csp7.transform.position, Quaternion.identity).GetComponent<CyborgSc>();
            cyb7.stpZ(csp7);
        }
        float angle;
            hod = 0;
            GameObject[] goArray;
            Rigidbody2D Robot = GetComponent<Rigidbody2D>();
            goArray = GameObject.FindGameObjectsWithTag("Allies");
            for (int i = 0; i < goArray.Length; i++)
            {
                if ((goArray[i].transform.position - transform.position).sqrMagnitude <= 1800)
                {
                zt ++;
                animator.SetBool("Ход", false);
                hod = hod + 1;
                if (zt == 1)
                {
                cyb1.pn();
                cyb2.pn();
                cyb3.pn();
                cyb4.pn();
                cyb5.pn();
                cyb6.pn();
                cyb7.pn();
                cyb8.pn();
                }
                cyb1.polo = true;
                cyb2.polo = true;
                cyb3.polo = true;
                cyb4.polo = true;
                cyb5.polo = true;
                cyb6.polo = true;
                cyb7.polo = true;
                cyb8.polo = true;
                Robot.velocity = new Vector3(0, 0, 0);
                Robot.angularVelocity = 0;                    
                }

            }
                if (hod<1)
                {
                zt = 0;
                cyb1.polo = false;
                cyb2.polo = false;
                cyb3.polo = false;
                cyb4.polo = false;
                cyb5.polo = false;
                cyb6.polo = false;
                cyb7.polo = false;
                cyb8.polo = false;
                }
            //float hod2 = 0;
            //goArray = GameObject.FindGameObjectsWithTag("Primanka");
            //for (int i = 0; i < goArray.Length; i++)
            //{
            //    if ((goArray[i].transform.position - transform.position).sqrMagnitude <= 800)
            //    {
            //        hod2 = hod2 + 1;
            //        if (hod2 == 1)
            //        {
            //            px = goArray[i].transform.position.x;
            //            py = goArray[i].transform.position.y;
             //       }
             //   }
            //}
            if (hod < 1)
            {
                animator.SetBool("Ход", true);                
                angle = Mathf.Atan2(transform.position.y - py, transform.position.x - px) * Mathf.Rad2Deg;
                var targetRotationS = Quaternion.Euler(new Vector3(0f, 0f, angle));
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotationS, 1);
                if (zam < Time.time)
                {
                    Robot.velocity = (new Vector3(px, py, 0) - transform.position).normalized * 5;                    
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