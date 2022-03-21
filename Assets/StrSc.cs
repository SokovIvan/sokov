using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class StrSc : MonoBehaviour
{
    float maxValue;
    public Color color = Color.red;
    public int width;
    public Slider slider;
    public GameObject ZZZ;
    public GameObject Snar;
    public GameObject F;
    public GameObject ColR;
    Vector3 Base;
    float life;
    float px;
    float py;
    float hod;
    float zam;
    Vector3 mousePos;
    Vector3 mousePosClick1;
    Vector3 mousePosClick2;
    Vector3 mousePosClick3;
    float n;
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
        life = 50;
        if (GameCon.up2Y())
        {
            life = +12;
        }
        slider.fillRect.GetComponent<Image>().color = color;
        maxValue = life / 100;
        slider.maxValue = maxValue;
        slider.minValue = 0;
        UpdateUI(); 
        Rigidbody2D Robot = GetComponent<Rigidbody2D>();        
        GameObject[] goArray;
        goArray = GameObject.FindGameObjectsWithTag("ResA");
        int rand = Random.Range(0, goArray.Length);
        px = goArray[rand].transform.position.x;
        py = goArray[rand].transform.position.y;
        hod = 0;
        zam = 0;
        //Base = new Vector3(3, -72, 0);
        n = 1;
        Base = GameObject.FindGameObjectWithTag("PlBA").transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        slider.value = life / 100;
        mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if ((Input.GetMouseButtonDown(1)) && (n == 3))
        {
            n = 1;
            if ((((transform.position.x > mousePosClick1.x) && (transform.position.x < mousePosClick2.x)) || ((transform.position.x < mousePosClick1.x) && (transform.position.x > mousePosClick2.x))) && (((transform.position.y > mousePosClick1.y) && (transform.position.y < mousePosClick2.y)) || ((transform.position.y < mousePosClick1.y) && (transform.position.y > mousePosClick2.y))))
            {
                px = mousePos.x;
                py = mousePos.y;
                hod = 3;
            }
            mousePosClick1 = mousePos;
            mousePosClick2 = mousePos;

        }
        if ((Input.GetKeyDown(KeyCode.LeftShift)) && (n == 3))
        {
            n = 1;
            if ((((transform.position.x > mousePosClick1.x) && (transform.position.x < mousePosClick2.x)) || ((transform.position.x < mousePosClick1.x) && (transform.position.x > mousePosClick2.x))) && (((transform.position.y > mousePosClick1.y) && (transform.position.y < mousePosClick2.y)) || ((transform.position.y < mousePosClick1.y) && (transform.position.y > mousePosClick2.y))))
            {
            GameCon.trcanN(4);
            GameCon.techbN(gameObject);
            }
            mousePosClick1 = mousePos;
            mousePosClick2 = mousePos;
        }
        if ((Input.GetMouseButtonDown(0)) && (n == 1))
        {
            mousePosClick1 = mousePos;
            n = 2;
        }
        else if ((Input.GetMouseButtonUp(0)) && (n == 2))
        {
            mousePosClick2 = mousePos;
            n = 3;

        }
        Rigidbody2D Robot = GetComponent<Rigidbody2D>();
        if (life <= 0)
        {            
            Instantiate(F, transform.position, Quaternion.Slerp(transform.rotation, transform.rotation, 1));
            Destroy(gameObject);
        }
        float hod1;
        hod1 = 0;
        float angle;
        GameObject[] goArray1;
        goArray1 = GameObject.FindGameObjectsWithTag("Robots");
        for (int i = 0; i < goArray1.Length; i++)
        {
            if ((goArray1[i].transform.position - transform.position).sqrMagnitude <= 10)
            {
                GameObject cur;
                hod1 = hod1 + 1;
                if (hod == 1)
                {
                    angle = Mathf.Atan2(transform.position.y - goArray1[i].transform.position.y, transform.position.x - goArray1[i].transform.position.x) * Mathf.Rad2Deg;
                    var targetRotationF = Quaternion.Euler(new Vector3(0f, 0f, angle));
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotationF, 1);
                    cur = Instantiate(Snar, transform.position, Quaternion.Slerp(transform.rotation, targetRotationF, 1));
                    cur.GetComponent<Rigidbody2D>().velocity = (new Vector3(goArray1[i].transform.position.x, goArray1[i].transform.position.y, 0) - cur.transform.position).normalized * 100;
                    ZZZ.SetActive(true);
                    Robot.velocity = new Vector3(0, 0, 0);
                }

            }
        }
        if (hod1 == 0)
        {
            if (zam < Time.time)
            {
                angle = Mathf.Atan2(transform.position.y - py, transform.position.x - px) * Mathf.Rad2Deg;
                var targetRotationS = Quaternion.Euler(new Vector3(0f, 0f, (angle - 90)));
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotationS, 1);
                Robot.velocity = (new Vector3(px, py, 0) - transform.position).normalized * 15;
                if ((((transform.position.x - px <= 1) && (transform.position.x > px)) || ((transform.position.x - px >= -1) && (transform.position.x < px))) && (((transform.position.y - py <= 1) && (transform.position.y > py)) || ((transform.position.y - py >= -1) && (transform.position.y < py))))
                {
                    Robot.velocity = (new Vector3(px, py, 0) - transform.position).normalized * 0;
                    Robot.angularVelocity = 0;
                    if (hod == 0)
                    {
                        GameObject[] goArray;
                        goArray = GameObject.FindGameObjectsWithTag("ResA");
                        int rand = Random.Range(0, goArray.Length);
                        px = goArray[rand].transform.position.x;
                        py = goArray[rand].transform.position.y;
                        ZZZ.SetActive(false);
                        GameCon.prA();
                        if (GameCon.up2Y())
                        {
                          GameCon.prA();
                        }
                        if (GameCon.up4Y())
                        {
                            GameCon.prA();
                        }

                    }
                    if (hod == 1)
                    {
                        px = Base.x;
                        py = Base.y;
                    }
                }
            }
            if ((transform.position - Base).sqrMagnitude <= 20)
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
        if (other.tag == "River")
        {
            float x = transform.position.x;
            float y = transform.position.y + 1;
            transform.position = new Vector3(x, y, 0);
        }
        if (other.tag == "ResA")
        {
            if (hod == 0|| hod == 3)
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
        if (other.tag == "Laser")
        {
            life -= 1;
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
    }
}
