using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class RSoldSc : MonoBehaviour
{
    float maxValue;
    public Color color = Color.red;
    public int width;
    public Slider slider;
    Vector3 mousePos;
    Vector3 mousePosClick1;
    Vector3 mousePosClick2;
    Vector3 mousePosClick3;
    public GameObject goL1;
    public GameObject Roc;
    public GameObject tur;
    public GameObject Laser;
    public GameObject F;
    float life;
    float px;
    float py;
    float hod;
    float firet;
    float zam;
    float u;
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
        Rigidbody2D Robot = GetComponent<Rigidbody2D>();
        life = 50;
        slider.fillRect.GetComponent<Image>().color = color;
        maxValue = life / 100;
        slider.maxValue = maxValue;
        slider.minValue = 0;
        UpdateUI();
        px = Random.Range(-15, 90);
        py = Random.Range(-60, 60);
        GameObject[] gameObjects = GameObject.FindGameObjectsWithTag("Flag");
        GameObject a=gameObjects[Random.Range(0, gameObjects.Length-1)];
        px = a.transform.position.x;
        py = a.transform.position.y;
        hod = 0;
        firet = 0;
        zam = 0;
        u = 1;
        n = 1;
    }

    // Update is called once per frame
    void Update()
    {
        Roc.transform.position = goL1.transform.position;
        slider.value = life / 50;
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
            if ((((transform.position.x > mousePosClick1.x) && (transform.position.x < mousePosClick2.x)) || ((transform.position.x < mousePosClick1.x) && (transform.position.x > mousePosClick2.x))) && (((transform.position.y > mousePosClick1.y) && (transform.position.y < mousePosClick2.y)) || ((transform.position.y < mousePosClick1.y) && (transform.position.y > mousePosClick2.y))))
            {
                if ((GameCon.turAsY() < 3) && (GameCon.resa() > 5)&&(GameCon.elY()>=1))
                {                    
                    for(int i=0;i<5; i++)
                    {
                    GameCon.otA();
                    }                    
                Instantiate(tur, transform.position, Quaternion.identity);
                }
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
        if (life <= 0)
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
        for (int i = 0; i < goArray.Length; i++)
        {
            if ((goArray[i].transform.position - transform.position).sqrMagnitude <= 650)
            {
                GameObject cur;
                hod = hod + 1;
                if ((hod == 1) && (Time.time - firet > 1.5))
                {
                    firet = Time.time;
                    angle = Mathf.Atan2(transform.position.y - goArray[i].transform.position.y, transform.position.x - goArray[i].transform.position.x) * Mathf.Rad2Deg;
                    var targetRotationF = Quaternion.Euler(new Vector3(0f, 0f, angle));
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotationF, 1);
                    angle = Mathf.Atan2(goL1.transform.position.y - goArray[i].transform.position.y, goL1.transform.position.x - goArray[i].transform.position.x) * Mathf.Rad2Deg;
                    var targetRotationL1 = Quaternion.Euler(new Vector3(0f, 0f, angle));
                    goL1.transform.rotation = Quaternion.Slerp(goL1.transform.rotation, targetRotationL1, 1);
                    cur = Instantiate(Laser, goL1.transform.position, Quaternion.Slerp(goL1.transform.rotation, targetRotationL1, 1));
                    Robot.velocity = new Vector3(0, 0, 0);
                }

            }
        }
        if(Time.time-firet>1.5)
        {
            Roc.SetActive(true);
        }
        else
        {
            Roc.SetActive(false);
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
                    Robot.velocity = (new Vector3(px, py, 0) - transform.position).normalized * 10;
                }
                else
                {
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