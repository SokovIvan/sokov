using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Incin2: MonoBehaviour
{
    public int xxx;
    public int xxx2;
    public int xxx3;
    public Animator animator;
    float maxValue;
    public Color color = Color.red;
    public int width;
    public Slider slider;
    Vector3 mousePos;
    Vector3 mousePosClick1;
    Vector3 mousePosClick2;
    Vector3 mousePosClick3;
    public GameObject goL1;
    public GameObject Laser;
    public GameObject Zvyk;
    public GameObject F;
    public GameObject mask;
    //public GameObject okoh;
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
    float timeBlink;

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

        Rigidbody2D Robot = GetComponent<Rigidbody2D>();
        life = 200;
        slider.fillRect.GetComponent<Image>().color = color;
        maxValue = life / 100;
        slider.maxValue = maxValue;
        slider.minValue = 0;
        //UpdateUI();
        px = Random.Range(-15, 90);
        py = Random.Range(-60, 60);
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Flag");
        GameObject a = gameObjects[Random.Range(0, gameObjects.Length-1)];
        px = a.transform.position.x;
        py = a.transform.position.y;
        hod = 0;
        firet = 0;
        zam = 0;
        u = 1;
        n = 1;
        animator.SetBool("Death", false);
        animator.SetBool("Attack", false);
        animator.SetBool("Õîä", false);
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
            }
            mousePosClick1 = mousePos;
            mousePosClick2 = mousePos;

        }

        if ((Input.GetKeyDown(KeyCode.LeftShift)) && (n == 3))
        {
            n = 1;
            if (Time.time - timeBlink > 15 && (((transform.position.x > mousePosClick1.x) && (transform.position.x < mousePosClick2.x)) || ((transform.position.x < mousePosClick1.x) && (transform.position.x > mousePosClick2.x))) && (((transform.position.y > mousePosClick1.y) && (transform.position.y < mousePosClick2.y)) || ((transform.position.y < mousePosClick1.y) && (transform.position.y > mousePosClick2.y))))
            {
                timeBlink = Time.time;
            }
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
        if ((life <= 0) && (dx == 0))
        {
            animator.SetBool("Death", true);
            td = Time.time + 1;
            dx = 1;
        }
        if ((td - Time.time < 0.5) && (dx == 1))
        {
            Instantiate(F, transform.position, Quaternion.Slerp(transform.rotation, transform.rotation, 1));
            Destroy(gameObject);
        }
        float angle;
        hod = 0;
        GameObject[] goArray;
        Rigidbody2D Robot = GetComponent<Rigidbody2D>();
        Robot.angularVelocity = 0;
        goArray = GameObject.FindGameObjectsWithTag("Robots");
        Laser.transform.position = goL1.transform.position;
        for (int i = 0; i < goArray.Length; i++)
        {
            if (Time.time - timeBlink < 10)
            {
                hod = 0;
                mask.SetActive(true);
                transform.tag = "Untagged";
            }
            else
            {
                mask.SetActive(false);
                GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b, 255);
                transform.tag = "Allies";
            }
            if ((goArray[i].transform.position - transform.position).sqrMagnitude <= 550)
            {
                animator.SetBool("Õîä", false);
                animator.SetBool("Attack", true);
                GameObject cur;
                hod = hod + 1;
                if (Time.time - timeBlink < 10)
                {
                    hod = 0;
                    GetComponent<SpriteRenderer>().color =  new Color(GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b, 100); 
                    transform.tag = "Untagged";
                }
                else
                {
                    GetComponent<SpriteRenderer>().color = new Color(GetComponent<SpriteRenderer>().color.r, GetComponent<SpriteRenderer>().color.g, GetComponent<SpriteRenderer>().color.b, 255);
                    transform.tag = "Allies";
                }
                if ((hod == 1) && (Time.time - firet > 2))
                {
                    Zvyk.SetActive(true);
                    animator.SetBool("Attack", true);
                    firet = Time.time;
                    angle = Mathf.Atan2(transform.position.y - goArray[i].transform.position.y, transform.position.x - goArray[i].transform.position.x) * Mathf.Rad2Deg;
                    var targetRotationF = Quaternion.Euler(new Vector3(0f, 0f, angle));
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotationF, 1);
                    angle = Mathf.Atan2(goL1.transform.position.y - goArray[i].transform.position.y, goL1.transform.position.x - goArray[i].transform.position.x) * Mathf.Rad2Deg;
                    var targetRotationL1 = Quaternion.Euler(new Vector3(0f, 0f, angle));
                    goL1.transform.rotation = Quaternion.Slerp(goL1.transform.rotation, targetRotationL1, 1);
                    Laser.SetActive(true);
                    Robot.velocity = new Vector3(0, 0, 0);
                }

            }


        }
        if (Time.time - firet > 0.4)
        {
            animator.SetBool("Attack", false);

        }
        if (Time.time - firet > 0.1)
        {
            Laser.SetActive(false);
        }
        if (Time.time - firet > 1.9)
        {
            Zvyk.SetActive(false);
        }
        if (hod < 1)
        {
            if ((transform.position - new Vector3(px, py, 0)).sqrMagnitude >= 1)
            {

                angle = Mathf.Atan2(transform.position.y - py, transform.position.x - px) * Mathf.Rad2Deg;
                var targetRotationS = Quaternion.Euler(new Vector3(0f, 0f, angle));
                transform.rotation = Quaternion.Slerp(transform.rotation, targetRotationS, 1);
            }
            if (zam < Time.time)
            {
                if ((transform.position - new Vector3(px, py, 0)).sqrMagnitude >= 1)
                {
                    animator.SetBool("Õîä", true);
                    Robot.velocity = (new Vector3(px, py, 0) - transform.position).normalized * 10;
                }
                else
                {
                    animator.SetBool("Õîä", false);
                    Robot.velocity = new Vector3(0, 0, 0);
                }
            }

        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.tag == "Laser")
        {
            if (Time.time - timeBlink > 10)
            {
                life -= 1;
            }

        }
        if (other.tag == "Snar2")
        {
            if (Time.time - timeBlink > 10)
            {
                life -= 25;
            }
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
            if (Time.time - timeBlink > 10)
            {
                life -= 10;
            }
        }
        if (other.tag == "Robots")
        {
            if (Time.time - timeBlink > 10)
            {
                life -= 50;
            }

        }

    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.tag == "Laser")
        {
            if (Time.time - timeBlink > 10)
            {
                life -= 1;
            }
        }
        if (other.tag == "Explosion")
        {
            if (Time.time - timeBlink > 10)
            {
                life -= 10;
            }
        }
    }
}

