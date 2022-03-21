using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SalvoSc : MonoBehaviour
{
    public Animator animator;
    float maxValue;
    public Color color = Color.red;
    public int width;
    public Slider slider;
    Vector3 mousePos;
    Vector3 mousePosClick1;
    Vector3 mousePosClick2;
    //Vector3 mousePosClick3;
    public GameObject goL1;
    public GameObject goL2;
    public GameObject Laser;
    //public GameObject Zvyk;
    public GameObject Vzriv;
    public GameObject F;    
    float life;
    float px;
    float py;
    float hod;
    float firet;
    float zam;
    float u;
    float n;
    float td;
    float dx;
    float zader;
    float zakop;
    float rotz;
    Vector3 pos;
    float rotzg;
    // Start is called before the first frame update
    void UpdateUI()
    {        
        RectTransform rect = slider.GetComponent<RectTransform>();
        int rectDeltaX = Screen.width / width;
        float rectPosX = 0;
        rectPosX = rect.position.x + (rectDeltaX - rect.sizeDelta.x) / 2;
        slider.direction = Slider.Direction.LeftToRight;
        rect.sizeDelta = new Vector2(rectDeltaX, rect.sizeDelta.y);
        rect.position = new Vector3(rectPosX, rect.position.y, rect.position.z);
    }
    void Start()
    {
        zader = 0;
        Rigidbody2D Robot = GetComponent<Rigidbody2D>();
        life = 200;
        if (GameCon.up2Y())
        {
            life = +50;
        }
        slider.fillRect.GetComponent<Image>().color = color;
        maxValue = life / 100;
        slider.maxValue = maxValue;
        slider.minValue = 0;
        //UpdateUI();
        px = transform.position.x;
        py = transform.position.y;
        hod = 0;
        firet = 0;
        zam = 0;
        u = 1;
        n = 1;        
       // animator.SetBool("Death", false);
        animator.SetBool("Выстрел", false);
        animator.SetBool("Закопанный", false);
        animator.SetBool("Раскопанный", false);
        animator.SetBool("Закапывается", false);
        animator.SetBool("Ход", false);
        zakop = 0;
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Flag");
        GameObject a = gameObjects[Random.Range(0, gameObjects.Length)];
        px = a.transform.position.x;
        py = a.transform.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        float angle;        
        GameObject[] goArray;
        Rigidbody2D Robot = GetComponent<Rigidbody2D>();
        Robot.angularVelocity = 0;
        slider.value = life / 100;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if ((Input.GetMouseButtonDown(0)) && (n == 3) && (zakop == 0))
        {   
            hod = 0;
            animator.SetBool("Закапывается", false);
            animator.SetBool("Выстрел", false);
            animator.SetBool("Закопанный", false);
            animator.SetBool("Раскопанный", true);
            animator.SetBool("Ход", true);
            zader = Time.time + 1;
            zakop = 0;
            n = 1;
            if ((((transform.position.x > mousePosClick1.x) && (transform.position.x < mousePosClick2.x)) || ((transform.position.x < mousePosClick1.x) && (transform.position.x > mousePosClick2.x))) && (((transform.position.y > mousePosClick1.y) && (transform.position.y < mousePosClick2.y)) || ((transform.position.y < mousePosClick1.y) && (transform.position.y > mousePosClick2.y))))
            {
                px = mousePos.x;
                py = mousePos.y;
            }
            mousePosClick1 = mousePos;
            mousePosClick2 = mousePos;

        }
         if ((Input.GetKeyDown(KeyCode.LeftShift)) && (zakop == 1))
        {
            n = 1;
            if ((((transform.position.x > mousePosClick1.x) && (transform.position.x < mousePosClick2.x)) || ((transform.position.x < mousePosClick1.x) && (transform.position.x > mousePosClick2.x))) && (((transform.position.y > mousePosClick1.y) && (transform.position.y < mousePosClick2.y)) || ((transform.position.y < mousePosClick1.y) && (transform.position.y > mousePosClick2.y))))
            {
                animator.SetBool("Закапывается", false);
                animator.SetBool("Выстрел", false);
                animator.SetBool("Закопанный", false);
                animator.SetBool("Раскопанный", true);
                zakop = 0;               
            }
           
        }
            if ((Input.GetKeyDown(KeyCode.LeftShift)) && (n == 3) && (zakop == 0))
        {
            if ((((transform.position.x > mousePosClick1.x) && (transform.position.x < mousePosClick2.x)) || ((transform.position.x < mousePosClick1.x) && (transform.position.x > mousePosClick2.x))) && (((transform.position.y > mousePosClick1.y) && (transform.position.y < mousePosClick2.y)) || ((transform.position.y < mousePosClick1.y) && (transform.position.y > mousePosClick2.y))))
            {  
                pos = transform.position;
                hod = 1;
                zakop = 1;
                n = 4;
                animator.SetBool("Закапывается", true);
                animator.SetBool("Выстрел", false);
                animator.SetBool("Закопанный", true);
                animator.SetBool("Раскопанный", false);                
                animator.SetBool("Ход", false);
                zader = Time.time + 1;
                Robot.velocity = new Vector3(0, 0, 0);
            }
        }
        if ((Input.GetMouseButtonDown(0)) && (n == 4)&&(zader<=Time.time))
        {   
            hod = 1;           
            zakop = 1;
            n = 1;
            if ((((transform.position.x > mousePosClick1.x) && (transform.position.x < mousePosClick2.x)) || ((transform.position.x < mousePosClick1.x) && (transform.position.x > mousePosClick2.x))) && (((transform.position.y > mousePosClick1.y) && (transform.position.y < mousePosClick2.y)) || ((transform.position.y < mousePosClick1.y) && (transform.position.y > mousePosClick2.y))))
            {
                rotz = transform.rotation.z;
                px = mousePos.x;
                py = mousePos.y;
                angle = (Mathf.Atan2(transform.position.y - py, transform.position.x - px) * Mathf.Rad2Deg) + 90;                
                var targetRotationS = Quaternion.Euler(new Vector3(0f, 0f, angle));                
                transform.rotation = Quaternion.Lerp(transform.rotation, targetRotationS, 1/5);
                zader = Time.time + 5;
                animator.SetBool("Закапывается", false);
                animator.SetBool("Выстрел", true);
                animator.SetBool("Закопанный", true);
                animator.SetBool("Раскопанный", false);
                animator.SetBool("Ход", false);                
                GameObject cur;
                cur = Instantiate(Laser, goL1.transform.position, transform.rotation);
                cur.GetComponent<Rigidbody2D>().velocity = (goL2.transform.position - cur.transform.position).normalized * 60;
                angle = Mathf.Atan2(cur.transform.position.y - goL2.transform.position.y, cur.transform.position.x - goL2.transform.position.x) * Mathf.Rad2Deg;
                var targetRotationL1 = Quaternion.Euler(new Vector3(0f, 0f, angle));
                cur.transform.rotation = Quaternion.Slerp(goL1.transform.rotation, targetRotationL1, 1);
                Robot.velocity = new Vector3(0, 0, 0);

            }       

        }
        if (zakop == 1)
        {
            transform.position=pos;
            if (Time.time - zader > -5 + 0.733)
            {
                animator.SetBool("Выстрел", false);
            }
        }
        if ((Input.GetMouseButtonDown(0)) && (n == 1))
        {
            mousePosClick1 = mousePos;
            n = 2;
        }
         if ((Input.GetMouseButtonUp(0)) && (n == 2))
        {
            mousePosClick2 = mousePos;
            n = 3;
            if (zakop == 1)
            {
                n =4;
            } 
        }
        if ((life <= 0) && (dx == 0))
        {
            //animator.SetBool("Death", true);
            td = Time.time + 1;
            dx = 1;
        }
        if ((td - Time.time < 0.5) && (dx == 1))
        {
            Instantiate(Vzriv, transform.position, Quaternion.Slerp(transform.rotation, transform.rotation, 1));
            Instantiate(F, transform.position, Quaternion.Slerp(transform.rotation, transform.rotation, 1));
            Destroy(gameObject);
        }        

        if (hod < 1)
        {
            if (((transform.position - new Vector3(px, py, 0)).sqrMagnitude >= 1)&&(zakop==0))
            {
                
                animator.SetBool("Ход", true);
                animator.SetBool("Закопанный", false);
                animator.SetBool("Раскопанный", true);
                animator.SetBool("Закапывается", false);
                angle = Mathf.Atan2(transform.position.y - py, transform.position.x - px) * Mathf.Rad2Deg+90;
                var targetRotationS = Quaternion.Euler(new Vector3(0f, 0f, angle));
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotationS, 1);
            }
            if (zam < Time.time)
            {
                if (((transform.position - new Vector3(px, py, 0)).sqrMagnitude >= 1)&&(zakop == 0))
                {
                    animator.SetBool("Ход", true);
                    animator.SetBool("Закопанный", false);
                    animator.SetBool("Раскопанный", true);
                    animator.SetBool("Закапывается", false);
                    Robot.velocity = (new Vector3(px, py, 0) - transform.position).normalized * 10;
                }
                else
                {
                    animator.SetBool("Ход", false);                    
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

