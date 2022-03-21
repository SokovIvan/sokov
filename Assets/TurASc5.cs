using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class TurASc5 : MonoBehaviour
{
    float maxValue;
    public Color color = Color.red;
    public int width;
    public Slider slider;
    public GameObject goL1;
    public GameObject Laser;
    public GameObject F;
    float life;
    float px;
    float py;
    float hod;
    float firet;
    float zam;
    float n;
    Vector3 poss;
    float timt;
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
        timt = Time.time;
        GameConSc5.turAsN(1);
        poss = transform.position;
        Rigidbody2D Robot = GetComponent<Rigidbody2D>();
        life = 500;
        slider.fillRect.GetComponent<Image>().color = color;
        maxValue = life / 500;
        slider.maxValue = maxValue;
        slider.minValue = 0;
        UpdateUI();
        px = Random.Range(-15, 90);
        py = Random.Range(-60, 60);
        hod = 0;
        firet = 0;
        zam = 0;
        n = 1;
        GameConSc5.ureN(1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = poss;
        slider.value = life / 500;
        if ((life <= 0))
        {
            GameConSc5.ureN(-1);
            GameConSc5.turAsN(-1);
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
                if ((hod == 1) && (Time.time - firet > 0.4))
                {
                    firet = Time.time;
                    angle = Mathf.Atan2(transform.position.y - goArray[i].transform.position.y, transform.position.x - goArray[i].transform.position.x) * Mathf.Rad2Deg;
                    var targetRotationF = Quaternion.Euler(new Vector3(0f, 0f, angle));
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotationF, 1);
                    angle = Mathf.Atan2(goL1.transform.position.y - goArray[i].transform.position.y, goL1.transform.position.x - goArray[i].transform.position.x) * Mathf.Rad2Deg;
                    var targetRotationL1 = Quaternion.Euler(new Vector3(0f, 0f, angle));
                    goL1.transform.rotation = Quaternion.Slerp(goL1.transform.rotation, targetRotationL1, 1);
                    cur = Instantiate(Laser, goL1.transform.position, Quaternion.Slerp(goL1.transform.rotation, targetRotationL1, 1));
                    cur.GetComponent<Rigidbody2D>().velocity = (new Vector3(goArray[i].transform.position.x, goArray[i].transform.position.y, 0) - cur.transform.position).normalized * 40;
                    Robot.velocity = new Vector3(0, 0, 0);
                }

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
        if (other.tag == "Laser")
        {
            life -= 1;
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
